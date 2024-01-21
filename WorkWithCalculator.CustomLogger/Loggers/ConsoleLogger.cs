using WorkWithCalculator.CustomLogger.Interfaces;

namespace WorkWithCalculator.CustomLogger.Loggers
{
    public class ConsoleLogger : Ilogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} - {message}");
            Console.ResetColor();
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} - {message}");
            Console.ResetColor();
        }
    }
}
