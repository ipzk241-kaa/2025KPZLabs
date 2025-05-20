namespace Mediator
{
    interface ICommandCentre
    {
        void RequestLanding(Aircraft aircraft);
        void RequestTakeOff(Aircraft aircraft);
    }

    class CommandCentre : ICommandCentre
    {
        private List<Runway> _runways = new List<Runway>();

        public CommandCentre(IEnumerable<Runway> runways)
        {
            _runways.AddRange(runways);
        }

        public void RequestLanding(Aircraft aircraft)
        {
            var freeRunway = _runways.FirstOrDefault(r => !r.IsBusy);

            if (freeRunway != null)
            {
                Console.WriteLine($"Літак {aircraft.Name} приземлився на злітно-посадкову смугу {freeRunway.Id}.");
                freeRunway.Occupy();
            }
            else
            {
                Console.WriteLine($"Літак {aircraft.Name} не зміг приземлитися. Немає вільної злітно-посадкової смуги.");
            }
        }

        public void RequestTakeOff(Aircraft aircraft)
        {
            var busyRunway = _runways.FirstOrDefault(r => r.IsBusy);

            if (busyRunway != null)
            {
                Console.WriteLine($"Літак {aircraft.Name} злітає з злітно-посадкової смуги {busyRunway.Id}.");
                busyRunway.Release();
            }
            else
            {
                Console.WriteLine($"Літак {aircraft.Name} не зміг злетіти. Літак не на злітно-посадковій смузі.");
            }
        }
    }
}