using System;
using System.Collections.Generic;
using System.Text;
using _6._1_Users_and_awards.Entities;
using _6._1_Users_and_awards.DAL;

namespace _6._1_Users_and_awards.Dependencies
{
    public static class Dependencies
    {
        public static IUsersStorable UsersStorage { get; } = new MemoryStorage();
        public static IAwardsStorable AwardsStorage { get; } = new MemoryStorage();
        public static IUserAwardTable UserAwardTable { get; } = new MemoryStorage();
    }
}
