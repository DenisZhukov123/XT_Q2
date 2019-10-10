using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.DAL.Interfaces
{
    public interface ICommentsDBDAO
    {
        bool CreateComment(Comments comment, Blogs blog);
        List<Comments> GetAllComments(Blogs blog);
    }
}
