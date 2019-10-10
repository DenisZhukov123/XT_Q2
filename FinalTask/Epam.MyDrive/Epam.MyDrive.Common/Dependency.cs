using Epam.MyDrive.BLL;
using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.DAL;
using Epam.MyDrive.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.Common
{
   public static class Dependency
    {
        private static IUsersLogic _usersLogic;
        private static IUsersDBDAO _usersDBDAO;
        private static ICarsLogic _carsLogic;
        private static ICarsDBDAO _carsDBDAO;
        private static IBlogsLogic _blogsLogic;
        private static IBlogsDBDAO _blogsDBDAO;
        private static ICommentsLogic _commentsLogic;
        private static ICommentsDBDAO _commentsDBDAO;
        private static IMessageLogic _messageLogic;
        private static IMessageDBDAO _messageDBDAO;
        private static ILoggerLogic _loggerLogic;
        private static ILoggerDAO _loggerDAO;

        public static IUsersDBDAO usersDBDAO => _usersDBDAO = new UsersDBDAO();
        public static IUsersLogic usersLogic => _usersLogic = new UsersLogic(usersDBDAO);
        public static ICarsDBDAO carsDBDAO => _carsDBDAO = new CarsDBDAO();
        public static ICarsLogic carsLogic => _carsLogic = new CarsLogic(carsDBDAO);
        public static IBlogsDBDAO blogsDBDAO => _blogsDBDAO = new BlogsDBDAO();
        public static IBlogsLogic blogsLogic => _blogsLogic = new BlogsLogic(blogsDBDAO);
        public static ICommentsDBDAO commentsDBDAO => _commentsDBDAO = new CommentsDBDAO();
        public static ICommentsLogic commentsLogic => _commentsLogic = new CommentsLogic(commentsDBDAO);
        public static IMessageDBDAO messageDBDAO => _messageDBDAO = new MessageDBDAO();
        public static IMessageLogic messageLogic => _messageLogic = new MessageLogic(messageDBDAO);
        public static ILoggerDAO loggerDAO => _loggerDAO = new LoggerDAO();
        public static ILoggerLogic loggerLogic => _loggerLogic = new LoggerLogic(loggerDAO);
    }
}
