using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.DAL.Interfaces
{
    public interface IMessageDBDAO
    {
        bool CreateMessage(Message message);
        Message GetMessageById(Guid id);
        bool EditMessage(Message message);
        bool DeleteMessage(Guid id);
        List<Message> GetAllMyMessage(string nick);
        List<Message> GetAllMeMessage(string nick);
        List<Message> GetAllMessage();
    }
}
