/*************************************************************
** File: StringSorter.cs
** Author/s: Justin Rough
** Description:
**     A simple program that reads strings entered by the user
** and stores them in a List of strings until the user enters
** a value of END.  The program then sorts the list of values
** and outputs the result.
*************************************************************/
using System;
using System.Collections.Generic;

namespace StringSorter
{
    class StringSorter
    {
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>();
            string input;

            Console.Write("Please enter a string or END to finish: ");
            input = Console.ReadLine();
            while (input.ToUpper() != "END")
            {
                stringList.Add(input);
                Console.Write("Please enter a string or END to finish: ");
                input = Console.ReadLine();
            }

            stringList.Sort();
            Console.WriteLine("Sorted strings:");
            foreach (string s in stringList)
                Console.WriteLine("\t" + s);
        }
    }
}
