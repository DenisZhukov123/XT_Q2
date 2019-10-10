using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.Entities
{
    public class Cars
    {
        public Guid ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YearOfManuf { get; set; }
        public int Power { get; set; }
        public byte[] Image { get; set; }

        public Cars(string brand, string model, DateTime manuf, int power, byte[] image)
        {
            ID = Guid.NewGuid();
            Brand = brand;
            Model = model;
            YearOfManuf = manuf;
            Power = power;
            Image = image;
        }
    }
}
