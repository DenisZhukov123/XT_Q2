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
    public class BlogsLogic : IBlogsLogic
    {
        private readonly IBlogsDBDAO _blogsDBDAO;

        public BlogsLogic(IBlogsDBDAO blogDAO)
        {
            _blogsDBDAO = blogDAO;
        }
        public bool CreateBlogCar(Blogs blog, Guid id)
        {
            return _blogsDBDAO.CreateBlogCar(blog, id);
        }

        public bool CreateBlogUser(Blogs blog, string nick)
        {
            return _blogsDBDAO.CreateBlogUser(blog, nick);
        }

        public bool DeleteBlogCar(Blogs blog, Guid id)
        {
            return _blogsDBDAO.DeleteBlogCar(blog, id);
        }

        public bool DeleteBlogUser(Blogs blog, string nickname)
        {
            return _blogsDBDAO.DeleteBlogUser(blog, nickname);
        }

        public bool EditBlog(Blogs blog)
        {
            return _blogsDBDAO.EditBlog(blog);
        }

        public Blogs GetBlogById(Guid id)
        {
            return _blogsDBDAO.GetBlogById(id);
        }

        public List<Blogs> GetCarBlogs(Cars car)
        {
            return _blogsDBDAO.GetCarBlogs(car);
        }

        public List<Blogs> GetUserBlogs(Users user)
        {
            return _blogsDBDAO.GetUserBlogs(user);
        }

        public List<Blogs> SearchBlogs(string search)
        {
            return _blogsDBDAO.SearchBlogs(search);
        }
    }
}
