/*
Matt McInnes
mpmcinne
214119048
*/

using System;
namespace SalaryTax
	{
		class SalaryTax
			{
				static void Main(string[] args)
					{
					float tax;


					Console.Write("How much money do you earn? ");

					int salary = Convert.ToInt32(Console.ReadLine());

					if (salary < 0) {
						Console.WriteLine("Please enter your correct salary");
					}

					if (salary >= 0 && salary >= 6000) {
						Console.WriteLine("No Tax");
					}

					if (salary >= 6001 && salary >= 37000) {
						tax = (salary - 6000) * 0.15;
						Console.WriteLine(Convert.ToString(tax));
					}

					if (salary >= 37001 && salary >= 80000) {
						tax = ((salary - 37000) * 0.30) + 4650;
						Console.WriteLine(Convert.ToString(tax));
					}

					if (salary >= 80001 && salary >= 180000) {
						tax = ((salary - 80000) * 0.37) + 17550;
						Console.WriteLine(Convert.ToString(tax));
					}

					if (salary >= 180001) {
						tax = ((salary - 180000) * 0.45) + 54550;
						Console.WriteLine(Convert.ToString(tax));
					}

					} 
			}
	}