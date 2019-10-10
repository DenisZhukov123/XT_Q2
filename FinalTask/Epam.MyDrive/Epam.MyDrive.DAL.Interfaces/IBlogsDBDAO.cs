using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.DAL.Interfaces
{
    public interface IBlogsDBDAO
    {
        bool CreateBlogUser(Blogs blog, string nick);
        bool CreateBlogCar(Blogs blog, Guid id);
        Blogs GetBlogById(Guid id);
        bool EditBlog(Blogs blog);
        List<Blogs> GetUserBlogs(Users user);
        List<Blogs> GetCarBlogs(Cars user);
        bool DeleteBlogUser(Blogs blog, string nick);
        bool DeleteBlogCar(Blogs blog, Guid id);
        List<Blogs> SearchBlogs(string search);
    }
}
