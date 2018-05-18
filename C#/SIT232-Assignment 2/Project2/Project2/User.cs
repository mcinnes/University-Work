using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class User 
    {
        // attributes
        private string _Name;
        private string _UserName;
        private string _Password;
        private BasicMenu _Menus;
        //properties
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string UserName
        {
            get { return _UserName; }
        }


        public string Password
        {
            get { return _Password;  }
            set { _Password = Utility.HashPassword(value); }
        }

        public BasicMenu UserMenu {  get { return _Menus; } }
        public virtual List<MenuOption> Menus
        {
            get { return _Menus.MenuOptions; }
        }

        // Constructors
        public User(string name, string userName, string password) 
        {
            _UserName = userName;
            _Password = Utility.HashPassword(password);
            _Name = name;
            _Menus = new BasicMenu();
        }

        public User(User u)
        {
            _UserName = u.UserName;
            _Name = u.Name;
            Password = u.Password;
            _Menus = u.UserMenu;
        }
        //serives methods
        public static User GetLogin()
        {
            string Welcome = "Welcome to the Account Usage";
            Console.WriteLine(Welcome);
            Console.WriteLine(new string('=', Welcome.Length));

            Console.Write("Login (or 'exit'): ");
            string username = Console.ReadLine();
            string password;
            User result = null;
            while (result == null)
            {
                if (username == "exit")    return null;

                Console.Write("Password: ");
                password = Utility.GetPassword();

                foreach (User u in LibraryDB.Users)
                {
                    if (u.UserName == username && u.Validate(password))
                    {
                        result = u;
                        break;
                    }
                }

                if (result == null)
                {
                    Console.WriteLine("Invalid login.\n");
                    Console.Write("Login (or 'exit'): ");
                    username = Console.ReadLine();
                }
            }
            return result;
        }

        public bool Validate(string inputPassword)
        {   // check the pwd min 8 chars no space min one symbol, upper, lower, digits
            return _Password == Utility.HashPassword(inputPassword);
        }
        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            return string.Format("{0} ({1})", _Name, _UserName);
        }

    }
}
