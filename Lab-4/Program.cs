using ChainOfResponsibility;
using Mediator;
using System.Text;

class Program
{
    static void Main()
    {
        //           ЛАНЦЮЖОК
        Console.OutputEncoding = Encoding.UTF8; 
        var basic = new BasicSupport();
        var tech = new TechnicalSupport();
        var billing = new BillingSupport();
        var manager = new ManagerSupport();

        basic.SetNext(tech);
        tech.SetNext(billing);
        billing.SetNext(manager);

        while (true)
        {
            Console.WriteLine("\nВітаємо у службі підтримки! Оберіть тип звернення:");
            Console.WriteLine("1 - Загальні питання");
            Console.WriteLine("2 - Технічна підтримка");
            Console.WriteLine("3 - Оплата");
            Console.WriteLine("4 - Звʼязатися з менеджером");
            Console.WriteLine("Інше - Повторити меню");

            Console.Write("Ваш вибір: ");
            var input = Console.ReadLine();
            var request = new SupportRequest(input);

            bool handled = basic.Handle(request);

            if (!handled)
            {
                Console.WriteLine("Ми не змогли визначити тип підтримки. Спробуйте ще раз.");
            }
            else
            {
                Console.WriteLine("Дякуємо за звернення!");
                break;
            }
        }

        //            ПОСЕРЕДНИК
        Console.WriteLine();
        var runways = new[] { new Runway(), new Runway() };
        var commandCentre = new CommandCentre(runways);

        var aircraft1 = new Aircraft("Boeing-737", commandCentre);
        var aircraft2 = new Aircraft("Airbus-A320", commandCentre);
        var aircraft3 = new Aircraft("Antonov-A256", commandCentre);

        aircraft1.RequestLanding();
        aircraft2.RequestLanding();
        aircraft3.RequestLanding();

        aircraft1.RequestTakeOff();
        aircraft2.RequestTakeOff();
        aircraft3.RequestTakeOff();
    }
}
