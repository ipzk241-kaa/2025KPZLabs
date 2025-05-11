using AbstractFactory;
using Builder;
using FactoryMethod;
using Prototype;
using Singleton;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // 1
        SubscriptionCreator creator = new MobileApp();
        ISubscription sub = creator.CreateSubscription("Premium");
        Console.WriteLine($"Щомісячна плата: ${sub.GetMonthlyFee()}, Канали: {sub.GetChannels()}");
        Console.WriteLine();
        // 2
        IDeviceFactory factory = new BalaxyFactory();
        var laptop = factory.CreateLaptop();
        var phone = factory.CreateSmartphone();
        IDeviceFactory factory2 = new IProneFactory();
        var IProne = factory2.CreateSmartphone(); // і взагалі чому саме IProne ну звучить якось не дуже
                                                  // буквально буквою помилитись і все смерть :D
        Console.WriteLine($"Фабрика клепає Balaxy пристрої: {laptop.GetType().Name}, {phone.GetType().Name}");
        Console.WriteLine($"Друга фабрика клепає IProne пристрої: {IProne.GetType().Name}");
        Console.WriteLine();
        // 3
        var a1 = Authenticator.GetInstance();
        var a2 = Authenticator.GetInstance();
        Console.WriteLine($"Перевіряємо чи однакові: {ReferenceEquals(a1, a2)}");
        Console.WriteLine();
        // 4
        var virus = new Virus("Alpha", "Corona", 0.1, 2);
        virus.AddChild(new Virus("Delta", "Mutation", 0.05, 1));
        virus.AddChild(new Virus("Gamma", "Mutation", 0.04, 1));
        Console.WriteLine("Створений вірус:");
        virus.Print();
        var clone = (Virus)virus.Clone();
        Console.WriteLine("Клонований вірус:");
        clone.Print();
        Console.WriteLine();
        // 5
        var hero = new HeroBuilder()
            .SetName("Бермольд")
            .SetBody("Атлетичний")
            .SetHairColor("Червоно малинове") //:D
            .SetEyeColor("Ярко червоні") //Типу як в бісинів з D&D в них вони трошки на демонічні схожі але ближче до людських
            .AddItem("Адамантовий меч")
            .AddItem(" Адамантова пластинчата броня вкрита драконячим барвником")
            .AddAction("Врятував смарагдовий гай")
            .AddAction("Врятував Місячні вежі")
            .Build();
        hero.Show();

        var enemy = new EnemyBuilder()
            .SetName("генерал Кетерік Торм")
            .SetBody("Високий")
            .SetHairColor("Біле")
            .SetEyeColor("Зелені") // не помню якшо чесно
            .AddItem("Молот Торма")
            .AddItem("Щит")
            .AddItem("Обладунки Обійми Жерця")
            .AddAction("Наклав прокляття тіней на Місячні вежі")
            .Build();
        enemy.Show();
    }
}
