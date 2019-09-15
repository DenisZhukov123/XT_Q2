using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace _6._1_Users_and_awards.Entities
{
    public interface IUsersAndAwardsManageble
    {
        bool AddUser(string name, DateTime birth);
        User GetUser(Guid id);
        bool RemoveUser(Guid id);
        void EditUser(Guid id, string Name, DateTime Birth);
        void EditAward(Guid id, string Title, byte[] Image, bool flag_image);
        ICollection<User> GetAllUsers();
        bool AddAward(string title, byte[] image);
        List<Award> GetUserAward(Guid UserId);
        List<User> GetAwardUser(Guid AwardId);
        Award GetAward(Guid id);
        ICollection<Award> GetAllAwards();
        bool AddAwardToUser(Guid IdUser, Guid IdAward);
        bool RemoveAward(Guid id);
        void RecordFiles(string path);
        void ReadFiles(string path);
    }
}
