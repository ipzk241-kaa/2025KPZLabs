namespace AbstractFactory
{
    class BalaxyLaptop : ILaptop { }
    class BalaxyPhone : ISmartphone { }
    class BalaxyFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public ISmartphone CreateSmartphone() => new BalaxyPhone();
    }
}
