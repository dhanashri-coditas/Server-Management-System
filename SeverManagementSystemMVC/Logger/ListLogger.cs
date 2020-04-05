using System.Collections.Generic;

namespace SeverManagementSystemMVC.Logger
{
    public class ListLogger : ILogger
    {
        List<string> list = new List<string>();

        public void Log(string name)
        {
            list.Add(name);
   
        }
    }
}