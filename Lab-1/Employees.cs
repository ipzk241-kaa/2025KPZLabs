using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo
{
    public interface IEmployee
    {
        string GetPosition();
    }

    public class Zookeeper : IEmployee
    {
        public string GetPosition() => "Доглядач зоопарку";
    }

    public class Veterinarian : IEmployee
    {
        public string GetPosition() => "Ветеринар";
    }
}
