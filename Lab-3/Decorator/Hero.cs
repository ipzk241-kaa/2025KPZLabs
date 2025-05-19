namespace Decorator
{
    public interface IHero
    {
        string GetDescription();
        int GetPower();
    }
    public class Warrior : IHero
    {
        public string GetDescription() => "Воїн";
        public int GetPower() => 50;
    }

    public class Mage : IHero
    {
        public string GetDescription() => "Маг";
        public int GetPower() => 40;
    }

    public class Palladin : IHero
    {
        public string GetDescription() => "Паладин";
        public int GetPower() => 60;
    }

}
