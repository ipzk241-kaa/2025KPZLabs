namespace AbstractFactory
{
    class KiaomiLaptop : ILaptop { }
    class KiaomiPhone : ISmartphone { }
    class KiaomiFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public ISmartphone CreateSmartphone() => new KiaomiPhone();
    }
}
