using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL.Interfaces
{
    public interface ICommentsLogic
    {
        bool CreateComment(Comments comment, Blogs blog);
        List<Comments> GetAllComments(Blogs blog);
    }
}
