using System;

namespace StudentValidator
{
    class StudentValidator
    {
        private static bool ValidStudentID(string input)
        {
            bool result = true;

			// Write code here to validate the student ID (input).

            return result;
        }

        private static bool ValidBirthYear(string input)
        {
            bool result = true;
            
			// Write code here to validate the birth year (input).

            return result;
        }

        private static bool ValidBirthMonth(string input)
        {
            bool result = true;

			// Write code here to validate the birth month (input).

            return result;
        }

        private static bool ValidBirthDay(string input, string month)
        {
            bool result = true;

			// Write code here to validate the birth day (input).  You will require the month to do this (month).
			
            return result;

        }

        static void Main(string[] args)
        {
            string studentID;
            Console.Write("Please enter the student ID: ");
            studentID = Console.ReadLine();
            while (ValidStudentID(studentID) == false)
            {
                Console.WriteLine("You have entered an invalid student ID, please try again.");
                Console.Write("Please enter the student ID: ");
                studentID = Console.ReadLine();
            }

            string birthYear;
            Console.Write("Please enter the birth year: ");
            birthYear = Console.ReadLine();
            while(ValidBirthYear(birthYear) == false)
            {
                Console.WriteLine("You have entered an invalid birth year, please try again.");
                Console.Write("Please enter the birth year: ");
                birthYear = Console.ReadLine();
            }

            string birthMonth;
            Console.Write("Please enter the birth month: ");
            birthMonth = Console.ReadLine();
            while(ValidBirthMonth(birthMonth) == false)
            {
                Console.WriteLine("You have entered an invalid birth month, please try again.");
                Console.Write("Please enter the birth month: ");
                birthMonth = Console.ReadLine();
            }

            string birthDay;
            Console.Write("Please enter the birth day: ");
            birthDay = Console.ReadLine();
            while(ValidBirthDay(birthDay, birthMonth) == false)
            {
                Console.WriteLine("You have entered an invalid birth month, please try again.");
                Console.Write("Please enter the birth day: ");
                birthDay = Console.ReadLine();
            }

            Console.WriteLine("Validated data:");
            Console.WriteLine("\tStudent ID: {0}", studentID);
            Console.WriteLine("\tBirth date: {0}/{1}/{2}", birthDay, birthMonth, birthYear);
        }
    }
}