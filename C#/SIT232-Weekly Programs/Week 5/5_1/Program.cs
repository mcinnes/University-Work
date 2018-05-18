/*************************************************************
** File: Program.cs
** Author/s: Justin Rough
** Description:
**     A simple demonstration of an inheritance hierarchy for
** a collection of bank accounts.  Two account types have been
** defined: a savings account and a credit card.
*************************************************************/
using System;

namespace BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savings = new SavingsAccount(1000.00M);
            CreditCard credit = new CreditCard(0.00M, 1000.00M);

            Console.WriteLine(savings);
            Console.WriteLine(credit);

            credit.Payment(100.00M);

            Console.WriteLine(credit);

            savings.Withdraw(600.00M);
            savings.Withdraw(600.00M);
            credit.Purchase(600.00M);
            credit.Purchase(600.00M);

            Console.WriteLine(savings);
            Console.WriteLine(credit);

            TermDeposit term = new TermDeposit(savings.Balance, 300);
        }
    }
}
