using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public class Award
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
