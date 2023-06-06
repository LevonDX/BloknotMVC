using BloknotMVC.Services;
using System.Diagnostics;

namespace BloknotMVC.Implementation
{
    public class DebugLogger : ILoggerService
    {
        public void WriteLog(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
