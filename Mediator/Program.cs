using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ABCBank aBCBank = new ABCBank();
            Account myAccount = new Account("my@gmail.com", 3000, aBCBank);
            Account otherAccount = new Account("other@hotmail.com", 4000, aBCBank);

            aBCBank.AddAccount(myAccount);
            aBCBank.AddAccount(otherAccount);

            myAccount.SendMoney("other@hotmail.com", 1000);
        }
    }
}
