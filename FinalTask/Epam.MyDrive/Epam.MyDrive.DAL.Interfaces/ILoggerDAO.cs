﻿using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.DAL.Interfaces
{
    public interface ILoggerDAO
    {
        ILog Log { get; }

        void InitLogger();
    }
}
