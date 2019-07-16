namespace AbstractFactory
{
    /// <summary>
    /// An abstract product 
    /// </summary>
    abstract class Phone { }

    /// <summary>
    /// An abstract product
    /// </summary>
    abstract class Computer { }

    /// <summary>
    /// The Abstract Factory class, which defines methods for creating abstract objects.
    /// </summary>
    abstract class ElectronicsFactory
    {
        abstract public Phone CreatePhone();
        abstract public Computer CreateComputer();
    }

    /// <summary>
    /// A concrete product
    /// </summary>
    class IPhone: Phone { }

    /// <summary>
    /// A concrete product
    /// </summary>
    class MacBookPro: Computer { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    class AppleFactory : ElectronicsFactory
    {
        public override Computer CreateComputer()
        {
            return new MacBookPro();
        }

        public override Phone CreatePhone()
        {
            return new IPhone();
        }
    }

    /// <summary>
    /// A concrete product 
    /// </summary>
    class MateLite : Phone { }

    /// <summary>
    /// A concrete product
    /// </summary>
    class MateBookPro: Computer { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    class HuaweiFactory : ElectronicsFactory
    {
        public override Computer CreateComputer()
        {
            return new MateBookPro();
        }

        public override Phone CreatePhone()
        {
            return new MateLite();
        }
    }
}
