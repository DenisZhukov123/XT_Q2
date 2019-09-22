using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace IUsersAndAwards.BLL.Interfaces
{
    public interface IUsersAndAwardsLogic
    {
        bool AddUser(string name, DateTime birth);
        User GetUser(Guid id);
        bool RemoveUser(Guid id);
        void EditUser(Guid id, string Name, DateTime Birth);
        void EditAward(Guid id, string Title, byte[] image, bool flag_image);
        ICollection<User> GetAllUsers();
        bool AddAward(string title, byte[] image);
        List<Award> GetUserAward(Guid UserId);
        List<User> GetAwardUser(Guid AwardId);
        Award GetAward(Guid id);
        ICollection<Award> GetAllAwards();
        bool RemoveAward(Guid id);
        bool AddAwardToUser(Guid IdUser, Guid IdAward);
        void RecordFiles(string path);
        void ReadFiles(string path);
    }
}
