using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeverManagementSystemMVC.Logger
{
    public class DbLogger : ILogger
    {
        public void Log(string name)
        {
            Console.WriteLine("Added Into Db");
        }
    }
}