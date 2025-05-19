namespace Decorator
{
    public class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + ", має Меч";
        public override int GetPower() => _hero.GetPower() + 20;
    }

    public class Armor : HeroDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + ", має Броню";
        public override int GetPower() => _hero.GetPower() + 15;
    }

    public class Amulet : HeroDecorator
    {
        public Amulet(IHero hero) : base(hero) { }

        public override string GetDescription() => _hero.GetDescription() + ", має Магічний амулет";
        public override int GetPower() => _hero.GetPower() + 25;
    }

}
