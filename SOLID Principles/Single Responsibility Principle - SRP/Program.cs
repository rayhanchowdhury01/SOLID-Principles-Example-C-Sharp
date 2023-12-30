 //Example without following SRP - Banking System using the Single Responsibility Principle

using System;
using System.Collections.Generic;

namespace SRP_Violation
{
    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        private List<string> Transations = new List<string>();

        public BankAccount(int accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Transations.Add($"Deposited ${amount}. New Balance: ${Balance}");
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            Transations.Add($"Withdrew ${amount}. New Balance: ${Balance}");
        }

        public void PrintStatement()
        {
            Console.WriteLine($"Statement for Account: {AccountNumber}");
            foreach (string s in Transations) Console.WriteLine(s);
        }
    }

    /*In this context, the BankAccount class takes care of:

    Conducting transaction operations.
    Generating the transaction statement.*/
}

namespace Valid_SRP
{
    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public List<string> Transactions = new List<string>();

        public BankAccount(int accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited ${amount}. New Balance: ${Balance}");
        }

        public void WithDraw(double amount)
        {
            Balance -= amount;
            Transactions.Add($"Withdrew ${amount}. New Balance: ${Balance}");
        }
    }

    public class StatementPrinter
    {
        public void Print(BankAccount bank)
        {
            Console.WriteLine($"Statement for Account: {bank.AccountNumber}");
            foreach (string s in bank.Transactions) Console.WriteLine(s);
        }
    }

    //Test Single Responsibility Principle
    public class Test
    {
        public static void Main(string[] args)
        {
            BankAccount MyAccount = new BankAccount(708090100);
            MyAccount.Deposit(100000);
            MyAccount.WithDraw(99999);

            StatementPrinter printer = new StatementPrinter();
            printer.Print(MyAccount);

            Console.ReadKey();
        }
        
        /*In this context:
         BankAccount has Single responsibility - Transaction- related operation
         StatementPrinter focuses on printing the statement
         
         The StatementPrinter class is dedicated to printing statements. 
         If there's a need to change the format or medium of the statement,
         modifications are exclusive to the StatementPrinter class. 
         The BankAccount class has nothing to do with that
        */
            
        
    }
}
/* OutPut:
Statement for Account: 708090100
Deposited $100000. New Balance: $100000
Withdrew $99999. New Balance: $1
*/