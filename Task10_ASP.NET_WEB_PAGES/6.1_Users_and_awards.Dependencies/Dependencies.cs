using _6._1_Users_and_awards.Entities;
using _6._1_Users_and_awards.DAL;
using _6._1_Users_and_awards.BLL;

namespace _6._1_Users_and_awards.Dependencies
{
    public static class Dependencies
    {
        private static IUsersStorable usersStorage;

        private static IAwardsStorable awardsStorage;

        private static IUserAwardTable userAwardTable;

        private static IUsersAndAwardsManageble usersAwardsManager;

        public static IUsersAndAwardsManageble UsersAwardsManager
        {
            get
            {
                return usersAwardsManager = new UsersAwardsManager(UsersStorage, AwardsStorage, UserAwardTable);
            }
        }
        public static IUsersStorable UsersStorage
        {
            get
            {
                return usersStorage = new MemoryStorage();
            }
        }

        public static IAwardsStorable AwardsStorage
        {
            get
            {
                return awardsStorage = new MemoryStorage();
            }
        }

        public static IUserAwardTable UserAwardTable
        {
            get
            {
                return userAwardTable = new MemoryStorage();
            }
        }

    }
}
