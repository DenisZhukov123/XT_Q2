using Epam.MyDrive.DAL.Interfaces;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.DAL
{
    public class LoggerDAO : ILoggerDAO
    {

        private static ILog log = LogManager.GetLogger("LOGGER");

        public ILog Log
        {
            get { return log; }
        }

        public void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
