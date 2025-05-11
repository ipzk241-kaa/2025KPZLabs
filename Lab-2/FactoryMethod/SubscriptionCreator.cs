namespace FactoryMethod
{
    abstract class SubscriptionCreator
    {
        public abstract ISubscription CreateSubscription(string type);
    }

    class WebSite : SubscriptionCreator
    {
        public override ISubscription CreateSubscription(string type) => type switch
        {
            "Domestic" => new DomesticSubscription(),
            "Educational" => new EducationalSubscription(),
            "Premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Неправильний тип підписки")
        };
    }

    class MobileApp : SubscriptionCreator
    {
        public override ISubscription CreateSubscription(string type)
        {
            ISubscription original = new WebSite().CreateSubscription(type);
            return new DiscountedSubscription(original, 0.9);
        }
    }

    class ManagerCall : SubscriptionCreator
    {
        public override ISubscription CreateSubscription(string type)
        {
            return new PremiumSubscription();
        }
    }

    class DiscountedSubscription : ISubscription
    {
        private readonly ISubscription _base;
        private readonly double _discount;

        public DiscountedSubscription(ISubscription baseSub, double discount)
        {
            _base = baseSub;
            _discount = discount;
        }

        public double GetMonthlyFee() => Math.Round(_base.GetMonthlyFee() * _discount, 2, MidpointRounding.AwayFromZero);
        public int GetMinPeriod() => _base.GetMinPeriod();
        public string GetChannels() => _base.GetChannels();
    }
}
