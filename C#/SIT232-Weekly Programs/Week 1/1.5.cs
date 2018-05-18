/*************************************************************
** File: ThreeNumbers.cs
** Author/s: Justin Rough
** Description:
**     A simple program that calculates the sum of three
**     numbers and what percentage/factor of the sum the 
**     three numbers contribute.  This program is provided
**     with many syntax errors as an exercise in correcting
**     such errors.
*************************************************************/
using System;

public class ThreeNumbers
{
	public static void Main()
	{
		string input;
		float factor;

		Console.Write("Enter the first number: ");
		input = Console.ReadLine();
		int num1 = Convert.ToInt32(input);
		
		Console.Write("Enter the second number: ");
        input = Console.ReadLine();
		int num2 = Convert.ToInt32(input);
		
		Console.Write("Enter the third number: ");
		input = Console.ReadLine();
		int num3 = Convert.ToInt32(input);
		
		Console.WriteLine();
		
		int sum = num1 + num2 + num3;
		Console.WriteLine("The sum of the numbers is {0}", sum);
		
		Console.WriteLine();
		
		factor = (Convert.ToSingle(num1) / sum) * 100;
		Console.WriteLine("The number {0} represents {1}% of the sum", num1, factor);
		factor = (Convert.ToSingle(num2) / sum) * 100f;
		Console.WriteLine("The number {0} represents {1}% of the sum", num2, factor);
		factor = (Convert.ToSingle(num3) / sum) * 100f;
		Console.WriteLine("The number {0} represents {1}% of the sum", num3, factor);
	}
}