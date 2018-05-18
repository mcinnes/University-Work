using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project2
{
    class Utility
    {
       
            // attributes
            private const string MENU_FORMAT_STRING = "\t{0,4}.   {1}";
            private static MD5CryptoServiceProvider _CryptoProvider = new MD5CryptoServiceProvider();
            //Function to get random number
            private static readonly Random r = new Random();
            private static readonly object syncLock = new object();

            public static int GetRandomNumber(int min, int max)
            {
                lock (syncLock)
                { // synchronize
                    return r.Next(min, max);
                }
            }

            public static string GetDate()
            {
                int day = GetRandomNumber(1, 31);
                return string.Format("{0:d2}-May-2017", day);
            }
            public static string GetContact()
            {
                int lDigit = GetRandomNumber(0, 100);
                int mid = GetRandomNumber(0, 1000);
                int last = GetRandomNumber(0, 1000);
                return string.Format("04{0:d2} {1:d3} {2:d3}", lDigit, mid, last);
            }
            public static int GetUnit()
            {
                return GetRandomNumber(0, 100);
            }

            ///////////////////////////////


            public static string GetUserName(string prompt)
            {
                string name = "";
                do
                {
                    Console.Write(prompt);
                    name = Console.ReadLine();
                }
                while (name == "" || name == " ");
                return name;
            }

            public static List<User> ExistingName(string name)
            {
                List<User> temp = new List<User>();
                foreach (User u in LibraryDB.Users)
                    if (u.Name.ToUpper().Contains(name.ToUpper())) temp.Add(u);
                return temp;
            }

            public static List<Customer> ExistingCustomerName(string name)
            {
                List<Customer> temp = new List<Customer>();
                foreach (Customer u in LibraryDB.CustomerList)
                    if (u.Name.ToUpper().Contains(name.ToUpper())) temp.Add(u);
                return temp;
            }

            public static User ExistingUser(string usr)
            {
                User user = null;
                foreach (User u in LibraryDB.Users)
                if (u.UserName.ToLower() == usr.ToLower()) user = u;
                return user;
            }

            public static User ExistingCustomerUser(string usr)
            {
                Customer user = null;
                foreach (Customer u in LibraryDB.CustomerList)
                    if (u.UserName.ToLower() == usr.ToLower()) user = u;
                return user;
            }
 
            public static string GetPassword()
            {
                ConsoleKeyInfo key;
                StringBuilder password = new StringBuilder();

                key = Console.ReadKey(true);
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        Console.Write("*");
                        password.Append(key.KeyChar);
                    }
                    else
                    {
                        Console.Write("\b \b");
                        password.Length--;
                    }
                    key = Console.ReadKey(true);
                }
                Console.WriteLine();

                return password.ToString();
            }

            public static string HashPassword(string password)
            {
                return BitConverter.ToString(_CryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
            
            public static bool ValidatePassword(string password)
            {
                string txt = "1Ijx@#zzzzz";

                string re1 = "(\\d+)";  // Number
                string re2 = "([a-z])"; // Any lowercase letter
                string re3 = "([A-Z])"; // Any uppercase letter
                string re4 = @"([^\s -])"; //No whitespace
                string re6 = "([!.@#$%^&*()])";
                string re5 = "A-Za-z0-9!.@#$%^&*()"; //combo pack

            return true;
            }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        #region _Menu

        public static T GetSelection<T>(T[] objectList)
        {
            int selection = 0;
            while (selection < 1 || selection > objectList.Length)
            {
                Console.WriteLine("Please select from the following list");
                for (int i = 0; i < objectList.Length; i++)
                    Console.WriteLine(MENU_FORMAT_STRING, i + 1, objectList[i]);
                Console.Write("Enter selection: ");
                if (int.TryParse(Console.ReadLine(), out selection) == false || selection <= 0 || selection > objectList.Length)
                    Console.WriteLine("Invalid selection, please try again.\n");
            }
            return objectList[selection - 1];
        }
        #endregion
    }
}
