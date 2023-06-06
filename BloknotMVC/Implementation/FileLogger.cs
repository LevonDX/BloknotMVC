using BloknotMVC.Services;

namespace BloknotMVC.Implementation
{
    public class FileLogger : ILoggerService
    {
        public void WriteLog(string message)
        {
            using StreamWriter writer = new StreamWriter("log.txt", true);
            writer.WriteLine(message);
        }
    }
}
