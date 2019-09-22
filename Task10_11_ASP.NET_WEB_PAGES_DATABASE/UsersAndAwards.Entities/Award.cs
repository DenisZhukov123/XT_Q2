using System;

namespace UsersAndAwards.Entities
{
    public class Award
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public Guid ImageName { get; set; }
        public Award(string title, byte[] image)
        {
            Id = Guid.NewGuid();
            Title = title;
            Image = image;
            ImageName = Guid.NewGuid();
        }
    }
}
