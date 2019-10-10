using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Epam.MyDrive.WEB.Models
{
    public static class CarsPL
    {
        private static ICarsLogic _carsLogic = Dependency.carsLogic;
        public static string Temp { get; set; }

        public static string Path { get; private set; }

        public static Cars GetCarById(Guid id)
        {
            return _carsLogic.GetCarById(id);
        }

        public static bool CheckStr(string str)
        {
            if (str.Length > 0 && str.Length < 25)
                return true;
            else return false;
        }

        static public bool CheckImage(string avatar)
        {
            if (avatar.Length > 0)
            {
                if (File.Exists(avatar))
                {
                    return true;
                }
            }
            return false;

        }
        public static byte[] ImageToByte(string path)
        {
            byte[] imageBytes;
            imageBytes = File.ReadAllBytes(path);
            return imageBytes;

        }

        static public bool CheckManufCar(string Manuf, out DateTime manuf)
        {
            if (DateTime.TryParse(Manuf, out manuf) == true)
            {
                return true;
            }
            return false;
        }

        public static bool CreateCar(string brand, string model, string manuf, string power, byte[] image, string nick)
        {
            byte[] tempImage;
            Path = AppDomain.CurrentDomain.BaseDirectory;
            if (!CheckStr(brand))
                return false;
            if (!CheckStr(model))
                return false;
            if (!CheckManufCar(manuf, out DateTime Manuf))
                return false;
            if (!int.TryParse(power, out int Power))
                return false;
            if (image!=null)
                tempImage = image;
            else
                tempImage = ImageToByte(Path + @"Pages\Image\default.png");

            Cars car = new Cars(brand, model, Manuf, Power, tempImage);
            return _carsLogic.CreateCar(car, nick);
        }

        public static void DeleteCar(Cars car)
        {
            if (_carsLogic.DeleteCar(car))
            {
                List<Blogs> ListBlogs = new List<Blogs>();
                ListBlogs = BlogsPL.GetCarBlogs(car);
                foreach (var item in ListBlogs)
                {
                    BlogsPL.DeleteBlogCar(item, car.ID);
                }
            }
        }
        public static List<Cars> GetUserCars(Users user)
        {
            return _carsLogic.GetUserCars(user);
        }

        public static List<Cars> GetAllCars()
        {
            return _carsLogic.GetAllCars();
        }
    }
}