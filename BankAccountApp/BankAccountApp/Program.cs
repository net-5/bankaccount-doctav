using System;

namespace BankAccountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BankAccount myAccount = new BankAccount();
            myAccount.AccountID = "RO42RNCB123456";
        }
    }
}
