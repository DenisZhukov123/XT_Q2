using System.Configuration;
using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;
using System.IO;
using System.Drawing;
using IUsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Common;



namespace _6._1_Users_and_awards.WEB.Models
{
    public static class UsersAndAwards
    {
        private static IUsersAndAwardsLogic usersandawardsLogic;
        public static string Path { get; private set; }
        private static string sAttr;
        public static int Remove { get; set; } = 0;
        public static int Count { get; set; } = 0;
        public static string Temp { get; set; }

        public static void ReadFiles(string path)
        {
            usersandawardsLogic.ReadFiles(path);
        }

        public static void Initialization()
        {
            sAttr = ConfigurationManager.AppSettings["Mode"];
            switch (sAttr)
            {
                case "0":
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory;
                        usersandawardsLogic = Dependencies.UsersAndAwardsDBLogic;
                    }
                    break;
                case "1":
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory;
                        usersandawardsLogic = Dependencies.UsersAndAwardsFileLogic;
                        ReadFiles(Path + @"App_Data");
                    }
                    break;
                default:
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory;
                        usersandawardsLogic = Dependencies.UsersAndAwardsFileLogic;
                        ReadFiles(Path + @"App_Data");
                    }
                    break;
            }
        }
        static public bool CheckBirthUser(string Birth, out DateTime birth)
        {
            DateTime now = DateTime.Now;
            if (DateTime.TryParse(Birth, out birth) == true)
            {
                if (birth <= now)
                    return true;
                return false;
            }
            return false;
        }

        static public bool CreateUser(string Name, string Birth)
        {
            if (CheckBirthUser(Birth, out DateTime birth)&&Name.Length!=0)
            {
                if (usersandawardsLogic.AddUser(Name, birth))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public static ICollection<User> GetAllUsers()
        {
            ICollection<User> users = usersandawardsLogic.GetAllUsers();
            return users;
        }

        static public void Save(string path)
        {
            if(sAttr=="1")
                usersandawardsLogic.RecordFiles(path+@"App_Data");
        }

        static public bool CheckGuid(string str_id, out Guid id)
        {
            if (Guid.TryParse(str_id, out  id))
                return true;
            return false;
        }

        static public bool RemoveUser(string Id)
        {
            if (CheckGuid(Id, out Guid id))
            {
                if (usersandawardsLogic.RemoveUser(id))
                    return true;
                else
                    return false;
            }
            return false;
        }

        static public bool EditUser(string Id, string Name, string Birth)
        {
            if (CheckGuid(Id, out Guid id))
            {
                User user = usersandawardsLogic.GetUser(id);
                if (Name.Length == 0)
                    Name = user.Name;
                if (Birth.Length == 0)
                    Birth = user.DateOfBirth.ToString();
                if (CheckBirthUser(Birth, out DateTime birth))
                {
                    usersandawardsLogic.EditUser(id, Name, birth);
                    return true;
                }
                else return false;
            }
            else return false;
        }
        static public bool CheckTitleAward(string Title)
        {
            if(Title.Length != 0)
                return true;
            return false;
        }

        static public bool CheckImageAward(string Image)
        {
            if (File.Exists(Image))
            {
                FileInfo Info = new FileInfo(Image);
                if (Info.Extension == ".png")
                    return true;
                else return false;
            }
           else return false;
        }

        static public bool CreateAward(string Title, string image)
        {
            if (CheckTitleAward(Title))
            {
                if (!CheckImageAward(image))
                    image = Path + @"Pages\Image\default.png";
                if (usersandawardsLogic.AddAward(Title,ImageToByte(image)))
                {
                    return true;
                }    
                else return false;
            }
            return false;
        }

        static public bool RemoveAward(string Id)
        {
            if (CheckGuid(Id, out Guid id))
            {
                if (usersandawardsLogic.RemoveAward(id))
                    return true;
                else
                    return false;
            }
            return false;
        }

        static public bool EditAward(string Id, string Title, string Image)
        {
            if (CheckGuid(Id, out Guid id))
            {
                if (!CheckTitleAward(Title))
                    Title = usersandawardsLogic.GetAward(id).Title;
                if (Image.Length != 0)
                {
                    if (!CheckImageAward(Image))
                        Image = Path + @"Pages\Image\default.png";
                    usersandawardsLogic.EditAward(id, Title, ImageToByte(Image), true);
                    return true;
                }
                else
                {
                    Image = Path + @"Pages\Image\default.png";
                    usersandawardsLogic.EditAward(id, Title, ImageToByte(Image), false);
                    return true;
                }
                
            }
            return false;
        }
        public static ICollection<Award> GetAllAward()
        {
            ICollection<Award> awards = usersandawardsLogic.GetAllAwards();
            return awards;
        }

        public static bool AddAwardToUser(string SUserID, string SAwardID)
        {
            if (CheckGuid(SUserID, out Guid UserId))
            {
                while (true)
                {
                    if (usersandawardsLogic.GetUser(UserId) != null)
                        break;
                    else
                        return false;
                };                    
            }
            else return false;
            if (CheckGuid(SAwardID, out Guid AwardId))
            {
                while (true)
                {
                    if (usersandawardsLogic.GetAward(AwardId) != null)
                        break;
                    else
                        return false;
                };
            }
            else return false;
            if (usersandawardsLogic.AddAwardToUser(UserId, AwardId))
            {
                return true;
            }
            return false;
        }

        public static List<Award> GetUserAward(string SUserID)
        {
            CheckGuid(SUserID, out Guid UserId);
            return usersandawardsLogic.GetUserAward(UserId);
        }
        public static byte[] ImageToByte(string path)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            return imageBytes;
        }
       
        public static List<User> GetAwardUser(string SAwardID)
        {
            CheckGuid(SAwardID, out Guid AwardID);
            return usersandawardsLogic.GetAwardUser(AwardID);
        }
        public static string GetImage(Award award)
        {
           
            using (MemoryStream ms = new MemoryStream(award.Image))
             {
                
                 using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))
                 {
                   
                    if (!File.Exists(Path+@"Pages\Image\" + award.ImageName.ToString()+".png"))
                    {
                        Bitmap newImage;
                        if (image.Width > 60)
                        {
                            int scale_width = image.Width / 60;
                            int scale_height = image.Height / 60;
                            newImage = new Bitmap(image, Convert.ToInt32(image.Width / scale_width), Convert.ToInt32(image.Height / scale_height));
                        }
                        else
                        {
                            newImage = new Bitmap(image, Convert.ToInt32(image.Width), Convert.ToInt32(image.Height));
                        }
                        newImage.Save(Path + @"Pages\Image\" + award.ImageName.ToString() + ".png");
                        return award.ImageName.ToString() + ".png";
                    }
                    else return award.ImageName.ToString() + ".png";
                }
             }
         }
        }
    }