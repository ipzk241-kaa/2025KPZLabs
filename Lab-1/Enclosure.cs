using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo
{
    public class Enclosure
    {
        public string Type { get; }
        private List<IAnimal> animals = new();

        public Enclosure(string type)
        {
            Type = type;
        }

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }

        public void ShowAnimals()
        {
            Console.WriteLine($"Вольєр ({Type}) містить:");
            foreach (var animal in animals)
            {
                Console.WriteLine($" - {animal.GetAnimalType()}");
            }
        }
    }
}
