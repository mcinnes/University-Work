using System;
using System.Linq;
namespace _3_3
{
    class Program
    {
        static void Main(string[] args)
        {
			string idString;
			string yearString;
			string monthString;
			string dayString;

			//ID
			Console.WriteLine("Please enter your student ID:");
			while (true)
			{ 
				idString = Console.ReadLine();
				if (StudentIDCheck(idString))
				{
					break;
				}
				else
				{
					Console.WriteLine("Please enter your student ID:");
				}
			}

			//Year
			Console.WriteLine("Please enter the year you were born:");
			while (true)
			{
				yearString = Console.ReadLine();
				if (YearCheck(yearString))
				{
					
					break;
				}
				else
				{
					Console.WriteLine("Please enter the year you were born:");
				}
			}

			//Month
			Console.WriteLine("Please enter the month you were born:");
			while (true)
			{
				monthString = Console.ReadLine();
				if (MonthCheck(monthString))
				{
					break;
				}
				else
				{
					Console.WriteLine("Please enter the month you were born:");
				}
			}

			//Day
			Console.WriteLine("Please enter the day you were born:");
			while (true)
			{
				dayString = Console.ReadLine();
				if (DayCheck(dayString, monthString))
				{
					break;
				}
				else
				{
					Console.WriteLine("Please enter the day you were born:");
				}
			}

			//Print
			Console.WriteLine();
			Console.WriteLine("Validated Data:");
			Console.WriteLine("Student ID: {0}", idString);
			Console.WriteLine("Date of birth: {0}/{1}/{2}", dayString, monthString, yearString);
        }


		public static bool StudentIDCheck(string idString)
		{
			//Length check
			if (idString.Length < 8 || idString.Length > 9) return false;

			//Numeric check
			if (!NumberCheck(idString)) return false;

			return true;
		}

		public static bool YearCheck(string yearString)
		{
			if (!NumberCheck(yearString)) return false;

			if (yearString.Length != 4) return false;

			if ((DateTime.Now.Year - Convert.ToInt32(yearString)) < 17 || (DateTime.Now.Year - Convert.ToInt32(yearString)) > 100) return false;

			return true;
		}

		public static bool MonthCheck(string monthString)
		{
			if (!NumberCheck(monthString)) return false;

			if (Convert.ToInt32(monthString) < 1 || Convert.ToInt32(monthString) > 12) return false;

			return true;
		}

		public static bool DayCheck(string dayString, string monthString)
		{
			if (!NumberCheck(dayString)) return false;

			int monthInt = Convert.ToInt32(monthString);
			int dayInt = Convert.ToInt32(dayString);

			//30 Day Months
			if (new int[] { 4, 9, 11, 6 }.Contains(monthInt))
			{
				if(dayInt < 1 || dayInt > 30) return false;
			}
			//Feb
			if (monthInt == 2)
			{
				if (dayInt < 1 || dayInt > 29) return false;
			}
			//Other Months
			if (dayInt < 1 || dayInt > 31) return false;
			

			return true;
		}

		public static bool NumberCheck(string str)
		{
			foreach (char c in str)
			{
				if (c < '0' || c > '9')
				{
					return false;
				}
			}

			return true;
		}
    }
}
