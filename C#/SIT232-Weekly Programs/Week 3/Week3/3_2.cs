/*
Matt McInnes
mpcminne
214119048
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_2
{
    class Program
    {
        static void Main(string[] args)
        {
        	List<float> valueList = new List<float>();

        	string input;

			while (true)
			{
				Console.WriteLine("Please enter a numeric value or END to finish: ");
				input = Console.ReadLine();

				if (input == "END")
				{
					break;
				}

				valueList.Add(float.Parse(input));
			}

			CalculateStdDeviation(valueList);
        }

        public static void CalculateStdDeviation(List<float> list)
        {
			float sumTotal = list.Sum();

			float mean = sumTotal / list.Count;

			List<float> squareList = new List<float>();


			foreach (float a in list)
			{
				float tempValue;
				tempValue = (float)Math.Pow((a - mean), 2);
				squareList.Add(tempValue);
				//divide by mean and square
				//Math.Sqrt()
			}

			sumTotal = squareList.Sum();
			mean = sumTotal / squareList.Count;

			float standardDeviation = (float)Math.Sqrt(mean);

			Console.WriteLine("The standard deviation of the entered numbers is {0}", standardDeviation);

        }
    }
}
