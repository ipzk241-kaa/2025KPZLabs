namespace Mediator
{
    class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public bool IsBusy { get; private set; }

        public void Occupy()
        {
            IsBusy = true;
            HighLightRed();
        }

        public void Release()
        {
            IsBusy = false;
            HighLightGreen();
        }

        public void HighLightRed()
        {
            Console.WriteLine($"Злітно-посадкова смуга {Id} зараз ЗАЙНЯТА.");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Злітно-посадкова смуга {Id} зараз ВІЛЬНА.");
        }
    }
}