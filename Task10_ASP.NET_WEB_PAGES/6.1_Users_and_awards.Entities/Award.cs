using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _6._1_Users_and_awards.Entities
{
    public class Award
    {
        public Guid Id { get; set; }
        public string Id_str
        {
            get
            {
                return Id.ToString();
            }
        }

        public string Title { get; set; }
        public byte[] Image { get; set; }
        public Guid ImageName { get; set; }

        /*public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }*/
        public Award(string title, byte[] image)
        {
            Id = Guid.NewGuid();
            Title = title;
            Image = image;
            ImageName= Guid.NewGuid();
        }
    }
}
