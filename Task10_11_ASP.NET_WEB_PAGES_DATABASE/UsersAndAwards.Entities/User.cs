using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                int age;
                DateTime now = DateTime.Now;
                age = now.Year - DateOfBirth.Year;
                if (now.Month < DateOfBirth.Month ||
                   (now.Month == DateOfBirth.Month &&
                    now.Day < DateOfBirth.Day))
                    age--;
                return age;
            }
        }

        public User(string name, DateTime birth)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = birth;
        }

    }
}
