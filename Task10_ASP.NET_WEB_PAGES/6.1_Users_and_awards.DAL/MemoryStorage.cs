using System;
using System.Collections.Generic;
using _6._1_Users_and_awards.Entities;
using System.Linq;
using System.IO;
using Newtonsoft.Json;


namespace _6._1_Users_and_awards.DAL
{
    public class MemoryStorage : IUsersStorable, IAwardsStorable, IUserAwardTable
    {
        private static List<User> Users { get; set; }
        private static List<Award> Awards { get; set; }
        private static TableUserAward<Guid> TableUserAward { get; set; }
        static MemoryStorage()
        {
            Users = new List<User>();
            Awards = new List<Award>();
            TableUserAward=new TableUserAward<Guid>();
        }
        public bool AddUser(User user)
        {
            if (Users.Any(n => n.Id == user.Id))
                return false;
            Users.Add(user);
            return true;
        }
        public bool RemoveUser(Guid id)
        {
            User tmp = Users.FirstOrDefault(x => x.Id == id);
            if (tmp == null)
                return false;
            TableUserAward.Remove(id);
            return Users.Remove(tmp);
        }
        public User GetUser(Guid id)
        {
            User user = Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void EditUser(Guid id, string Name, DateTime Birth)
        {
            Users.FindAll(x => x.Id == id).ForEach(s => { s.Name = Name; s.DateOfBirth = Birth; });
        }
           
        public void EditAward(Guid id, string Title, byte[] Image, bool flag_image)
        {
            if(flag_image)
                Awards.FindAll(x => x.Id == id).ForEach(s => { s.Title = Title;s.Image = Image; s.ImageName = Guid.NewGuid();});

            else
                Awards.FindAll(x => x.Id == id).ForEach(s => { s.Title = Title;});
        }

        public bool AddAward(Award award)
        {
            if (Awards.Any(x => x.Id == award.Id||x.Title == award.Title))
                return false;
            Awards.Add(award);
            return true;
        }
        public Award GetAward(Guid id)
        {
            Award award = Awards.FirstOrDefault(x => x.Id == id);
            return award;
        }

        public bool AddAwardUser(Guid IdUser, Guid IdAward)
        {
            TableUserAward.Add(IdUser, IdAward);
            return true;
        }
        public List<Award> GetUserAward(Guid UserId)
        {
            List<Award> ListAward = new List<Award>();
            for (int i = 0; i < TableUserAward.Count; i++)
            {
                if (TableUserAward[i, 0] == UserId)
                {
                    ListAward.Add(GetAward(TableUserAward[i, 1]));
                }
            }
            return ListAward;
        }

        public List<User> GetAwardUser(Guid AwardId)
        {
            List<User> ListUser = new List<User>();
            for (int i = 0; i < TableUserAward.Count; i++)
            {
                if (TableUserAward[i, 1] == AwardId)
                {
                    ListUser.Add(GetUser(TableUserAward[i, 0]));
                }
            }
            return ListUser;
        }

        public bool RemoveAward(Guid id)
        {
            Award tmp = Awards.FirstOrDefault(x => x.Id == id);
            if (tmp == null)
                return false;
            TableUserAward.Remove(id);
            return Awards.Remove(tmp);
        }
        /*
        public bool SetAwardImage(Guid id)
        {
           
           //File.AppendAllLines(this._awards_imageFile, new[] { CreateLineFromAwardImageID(id) });
            
           return false;
       
        }*/

        public static void RecordFiles(string path)
        {
            string ListOfUser = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(@path+@"\Users.json", ListOfUser);
            string ListOfAward = JsonConvert.SerializeObject(Awards, Formatting.Indented);
            File.WriteAllText(@path + @"\Awards.json", ListOfAward);
            using (StreamWriter sr1 = File.CreateText(@path + @"\TableUserAward.txt"))
            {
                for (int i = 0; i < TableUserAward.Count; i++)
                {
                    Guid[,] temp = new Guid[1, 2];
                    temp[0, 0] = TableUserAward[i, 0];
                    temp[0, 1] = TableUserAward[i, 1];
                    string ListOfTableUserAward = temp[0, 0].ToString() + ";" + temp[0, 1].ToString();
                    sr1.WriteLine(ListOfTableUserAward);
                }
            }
        }

        public static void ReadFiles(string path)
        {
            if (File.Exists(@path + @"\Users.json"))
            {
                Users = new List<User>();
                string users = File.ReadAllText(@path + @"\Users.json");
                Users = JsonConvert.DeserializeObject<List<User>>(users);
            }
            else
                Users = new List<User>();
            if (File.Exists(@path + @"\Awards.json"))
            {
                Awards = new List<Award>();
                string awards = File.ReadAllText(@path + @"\Awards.json");
                Awards = JsonConvert.DeserializeObject<List<Award>>(awards);
            }
            else
                Awards = new List<Award>();
            if (File.Exists(@path + @"\Users.json")&& File.Exists(@path + @"\Awards.json") &&File.Exists(@path + @"\TableUserAward.txt"))
            {
                TableUserAward = new TableUserAward<Guid>();
                string [] alltable = File.ReadAllLines(@path + @"\TableUserAward.txt");
                foreach (string s in alltable)
                {
                    string[] GuidTable = s.Split(';');
                    TableUserAward.Add(Guid.Parse(GuidTable[0]), Guid.Parse(GuidTable[1]));
                }
            }
            else
                TableUserAward = new TableUserAward<Guid>();
        }

        public ICollection<User> SelectAllUsers()
        {
            return Users;
        }
        public ICollection<Award> SelectAllAwards()
        {
            return Awards;
        }
    }
}
