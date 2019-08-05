using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    /// <summary>
    /// abstract class for command
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute(Bank bank, Transaction transaction);
    }

    /// <summary>
    /// Concrete command
    /// </summary>
    public class AddTransaction : Command
    {
        public override void Execute(Bank bank, Transaction transaction)
        {
            bank.Transactions.Add(transaction);
            bank.AddBalance(transaction.Amount);
        }
    }

    /// <summary>
    /// Concrete command
    /// </summary>
    public class ModifyTransaction : Command
    {
        public override void Execute(Bank bank, Transaction transaction)
        {
            Transaction found = bank.Transactions.FirstOrDefault(t => t.Equal(transaction));
            if (found != null)
            {
                bank.AddBalance(-found.Amount);
                found.Display();
                transaction.Display();
                bank.AddBalance(transaction.Amount);
                bank.Transactions.Remove(found);
                bank.Transactions.Add(transaction);
            }
            else
            {
                Console.WriteLine("The transaction is not existed in the current bank");
            }
        }
    }

    /// <summary>
    /// Concrete command
    /// </summary>
    public class DeleteTransaction : Command
    {
        public override void Execute(Bank bank, Transaction transaction)
        {
            var found = bank.Transactions.FirstOrDefault(t => t.Equal(transaction));
            if (found != null)
            {
                bank.AddBalance(-found.Amount);
                bank.Transactions.Remove(found);
            }
            else
            {
                Console.WriteLine("The transaction is not existed in the current bank");
            }
        }
    }

    /// <summary>
    /// Invoker class
    /// </summary>
    public class MoneyManager
    {
        public Dictionary<string, Bank> Banks;
        private Command _command;

        public MoneyManager() => Banks = new Dictionary<string, Bank>();

        public void AddBank(string nickname, Bank bank) => Banks.Add(nickname, bank);

        public void SetOperation(Command command) => _command = command;

        public void PerformOperation(string nickname, Transaction transaction)
        {
            if (Banks.ContainsKey(nickname))
            {
                Console.WriteLine("Before transaction: \n================");
                Banks[nickname].Display();
                _command.Execute(Banks[nickname], transaction);
                Console.WriteLine("After transaction: \n================");
                Banks[nickname].Display();
                Console.WriteLine();
            }
            
        }
    }
}
