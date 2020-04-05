using System;
using System.IO;
using System.Linq;
using System.Web;

namespace SeverManagementSystemMVC.Logger
{




    public class FileLogger:ILogger
    {
        public void Log(string name)
        {
            Console.WriteLine("Added Into File");
            string folder = @"C:\Temp\";
   
            string fileName = "abc.txt";
        
            string fullPath = folder + fileName;
          
            File.AppendAllLines(fullPath, new string[] { name });
        }
    }
}