using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL.Interfaces
{
    public interface ICarsLogic
    {
        bool CreateCar(Cars car,string nick);
        Cars GetCarById(Guid id);
        bool DeleteCar(Cars car);
        List<Cars> GetUserCars(Users user);
        List<Cars> GetAllCars();
    }
}
