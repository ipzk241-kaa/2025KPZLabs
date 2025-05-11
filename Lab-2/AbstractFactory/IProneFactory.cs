namespace AbstractFactory
{
    class IProneLaptop : ILaptop { }
    class IPronePhone : ISmartphone { }
    class IProneFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public ISmartphone CreateSmartphone() => new IPronePhone();
    }
}
