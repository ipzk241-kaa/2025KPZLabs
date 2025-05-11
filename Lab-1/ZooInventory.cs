using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo
{
    public class ZooInventory
    {
        private List<IAnimal> animals = new();
        private List<IEmployee> employees = new();

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public void ShowInventory()
        {
            Console.WriteLine("=== Інформація по зоопарку ===");
            Console.WriteLine($"Всього тварин: {animals.Count}");
            foreach (var a in animals)
            {
                Console.WriteLine($" - {a.GetAnimalType()}");
            }

            Console.WriteLine($"Всього працівників: {employees.Count}");
            foreach (var e in employees)
            {
                Console.WriteLine($" - {e.GetPosition()}");
            }
        }
    }
}
