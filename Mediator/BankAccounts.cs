using System;
using System.Collections.Generic;

namespace Mediator
{
    /// <summary>
    /// Collegue class
    /// </summary>
    public class Account
    {
        public string Identifier { get; set; }
        public double Balance { get; private set; }
        private readonly IBank _bank;

        public Account(string identifier, double initialBalance, IBank bank)
        {
            Identifier = identifier;
            Balance = initialBalance;
            _bank = bank;
        }

        public void Deduct(double amount) => Balance -= amount;

        public void Add(double amount) => Balance += amount;

        public void SendMoney(string emailIdentifier, double amount) => _bank.SendMoney(this, emailIdentifier, amount);
    }

    /// <summary>
    /// Interface for mediator
    /// </summary>
    public interface IBank
    {
        void AddAccount(Account account);
        void SendMoney(Account fromAccount, string toEmailIdentifier, double amount);
    }

    /// <summary>
    /// Concrete mediator between bank accounts
    /// </summary>
    public class ABCBank : IBank
    {
        public Dictionary<string, Account> Accounts = new Dictionary<string, Account>();

        public void AddAccount(Account account)
        {
            Accounts.Add(account.Identifier, account);
        }

        public void SendMoney(Account fromAccount, string toEmailIdentifier, double amount)
        {
            if (!Accounts.ContainsKey(toEmailIdentifier))
            {
                throw new Exception(toEmailIdentifier + " is not being registered to an account.");
            }
            if (fromAccount.Balance < amount)
            {
                throw new Exception("Sending account does not have $" + amount + ".");
            }
            Console.WriteLine("Account {0} is sending ${1} to {2}", fromAccount.Identifier, amount, toEmailIdentifier);
            Console.WriteLine("Before sending the money, from_account has ${0}, to_account has ${1}", fromAccount.Balance, Accounts[toEmailIdentifier].Balance);
            fromAccount.Deduct(amount);
            Accounts[toEmailIdentifier].Add(amount);
            Console.WriteLine("After sending the money, from_account has ${0}, to_account has ${1}", fromAccount.Balance, Accounts[toEmailIdentifier].Balance);
        }
    }
}
