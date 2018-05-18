/*
Matt McInnes
mpmcinne
214119048
*/
using System;

namespace _3_1
{
    class Program
    {
        static void Main(string[] args)
        {
        	Console.WriteLine("Please enter an integer value to sum up to:");
        	uint input = Convert.ToUInt32(Console.ReadLine());
        	Console.WriteLine("The sum of all numbers up to and including {0} is {1}",input, SumUpTo(input));
	    }

        private static uint SumUpTo(uint value)
        {
        	uint answer = 0;
        	uint x;

        	for (x = 0; x <= value; x++)
        	{
        		answer = answer + x;
        	}
        	return answer;
        }
    }
}
