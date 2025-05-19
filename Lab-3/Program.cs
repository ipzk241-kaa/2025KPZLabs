using Adapter;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== Консольний логгер ===");
        Logger consoleLogger = new Logger();
        consoleLogger.Log("Це повідомлення логгеру.");
        consoleLogger.Error("Це повідомлення про помилку.");
        consoleLogger.Warn("Це попереджувальне повідомлення.");

        Console.WriteLine("\n=== Файловий логер ===");
        FileLoggerAdapter fileLogger = new FileLoggerAdapter("log.txt");
        fileLogger.Log("Повідомлення файлового логеру.");
        fileLogger.Error("Файлове повідомлення про помилку.");
        fileLogger.Warn("Файлове попереджувальне повідомлення.");

        Console.WriteLine("Повідомлення збережені в 'log.txt'.");
    }
}
    