using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.MyDrive.WEB.Models
{
    public static class MessagePL
    {
        private static IMessageLogic _messageLogic = Dependency.messageLogic;
        public static string Path { get; private set; }
        public static string Temp { get; set; }
        public static bool CreateMessage(string sendnick, string recnick, string text)
        {
            Message message = new Message(sendnick, recnick, text);
            return _messageLogic.CreateMessage(message);
        }

        public static Message GetMessageById(Guid id)
        {
            return _messageLogic.GetMessageById(id);
        }
        public static List<Message> GetAllMyMessage(string nick)
        {
            return _messageLogic.GetAllMyMessage(nick);
        }

        public static List<Message> GetAllMeMessage(string nick)
        {
            return _messageLogic.GetAllMeMessage(nick);
        }
        public static List<Message> GetAllMessage()
        {
            return _messageLogic.GetAllMessage();
        }

        public static bool EditMessage(Message mess,string text)
        {
            Message newmess = new Message(text);
            newmess.ID = mess.ID;
            newmess.RecNick = mess.RecNick;
            newmess.SendNick = mess.SendNick;
            return _messageLogic.EditMessage(newmess);
        }

        public static bool DeleteMessage(Guid id)
        {
            return _messageLogic.DeleteMessage(id);
        }
    }
}