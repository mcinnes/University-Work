using System;
using System.Text.RegularExpressions;

namespace _10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            phone("04-2521-5401");
            money("150.00");
            address("16 Avonside Road");
            password("^&^ALAala123");
        }
        static void phone(string phoneNumber)
        {  
           string I2="(\\d{2})"; // Integer length 2
           string Neg="(-)"; // Minus
           string I4="(\\d{4})";  // Integer length 4
        
            Regex r = new Regex(I2 + Neg + I4 + Neg + I4, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(phoneNumber);
            if (m.Success)
            {
                Console.WriteLine("Phone Input is Valid");
            }
            else
            {
                Console.WriteLine("Phone Input is NOT Valid");
            }
        }
        static void money(string Money){
          string moneyReg = @"\(?[0-9]{1,}(?:,?[0-9]{3})*\.[0-9]{2}\)?";  // Dollar Amount 1
            Regex r = new Regex(moneyReg, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(Money);
            if (m.Success){
                Console.WriteLine("Money Input is Valid");
            } else {
                Console.WriteLine("Money Input is NOT Valid");
            }
        }
         static void address(string Address){
         
           string houseNum= @"(\d{1,})"; // Integer length at least 1 digit
           string space= @"( )"; // Minus
           string words= @"(\[a-z][A-Z])";  // Integer length 4
           string opti = @"(?:([a-z] )";
            Regex r = new Regex(houseNum + space + words + space + words, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(Address);
            if (m.Success){
                Console.WriteLine("Address Input is Valid");
            } else {
                Console.WriteLine("Address Input is NOT Valid");
            }
        }
        static void password(string Password)
        {
            string upperCase = @"(.*?[A-Z]){3,}";
            string lowerCase = @"(.*?[A-Z]){3,}";
            string numbers = @"(.*?[0-9]){3,}";
            string symbols = @"(.*?\!@#$%^&*()_-{3,})";
            Regex r = new Regex(upperCase + lowerCase + numbers + symbols, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(Password);
            if (m.Success){
                Console.WriteLine("Password Input is Valid");
            } else {
                Console.WriteLine("Password Input is NOT Valid");
            }
        }
    }
}
