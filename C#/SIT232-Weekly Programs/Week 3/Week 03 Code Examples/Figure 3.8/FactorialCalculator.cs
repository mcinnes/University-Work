/*************************************************************
** File: FactoiralCalculator.cs
** Author/s: Justin Rough
** Description:
**     A simple program for calculating the factorial of a
**     number.  The factorial method is implemented using
**     recursion.
*************************************************************/
using System;

namespace FactorialCalculator
{
    class FactorialCalculator
    {
        static ulong Factorial(ulong number)
        {
            ulong result;

            if (number == 0)
                result = 1; // base case
            else
                result = number * Factorial(number - 1); // general case

            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            ulong input = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine("{0}! = {1}", input, Factorial(input));
        }
    }
}
