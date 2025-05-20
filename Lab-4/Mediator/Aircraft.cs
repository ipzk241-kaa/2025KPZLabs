namespace Mediator
{
    class Aircraft
    {
        public string Name { get; }
        public bool IsTakingOff { get; set; }
        private ICommandCentre _commandCentre;

        public Aircraft(string name, ICommandCentre commandCentre)
        {
            this.Name = name;
            this._commandCentre = commandCentre;
        }

        public void RequestLanding()
        {
            Console.WriteLine($"Літак {Name} просить про приземлиння.");
            _commandCentre.RequestLanding(this);
        }

        public void RequestTakeOff()
        {
            Console.WriteLine($"Літак {Name} просить про зліт.");
            _commandCentre.RequestTakeOff(this);
        }
    }
}