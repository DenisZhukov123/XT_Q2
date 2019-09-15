using System;
using System.Collections.Generic;
using _6._1_Users_and_awards.Entities;
using _6._1_Users_and_awards.DAL;
using System.Drawing;

namespace _6._1_Users_and_awards.BLL
{
    public class UsersAwardsManager : IUsersAndAwardsManageble
    {
        private readonly IUsersStorable MemoryUserStorage;

        private readonly IAwardsStorable MemoryAwardStorage;

        private readonly IUserAwardTable UserAwardTable;


        public UsersAwardsManager(IUsersStorable MemoryUserStorage, IAwardsStorable MemoryAwardStorage, IUserAwardTable UserAwardTable)
        {
            this.MemoryUserStorage = MemoryUserStorage;
            this.MemoryAwardStorage = MemoryAwardStorage;
            this.UserAwardTable = UserAwardTable;
        }

        public bool AddUser(string name, DateTime birth)
        {
            return MemoryUserStorage.AddUser(new User(name, birth));
        }
        public User GetUser(Guid id)
        {
            return MemoryUserStorage.GetUser(id);
        }
        public bool RemoveUser(Guid id)
        {
            return MemoryUserStorage.RemoveUser(id);
        }

        public void EditUser(Guid id, string Name, DateTime Birth)
        {
            MemoryUserStorage.EditUser(id,Name,Birth);
        }

        public void EditAward(Guid id, string Title, byte[] image, bool flag_image)
        {
            MemoryAwardStorage.EditAward(id, Title, image, flag_image);
        }
        public ICollection<User> GetAllUsers()
        {
            return MemoryUserStorage.SelectAllUsers();
        }
        public bool AddAward(string title, byte[] image)
        {
            return MemoryAwardStorage.AddAward(new Award(title,image));
        }
        public List<Award> GetUserAward(Guid UserId)
        {
            return UserAwardTable.GetUserAward(UserId);
        }

        public List<User> GetAwardUser(Guid AwardId)
        {
            return UserAwardTable.GetAwardUser(AwardId);
        }
        public Award GetAward(Guid id)
        {
            return MemoryAwardStorage.GetAward(id);
        }
        public ICollection<Award> GetAllAwards()
        {
            return MemoryAwardStorage.SelectAllAwards();
        }
        public bool RemoveAward(Guid id)
        {
            return MemoryAwardStorage.RemoveAward(id);
        }
        public bool AddAwardToUser(Guid IdUser, Guid IdAward)
        {
            return UserAwardTable.AddAwardUser(IdUser, IdAward);
        }

        public void RecordFiles(string path)
        {
            MemoryStorage.RecordFiles(path);
        }
        public void ReadFiles(string path)
        {
            MemoryStorage.ReadFiles(path);
        }
    }
}
