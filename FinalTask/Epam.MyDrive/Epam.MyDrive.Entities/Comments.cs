using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.Entities
{
    public class Comments
    {
        public Guid ID { get; set; }
        public string Nickname { get; set; }
        public string Text { get; set; }
        public Comments(string nick, string text)
        {
            ID = Guid.NewGuid();
            Nickname = nick;
            Text = text;
        }
    }
}
