using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.MyDrive.WEB.Models
{
    public static class SearchPL
    {
        public static List<Users> SearchUsers = new List<Users>();
        public static List<Blogs> SearchBlogs = new List<Blogs>();
        public static void NewSearchUsers()
        {
            SearchUsers = new List<Users>();
        }
        public static void NewSearchBlogs()
        {
            SearchBlogs = new List<Blogs>();
        }
    }
}