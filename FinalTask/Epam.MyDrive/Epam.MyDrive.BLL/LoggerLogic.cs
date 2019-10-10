using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL
{
    public class LoggerLogic:ILoggerLogic
    {
        private readonly ILoggerDAO _loggerDAO;
        public LoggerLogic(ILoggerDAO loggerDAO)
        {
            _loggerDAO = loggerDAO;
        }

        public void InitLogger() => _loggerDAO.InitLogger();
        
    }
}
