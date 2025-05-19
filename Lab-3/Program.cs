using Adapter;
using Bridge;
using Decorator;
using Proxy;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        //         АДАПТЕР
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
        //             ДЕКОРАТОР
        Console.WriteLine();
        Console.WriteLine("=== РПГ Герой з інвентарем ===");

        IHero mage = new Mage();
        mage = new Amulet(new Armor(mage));

        Console.WriteLine(mage.GetDescription());
        Console.WriteLine("Сила: " + mage.GetPower());

        IHero warrior = new Warrior();
        warrior = new Sword(new Sword(new Armor(warrior)));

        Console.WriteLine("\n" + warrior.GetDescription());
        Console.WriteLine("Сила: " + warrior.GetPower());

        IHero palladin = new Palladin();
        palladin = new Armor(new Amulet(palladin));

        Console.WriteLine("\n" + palladin.GetDescription());
        Console.WriteLine("Сила: " + palladin.GetPower());

        //                МІСТ
        Console.WriteLine();
        Console.WriteLine("=== Відтворення форми ===");

        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle = new Circle(vectorRenderer);
        Shape square = new Square(rasterRenderer);
        Shape triangle = new Triangle(vectorRenderer);

        circle.Draw();
        square.Draw();
        triangle.Draw();

        //             ПРОКСІ
        Console.WriteLine();
        string path = "Text.txt";
        File.WriteAllText(path, "Рандомний\nТекст!");

        Console.WriteLine("=== SmartTextChecker ===");
        SmartTextChecker checker = new SmartTextChecker();
        checker.ReadFile(path);

        Console.WriteLine("\n=== SmartTextReaderLocker ===");
        SmartTextReaderLocker locker = new SmartTextReaderLocker(@"forbidden|secret|deny");
        locker.ReadFile("secretfile.txt");
        locker.ReadFile(path);
    }
}
    