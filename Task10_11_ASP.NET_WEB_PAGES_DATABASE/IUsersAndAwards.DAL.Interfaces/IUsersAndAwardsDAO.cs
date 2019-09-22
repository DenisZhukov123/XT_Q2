using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace IUsersAndAwards.DAL.Interfaces
{
    public interface IUsersAndAwardsDAO
    {
        bool AddUser(User user);
        bool RemoveUser(Guid id);
        User GetUser(Guid id);
        void EditUser(Guid id, string Name, DateTime Birth);
        void EditAward(Guid id, string Title, byte[] Image, bool flag_image);
        bool AddAward(Award award);
        Award GetAward(Guid id);
        bool AddAwardUser(Guid IdUser, Guid IdAward);
        List<Award> GetUserAward(Guid UserId);
        List<User> GetAwardUser(Guid AwardId);
        bool RemoveAward(Guid id);       
        ICollection<User> SelectAllUsers();
        ICollection<Award> SelectAllAwards();
        void RecordFiles(string path);
        void ReadFiles(string path);
    }
}
