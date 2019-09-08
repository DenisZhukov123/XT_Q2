
using _6._1_Users.Entities;
using _6._1_Users.DAL;
using _6._1_Users.BLL;

namespace _6._1_Users.Dependencies
{
    public static class Dependencies
    {
        private static IUsersStorable usersStorage;

        public static IUsersStorable UsersStorage
        {
            get
            {
                return usersStorage = new MemoryStorage();
            }
        }

        private static IUserManageble usersManager;

        public static IUserManageble UsersManager
        {
            get
            {
                return usersManager = new UsersManager(UsersStorage);
            }
        }
    }   
}
