using System;
using System.Collections.Generic;

namespace Command
{
    public class Transaction
    {
        private Guid Id;
        public string Item { get; set; }
        public double Amount { get; set; }
        public string Source { get; set; }
        private DateTime Timestamp { get; set; }

        public Transaction() { }

        public Transaction(string item, double amount, string source)
        {
            Id = Guid.NewGuid();
            Item = item;
            Amount = amount;
            Source = source;
            Timestamp = DateTime.Now;
        }

        public Transaction Clone()
        {
            return new Transaction()
            {
                Id = this.Id,
                Item = this.Item,
                Amount = this.Amount,
                Source = this.Source,
                Timestamp = this.Timestamp
            };
        }
        
        public bool Equal(Transaction t) => Id == t.Id;

        public void Display() => Console.WriteLine("Item: {0}, Amount: {1}, From: {2}, Timestamp: {3}", Item, Amount, Source, Timestamp.ToShortDateString());
    }

    /// <summary>
    /// Receiver class
    /// </summary>
    public class Bank
    {
        public string Name { get; }
        private double Balance { get; set; }
        public List<Transaction> Transactions = new List<Transaction>();

        public Bank(string name, double initialAmount)
        {
            Name = name;
            Balance = initialAmount;
        }

        public void AddBalance(double amount)
        {
            Balance += amount;
        }

        public void Display()
        {
            Console.WriteLine("Bank Account: {0}, Current Balance: {1}", Name, Balance);
            Console.WriteLine("Transactions: ");
            foreach (var transaction in Transactions)
            {
                transaction.Display();
            }
        }
    }
}
