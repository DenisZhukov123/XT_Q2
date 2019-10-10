using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.MyDrive.WEB.Models
{
    public static class CommentsPL
    {
        private static ICommentsLogic _commentsLogic = Dependency.commentsLogic;
        public static string Path { get; private set; }

        public static bool CreateComment(string text, Blogs blog, Users user)
        {
            Comments comment = new Comments(user.Nickname,text);
            return _commentsLogic.CreateComment(comment,blog);
        }

        public static List<Comments> GetAllComments(Blogs blog)
        {
            return _commentsLogic.GetAllComments(blog);
        }
    }
}