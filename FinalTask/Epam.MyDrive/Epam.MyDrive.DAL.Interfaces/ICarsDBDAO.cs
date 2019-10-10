using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.DAL.Interfaces
{
    public interface ICarsDBDAO
    {
        bool CreateCar(Cars car, string nick);
        Cars GetCarById(Guid id);
        List<Cars> GetUserCars(Users user);
        List<Cars> GetAllCars();
        bool DeleteCar(Cars car);
    }
}
