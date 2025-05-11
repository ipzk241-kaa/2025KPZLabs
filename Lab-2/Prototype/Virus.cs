namespace Prototype
{
    class Virus : ICloneable
    {
        public string Name, Species;
        public double Weight;
        public int Age;
        public List<Virus> VChildren = new();

        public Virus(string name, string species, double weight, int age)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
        }

        public void AddChild(Virus child) => VChildren.Add(child);

        public object Clone()
        {
            Virus clone = new(Name, Species, Weight, Age);
            foreach (var child in VChildren)
            {
                clone.VChildren.Add((Virus)child.Clone());
            }
            return clone;
        }

        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}{Name} ({Species})");
            foreach (var child in VChildren)
            {
                child.Print(indent + "  ");
            }
        }
    }

}
