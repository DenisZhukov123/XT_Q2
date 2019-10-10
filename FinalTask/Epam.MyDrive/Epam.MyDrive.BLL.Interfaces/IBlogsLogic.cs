using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL.Interfaces
{
    public interface IBlogsLogic
    {
        bool CreateBlogUser(Blogs blog, string nick);
        bool CreateBlogCar(Blogs blog, Guid id);
        Blogs GetBlogById(Guid id);
        bool EditBlog(Blogs blog);
        bool DeleteBlogCar(Blogs blog, Guid id);
        bool DeleteBlogUser(Blogs blog, string nickname);
        List<Blogs> GetUserBlogs(Users user);
        List<Blogs> GetCarBlogs(Cars car);
        List<Blogs> SearchBlogs(string search);
    }
}
