using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.DAL.Interfaces;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL
{
    public class CarsLogic : ICarsLogic
    {
        private readonly ICarsDBDAO _carsDBDAO;

        public CarsLogic(ICarsDBDAO carDAO)
        {
            _carsDBDAO = carDAO;
        }
        public Cars GetCarById(Guid id)
        {
            return _carsDBDAO.GetCarById(id);
        }

        public List<Cars> GetUserCars(Users user)
        {
            return _carsDBDAO.GetUserCars(user);
        }

        public bool CreateCar(Cars car, string nick)
        {
            return _carsDBDAO.CreateCar(car, nick);
        }

        public bool DeleteCar(Cars car)
        {
            return _carsDBDAO.DeleteCar(car);
        }
        public List<Cars> GetAllCars()
        {
            return _carsDBDAO.GetAllCars();
        }

    }
}
