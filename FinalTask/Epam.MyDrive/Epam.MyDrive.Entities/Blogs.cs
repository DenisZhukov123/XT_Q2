using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.Entities
{
    public class Blogs
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Blogs(string title, string text)
        {
            ID = Guid.NewGuid();
            Title = title;
            Text = text;
        }
    }
}
