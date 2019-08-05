using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            // client
            MoneyManager moneyManager = new MoneyManager();

            // set up the data
            Bank discover = new Bank("DiscoverCard", 0);
            Bank chase = new Bank("ChaseCheckingAcount", 4000);

            moneyManager.AddBank("discover-cc", discover);
            moneyManager.AddBank("chase-ca", chase);

            // add transactions
            Transaction transaction1 = new Transaction("La La Land Movie", -8.99, "State Theater");
            Transaction transaction2 = new Transaction("Daniil Trifonov Concert", -100.00, "UMS");
            Transaction transaction4 = new Transaction("Salary", 3000, "Company");
            Command command = new AddTransaction();
            moneyManager.SetOperation(command);
            moneyManager.PerformOperation("discover-cc", transaction1);
            moneyManager.PerformOperation("discover-cc", transaction2);
            moneyManager.PerformOperation("chase-ca", transaction4);

            // alterate a transaction
            Transaction transaction3 = transaction2.Clone();
            transaction3.Amount = -150;
            command = new ModifyTransaction();
            moneyManager.SetOperation(command);
            moneyManager.PerformOperation("discover-cc", transaction3);

            // remove a transaction
            command = new DeleteTransaction();
            moneyManager.SetOperation(command);
            moneyManager.PerformOperation("chase-ca", transaction4);
        }
    }

}
