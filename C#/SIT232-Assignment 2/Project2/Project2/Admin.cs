using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project2
{
    class Admin : User, IMenuSet
    {
        // Constructors
        public Admin(string name, string userName, string password) : base (name, userName, password)
        {  }

        public Admin(Admin u) : base(u) { }

        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            return string.Format("Admin {0}", base.ToString());
        }
        #region Menu
        public List<MenuOption> MenuOptions
        {
            get
            {
                List<MenuOption> m = new List<MenuOption>();
                m.Add(new MenuOption("List Staff", ListStaffUsers));
                m.Add(new MenuOption("Create Staff", CreateStaffUser));
                m.Add(new MenuOption("Change Staff Name", ChangeStaffName));
                m.Add(new MenuOption("Reset Staff Password", ChangeStaffPassword));
                m.Add(new MenuOption("Delete Staff A User", DeleteStaffUser));
                return m;
            }
        }

        private void ListStaffUsers()
        {
            foreach (User u in LibraryDB.Users)
                if (u is Staff) Console.WriteLine("\t- {0}", u);
            // create exception class
        }

        private void CreateStaffUser()
        {
            //User temp = Utility.CreateUser();
            string name = Utility.GetUserName("Enter Staff Full Name: ");
            List<User> temp = Utility.ExistingName(name);
            if (temp.Count != 0)
            {
                foreach (User u in temp) Console.WriteLine(u);
                string confirm = Utility.GetUserName("Add another Staff (y/n)? ");
                if (confirm.ToLower() != "y") return;
            }
            string usr = Utility.GetUserName("Enter User Name: ");
            while(Utility.ExistingUser(usr) != null)
            {
                Console.WriteLine("User Name already taken - Try again"); // error
                usr = Utility.GetUserName("Enter User Name: ");
            }
            string first;
            do
            {
                Console.Write("Password: ");
                first = Utility.GetPassword();
                Console.Write("Re-Enter new Password: ");
                string second = Utility.GetPassword();
                if (first != second) first = "";
            } while (first == "");
           
            LibraryDB.Users.Add(new Staff(name, usr, first));
            // create exception class       
        }

        public static void ChangeStaffName()
        {
            string name = Utility.GetUserName("Enter User Name: ");
            User temp = Utility.ExistingUser(name);
            if(temp != null)
                temp.Name = Utility.GetUserName("Enter Staff Full Name: ");
            Console.WriteLine("{0} is not on Staff List", name);
            // create exception class
        }

        public static void DeleteStaffUser()
        {
            string name = Utility.GetUserName("Enter User Name: ");
            User temp = Utility.ExistingUser(name);
            if (temp != null)
            {
                Console.WriteLine(temp);
                string confirm = Utility.GetUserName("Confirm to delete this staff (y/n): ");
                if (confirm.ToLower() == "y") LibraryDB.Users.Remove(temp);
            }
            Console.WriteLine("User Name {0} is not on Staff List", name);
            // create exception class
        }

        public static void ChangeStaffPassword()
        {
            string name = Utility.GetUserName("Enter User Name: ");
            User temp = Utility.ExistingUser(name);
            if (temp != null)
            {
                Console.WriteLine(temp);
                string first;
                do
                {
                    Console.Write("Password: ");
                    first = Utility.GetPassword();
                    Console.Write("Re-Enter new Password: ");
                    string second = Utility.GetPassword();
                    if (first != second) first = "";
                } while (first == "");
                temp.Password = first;
            }
            Console.WriteLine("User Name {0} is not on Staff List", name);
            // create exception class
        }

        #endregion
    }
}
