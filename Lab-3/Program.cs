using Adapter;
using Bridge;
using Command;
using Composite;
using Decorator;
using Flyweight;
using Proxy;
using State;
using System.Text;
using Visitor;

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
        palladin = new Armor(new Amulet(new Sword(palladin)));

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
        string path2 = "book.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл book.txt не знайдено!");
            return;
        }

        string[] lines = File.ReadAllLines(path2);
        var factory = new HtmlFlyweightFactory();
        var html = LightHtmlConverter.ConvertTextToHtml(lines, factory);

        Console.WriteLine("== LightHTML з Flyweight ==");
       // Console.WriteLine(html.OuterHTML);

        Console.WriteLine($"\nВсього унікальних тегів (Flyweight): {factory.SharedCount}");
        Console.WriteLine($"Загальна кількість об'єктів LightNode: {TreeAnalyzer.CountNodes(html)}");
        //           УВАГА!!! Далі йдуть завдання з лабораторної роботи 4
        //           Спостерігач
        Console.WriteLine("\n=== СПОСТЕРІГАЧ ===");
        var div = new LightElementNode("div");
        var button = new LightElementNode("button");
        var text = new LightTextNode("Натисни мене");

        button.AddChild(text);
        div.AddChild(button);

        button.CssClasses.Add("some-button");
        div.CssClasses.Add("some-div");
        button.AddEventListener("click", (type, sender) =>
        {
            string label = sender.CssClasses.Count > 0 ? $".{sender.CssClasses[0]}" : $"<{sender.TagName}>";
            Console.WriteLine($"Обробник: Ви натиснули на {label}!");
        });

        button.AddEventListener("mouseover", (type, sender) =>
        {
            string label = sender.CssClasses.Count > 0 ? $".{sender.CssClasses[0]}" : $"<{sender.TagName}>";
            Console.WriteLine($"Обробник: Навели курсор на {label}.");
        });

        Console.WriteLine("HTML:");
        Console.WriteLine(div.OuterHTML);
        Console.WriteLine();

        Console.WriteLine("Симуляція подій:");
        button.Trigger("mouseover");
        button.Trigger("click");
        button.Trigger("blur");

        //           СТРАТЕГІЯ
        var localImage = new LightImageNode("file://photo.jpg", new FileLoadStrategy());
        var webImage = new LightImageNode("https://imgur.com/logo.png", new NetworkLoadStrategy());

        var div2 = new LightElementNode("div");
        div2.AddChild(localImage);
        div2.AddChild(webImage);

        Console.WriteLine("HTML:");
        Console.WriteLine(div.OuterHTML);
        Console.WriteLine();

        Console.WriteLine("Завантаження:");
        Console.WriteLine(localImage.LoadInfo);
        Console.WriteLine(webImage.LoadInfo);
        //            УВАГА!!! Далі йдуть завдання з МКР 1
        //            КОМАНДА
        Console.WriteLine("\n=== КОМАНДА ===");
        //  Стару команду AddChild було прийнято рішення
        //  залишити щоб працював старий код в Program.cs
        var html2 = new LightElementNode("div");
        var p = new LightElementNode("p");
        var text2 = new LightTextNode("Старий текст");

        var manager = new CommandManager();
        manager.ExecuteCommand(new AddElementCommand(p, text2));
        Console.WriteLine(html2.OuterHTML);
        manager.ExecuteCommand(new AddElementCommand(html2, p));
        Console.WriteLine(html2.OuterHTML);
        manager.ExecuteCommand(new UpdateTextCommand(text2, "Новий текст"));
        manager.ExecuteCommand(new AddCssClassCommand(p, "highlighted"));

        Console.WriteLine(html2.OuterHTML);

        //              СТАН
        Console.WriteLine("\n=== СТАН ===");
        var div3 = new LightElementNode("div");
        div.AddChild(new LightTextNode("Hello world"));

        Console.WriteLine("Normal:");
        Console.WriteLine(div3.OuterHTML);

        div3.SetState(new HoverState());
        Console.WriteLine("\nHovered:");
        Console.WriteLine(div3.OuterHTML);

        div3.SetState(new ActiveState());
        Console.WriteLine("\nActive:");
        Console.WriteLine(div3.OuterHTML);

        //           ШАБЛОННИЙ МЕТОД
        Console.WriteLine("\n=== ШАБЛОННИЙ МЕТОД ===");
        var div4 = new LightElementNode("div");
        div4.CssClasses.Add("container");
        div4.SetState(new HoverState());

        div4.AddChild(new LightTextNode("МІЙ НОВИЙ LightHTML!"));

        Console.WriteLine(div4.OuterHTML);

        //            ВІДВІДУВАЧ
        Console.WriteLine("\n=== Відвідувач ===");
        var div5 = new LightElementNode("div");
        div.CssClasses.Add("wrapper");

        var p1 = new LightElementNode("p");
        p1.AddChild(new LightTextNode("Текст Текст"));
        p1.AddChild(new LightTextNode("Ше одна стрічка тексту."));

        div5.AddChild(p1);
        div5.AddChild(new LightTextNode("Окремий текст"));

        var visitor = new NodeCounterVisitor();
        div5.Accept(visitor);
        // в принципі щось подібне до TreeAnalyzer.CountNodes(html) з легковаговика
        // але за іншим шаблоном.
        Console.WriteLine($"Елементи: {visitor.ElementCount}, Текстові ноди(вузли): {visitor.TextCount}");

    }
}
    