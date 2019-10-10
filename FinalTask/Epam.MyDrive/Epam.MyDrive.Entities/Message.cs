using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.Entities
{
    public class Message
    {
        public Guid ID { get; set; }
        public string SendNick { get; set; }
        public string RecNick { get; set; }
        public string Text { get; set; }
        public Message(string sendnick, string recnick, string text)
        {
            ID = Guid.NewGuid();
            SendNick = sendnick;
            RecNick = recnick;
            Text = text;
        }
        public Message(string text)
        {
            ID = Guid.NewGuid();
            Text = text;
        }
    }
}
