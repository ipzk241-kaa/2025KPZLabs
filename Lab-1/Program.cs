using System.Text;
using zoo;
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        IAnimal lion = new Lion();
        IAnimal parrot = new Parrot();

        IEmployee zookeeper = new Zookeeper();
        IEmployee vet = new Veterinarian();

        Enclosure savannahEnclosure = new Enclosure("Савана");
        Enclosure tropicalEnclosure = new Enclosure("Тропіки");

        savannahEnclosure.AddAnimal(lion);
        tropicalEnclosure.AddAnimal(parrot);

        Console.WriteLine("=== Інформація про Вольєри===");
        savannahEnclosure.ShowAnimals();
        tropicalEnclosure.ShowAnimals();

        ZooInventory inventory = new ZooInventory();

        inventory.AddAnimal(lion);
        inventory.AddAnimal(parrot);
        inventory.AddEmployee(zookeeper);
        inventory.AddEmployee(vet);

        inventory.ShowInventory();

        Console.WriteLine("\n=== Звуки тварин ===");
        lion.MakeSound();
        parrot.MakeSound();
    }
}
