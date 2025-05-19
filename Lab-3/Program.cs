using Adapter;
using Bridge;
using Composite;
using Decorator;
using Flyweight;
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

        //         Компонувальник
        Console.WriteLine("=== LightHTML ===");

        var table = new LightElementNode("table", DisplayType.Block, ClosingType.Normal);
        table.CssClasses.Add("my-table");

        for (int i = 0; i < 3; i++)
        {
            var row = new LightElementNode("tr");

            for (int j = 0; j < 3; j++)
            {
                var cell = new LightElementNode("td");
                cell.AddChild(new LightTextNode($"R{i + 1}C{j + 1}"));
                row.AddChild(cell);
            }

            table.AddChild(row);
        }

        Console.WriteLine("OuterHTML:");
        Console.WriteLine(table.OuterHTML);
        Console.WriteLine("\nInnerHTML:");
        Console.WriteLine(table.InnerHTML);

        //            ЛЕГКОВАГОВИК
        Console.WriteLine();
        string[] lines = {
            "Тпу Назва Книги",
            "Типу H2 тег",
            "    Типу абзац з відступом.",
            "Типу трошки длінного тексту шоб воно подумало шо це вже параграф.",
            "Ше трошки тест H2",
            "А тут уже знову звичайний параграф для цього треба більше символів.",
            "Я втомився("
        };
        var factory = new HtmlFlyweightFactory();
        var html = LightHtmlConverter.ConvertTextToHtml(lines, factory);

        Console.WriteLine("== LightHTML з Flyweight ==");
        Console.WriteLine(html.OuterHTML);

        Console.WriteLine($"\nВсього унікальних тегів (Flyweight): {factory.SharedCount}");
        Console.WriteLine($"Загальна кількість об'єктів LightNode: {TreeAnalyzer.CountNodes(html)}");
    }
}
    