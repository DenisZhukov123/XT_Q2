using UsersAndAwards.Entities;
using IUsersAndAwards.BLL.Interfaces;
using IUsersAndAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;


namespace UsersAndAwards.BLL
{
    public class UsersAwardsManager : IUsersAndAwardsLogic
    {
       
        private readonly IUsersAndAwardsDAO _usersandawardsDao;

        public UsersAwardsManager(IUsersAndAwardsDAO usersandawardsDao)
        {
            _usersandawardsDao = usersandawardsDao;
        }
       
        public bool AddUser(string name, DateTime birth)
        {
            return _usersandawardsDao.AddUser(new User(name, birth));
        }
        public User GetUser(Guid id)
        {
            return _usersandawardsDao.GetUser(id);
        }
        public bool RemoveUser(Guid id)
        {
            return _usersandawardsDao.RemoveUser(id);
        }

        public void EditUser(Guid id, string name, DateTime birth)
        {
            _usersandawardsDao.EditUser(id, name, birth);
        }

        public void EditAward(Guid id, string title, byte[] image, bool flag_image)
        {
            _usersandawardsDao.EditAward(id, title, image, flag_image);
        }
        public ICollection<User> GetAllUsers()
        {
            return _usersandawardsDao.SelectAllUsers();
        }
        public bool AddAward(string title, byte[] image)
        {
            return _usersandawardsDao.AddAward(new Award(title, image));
        }
        public List<Award> GetUserAward(Guid UserId)
        {
            return _usersandawardsDao.GetUserAward(UserId);
        }

        public List<User> GetAwardUser(Guid AwardId)
        {
            return _usersandawardsDao.GetAwardUser(AwardId);
        }
        public Award GetAward(Guid id)
        {
            return _usersandawardsDao.GetAward(id);
        }
        public ICollection<Award> GetAllAwards()
        {
            return _usersandawardsDao.SelectAllAwards();
        }
        public bool RemoveAward(Guid id)
        {
            return _usersandawardsDao.RemoveAward(id);
        }
        public bool AddAwardToUser(Guid IdUser, Guid IdAward)
        {
            return _usersandawardsDao.AddAwardUser(IdUser, IdAward);
        }

        public void RecordFiles(string path)
        {
            _usersandawardsDao.RecordFiles(path);
        }
        public void ReadFiles(string path)
        {
            _usersandawardsDao.ReadFiles(path);
        }
    }
}
