using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Epam.MyDrive.WEB.Models
{
    public static class BlogsPL
    {
        private static IBlogsLogic _blogsLogic = Dependency.blogsLogic;
        public static string Temp { get; set; }
        public static string Path { get; private set; }

        public static Blogs GetBlogsById(Guid id)
        {
            return _blogsLogic.GetBlogById(id);
        }

        public static bool CheckStr(string str)
        {
            if (str.Length > 0 && str.Length < 25)
                return true;
            else return false;
        }

       
        static public bool CheckManufCar(string Manuf, out DateTime manuf)
        {
            if (DateTime.TryParse(Manuf, out manuf) == true)
            {
                return true;
            }
            return false;
        }

        public static bool CreateBlogUser(string title, string text, string nick)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            if (!CheckStr(title))
                return false;
            Blogs blog = new Blogs(title, text);
            return _blogsLogic.CreateBlogUser(blog, nick);
        }

        public static bool CreateBlogCar(string title, string text, Guid id)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            if (!CheckStr(title))
                return false;
            Blogs blog = new Blogs(title, text);
            return _blogsLogic.CreateBlogCar(blog, id);
        }
        public static List<Blogs> GetUserBlogs(Users user)
        {
            return _blogsLogic.GetUserBlogs(user);
        }

        public static List<Blogs> GetCarBlogs(Cars car)
        {
            return _blogsLogic.GetCarBlogs(car);
        }
        public static bool DeleteBlogCar(Blogs blog, Guid id)
        {
            return _blogsLogic.DeleteBlogCar(blog, id);
        }

        public static bool DeleteBlogUser(Blogs blog, string nickname)
        {
            return _blogsLogic.DeleteBlogUser(blog, nickname);
        }

        public static bool EditBlog(Blogs blog, string title, string text)
        {
            Blogs newblog = new Blogs(title, text);
            newblog.ID = blog.ID;
            return _blogsLogic.EditBlog(newblog);
        }
        public static List<Blogs> SearchBlogs(string search)
        {
            return _blogsLogic.SearchBlogs(search);
        }
    }
}