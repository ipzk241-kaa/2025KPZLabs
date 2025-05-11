using AbstractFactory;
using FactoryMethod;
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
    }
}
