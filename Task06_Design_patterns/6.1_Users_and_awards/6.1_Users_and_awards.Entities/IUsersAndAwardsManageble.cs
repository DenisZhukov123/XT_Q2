using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public interface IUsersAndAwardsManageble
    {
        bool AddUser(string name, DateTime birth);
        User GetUser(Guid id);

        bool RemoveUser(Guid id);

        ICollection<User> GetAllUsers();

        bool AddAward(string title);

        List<Award> GetUserAward(Guid UserId);

        Award GetAward(Guid id);

        ICollection<Award> GetAllAwards();

        bool AddAwardToUser(Guid IdUser, Guid IdAward);

        void RecordFiles(string path);

        void ReadFiles(string path);
    }
}
