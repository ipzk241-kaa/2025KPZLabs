namespace AbstractFactory
{
    interface ILaptop { }
    interface ISmartphone { }
    interface IDeviceFactory
    {
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
    }
}
