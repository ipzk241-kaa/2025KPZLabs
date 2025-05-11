using FactoryMethod;
class Program
{
    static void Main(string[] args)
    {
        // 1
        SubscriptionCreator creator = new MobileApp();
        ISubscription sub = creator.CreateSubscription("Premium");
        Console.WriteLine($"Щомісячна плата: ${sub.GetMonthlyFee()}, Канали: {sub.GetChannels()}");
    }
}
