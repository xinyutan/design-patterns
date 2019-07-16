using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose the brand you want to buy from: Apple (a) or Huawei (h): ");
            char input = Console.ReadKey().KeyChar;

            ElectronicsFactory electronicsFactory;
            switch (input)
            {
                case 'a':
                    electronicsFactory = new AppleFactory();
                    break;

                case 'h':
                    electronicsFactory = new HuaweiFactory();
                    break;

                default:
                    throw new NotImplementedException();
            }

            var computer = electronicsFactory.CreateComputer();
            var phone = electronicsFactory.CreatePhone();

            Console.WriteLine("\nComputer: " + computer.GetType().Name);
            Console.WriteLine("Phone: " + phone.GetType().Name);

            Console.ReadKey();
        }
    }
}
