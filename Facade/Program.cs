using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderService = new OrderService();

            var order1 = new Order("The Fountainhead", 2, (float)7.99);
            orderService.PlaceOrder(order1, "Ann Arbor, MI", "abc@gmail.com", "1234");

            var order2 = new Order("The Birth of Tragedy", 1, (float)3.99);
            orderService.PlaceOrder(order2, "Detroit, MI", "xyz@yahoo.com", "56789");
        }
    }
}
