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
    public class MessageLogic : IMessageLogic
    {
        private readonly IMessageDBDAO _messageDBDAO;
        public MessageLogic(IMessageDBDAO messageDAO)
        {
            _messageDBDAO = messageDAO;
        }

        public bool CreateMessage(Message message)
        {
            return _messageDBDAO.CreateMessage(message);
        }

        public bool EditMessage(Message message)
        {
            return _messageDBDAO.EditMessage(message);
        }

        public List<Message> GetAllMeMessage(string nick)
        {
            return _messageDBDAO.GetAllMeMessage(nick);
        }

        public List<Message> GetAllMyMessage(string nick)
        {
            return _messageDBDAO.GetAllMyMessage(nick);
        }

        public Message GetMessageById(Guid id)
        {
            return _messageDBDAO.GetMessageById(id);
        }
        public bool DeleteMessage(Guid id)
        {
            return _messageDBDAO.DeleteMessage(id);
        }

        public List<Message> GetAllMessage()
        {
            return _messageDBDAO.GetAllMessage();
        }
    }
}
