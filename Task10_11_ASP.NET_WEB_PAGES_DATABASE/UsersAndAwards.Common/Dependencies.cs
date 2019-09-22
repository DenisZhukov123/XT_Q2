using _6._1_UsersAndAwards.DAL;
using IUsersAndAwards.BLL.Interfaces;
using IUsersAndAwards.DAL.Interfaces;
using UsersAndAwards.BLL;

namespace UsersAndAwards.Common
{
    public static class Dependencies
    {
        private static  IUsersAndAwardsLogic _usersandawardsFileLogic;
        private static IUsersAndAwardsLogic _usersandawardsDBLogic;
        private static  IUsersAndAwardsDAO _usersandawardsFileDao;
        private static  IUsersAndAwardsDAO _usersandawardsDBDao;

        public static IUsersAndAwardsDAO UsersAndAwardsFileDAO => _usersandawardsFileDao=new MemoryStorage();
        public static IUsersAndAwardsDAO UsersAndAwardsDBDAO => _usersandawardsDBDao=new DataBase();
        public static IUsersAndAwardsLogic UsersAndAwardsFileLogic => _usersandawardsFileLogic = new UsersAwardsManager(UsersAndAwardsFileDAO);
        public static IUsersAndAwardsLogic UsersAndAwardsDBLogic => _usersandawardsDBLogic = new UsersAwardsManager(UsersAndAwardsDBDAO);
    }
}
