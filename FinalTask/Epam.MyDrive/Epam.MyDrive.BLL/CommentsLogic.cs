using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.DAL.Interfaces;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL
{
    public class CommentsLogic : ICommentsLogic
    {
        private readonly ICommentsDBDAO _commentsDBDAO;
        public CommentsLogic(ICommentsDBDAO commentsDAO)
        {
            _commentsDBDAO = commentsDAO;
        }

        public bool CreateComment(Comments comment, Blogs blog)
        {
            return _commentsDBDAO.CreateComment(comment,blog);
        }

        public List<Comments> GetAllComments(Blogs blog)
        {
            return _commentsDBDAO.GetAllComments(blog);
        }

    }
}
