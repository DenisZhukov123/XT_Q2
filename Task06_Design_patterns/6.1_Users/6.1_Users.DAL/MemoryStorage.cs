using System;
using System.Collections.Generic;
using System.Text;
using _6._1_Users.Entities;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
namespace _6._1_Users.DAL
{
    public class MemoryStorage : IUsersStorable
    {
        private static List<User> Users { get; set; }
        static MemoryStorage()
        {
            Users = new List<User>();
        }
        public bool AddUser(User user)
        {
            if (Users.Any(x => x.Id == user.Id))
                return false;
            Users.Add(user);
            return true;
        }

        public bool RemoveUser(Guid id)
        {
            User tmp = Users.FirstOrDefault(x => x.Id == id);
            if (tmp == null)
                return false;
            return Users.Remove(tmp);
        }

        public void RecordFile(string path)
        {
            string ListOfUser = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(@path+@"\Users.json", ListOfUser);
        }

        public void ReadFile(string path)
        {
            if (File.Exists(@path+@"\Users.json"))
            {
                Users = new List<User>();
                string users = File.ReadAllText(@path + @"\Users.json");
                Users = JsonConvert.DeserializeObject<List<User>>(users);
            }
            else
                Users = new List<User>();
        }

        public ICollection<User> SelectAllUsers()
        {
            return Users;
        }
    }
}
