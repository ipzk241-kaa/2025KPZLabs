using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo
{
    public interface IAnimal
    {
        void MakeSound();
        string GetAnimalType();
    }

    public class Lion : IAnimal
    {
        public void MakeSound() => Console.WriteLine("Грааар!");
        public string GetAnimalType() => "Лев";
    }

    public class Parrot : IAnimal
    {
        public void MakeSound() => Console.WriteLine("Каар!(хз який звук попугаї видають ._.)");
        public string GetAnimalType() => "Попугай";
    }
}
