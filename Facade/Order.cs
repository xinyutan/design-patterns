using System;

namespace Facade
{
    class Order
    {
        string Name { get; set; }
        int Quantity { get; set; }
        float UnitPrice { get; set; }

        public Order(string name, int quantity, float unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return Quantity.ToString() + " " + Name;
        }

        public float GetAmount()
        {
            return UnitPrice * Quantity;
        }
    }

    class EmailService
    {
        public void SendEmail(string email, DateTime scheduleTime, string content)
        {
            Console.WriteLine("Sending an email to {0} at {1} with content '{2}'.", email, scheduleTime.ToString(), content);
        }
    }

    class FinancialService
    {
        public void Charge(string cardnumber, Order order)
        {
            Console.WriteLine("Charging card {0} ${1}.", cardnumber, order.GetAmount());
        }
    }

    class ShippingService
    {
        public void Ship(Order order, string address)
        {
            Console.WriteLine("Shipping {0} to {1}", order.ToString(), address);
        }
    }

    /// <summary>
    /// Facade, the service class that wrapped other process services
    /// </summary>
    class OrderService
    {
        protected EmailService _emailService;
        protected FinancialService _financialService;
        protected ShippingService _shippingService;

        public OrderService()
        {
            _emailService = new EmailService();
            _financialService = new FinancialService();
            _shippingService = new ShippingService();
        }

        public void PlaceOrder(Order order, string address, string email, string cardnumber)
        {
            _emailService.SendEmail(email, DateTime.Now, "Your order is placed.");
            _shippingService.Ship(order, address);
            _financialService.Charge(cardnumber, order);
        }
    }
}
