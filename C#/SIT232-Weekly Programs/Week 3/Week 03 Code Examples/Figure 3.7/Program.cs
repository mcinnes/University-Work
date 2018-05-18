/*************************************************************
** File: Program.cs
** Author/s: Justin Rough
** Description:
**     A simple Main method to demonstrate use of the Mortgage
** class.  The value of the mortgage is obtained from the user
** which is then used to create a Mortgage object, charge
** interest for 30 days, and display the balance that results.
*************************************************************/
using System;

namespace Mortgage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is the value of the mortgage? ");
            Mortgage clientMortgage = new Mortgage(Convert.ToDecimal(Console.ReadLine()));

            Console.WriteLine("Interest rate is {0:p}", Mortgage.InterestRate);
            clientMortgage.ChargeInterest(30);
            Console.WriteLine("The balance becomes {0:c} after 30 days interest are charged.", clientMortgage.Balance);
        }
    }
}
