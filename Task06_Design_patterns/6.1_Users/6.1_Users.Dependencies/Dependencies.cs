using System;
using System.Collections.Generic;
using System.Text;
using _6._1_Users.Entities;
using _6._1_Users.DAL;

namespace _6._1_Users.Dependencies
{
    public static class Dependencies
    {
        public static IUsersStorable UsersStorage { get; } = new MemoryStorage();
    }
}
