namespace FactoryMethod
{
    interface ISubscription
    {
        double GetMonthlyFee();
        int GetMinPeriod();
        string GetChannels();
    }

    class DomesticSubscription : ISubscription
    {
        public double GetMonthlyFee() => 9.99;
        public int GetMinPeriod() => 1;
        public string GetChannels() => "Новини, Розваги";
    }

    class EducationalSubscription : ISubscription
    {
        public double GetMonthlyFee() => 5.99;
        public int GetMinPeriod() => 3;
        public string GetChannels() => "Наука, Документальне";
    }

    class PremiumSubscription : ISubscription
    {
        public double GetMonthlyFee() => 19.99;
        public int GetMinPeriod() => 6;
        public string GetChannels() => "Всі канали включено";
    }
}