using System;
using System.Collections.Generic;


namespace Project2
{
    class Staff : User, IMenuSet
    {
        public Staff(string name, string userName, string password) : base(name, userName, password)
        { }
        public Staff(Staff u) : base(u)
        { }
        // property
        public List<MenuOption> MenuOptions
        {
            get
            {
                List<MenuOption> m = new List<MenuOption>();
                m.Add(new MenuOption("List Customer", ListCustomerUsers));
                m.Add(new MenuOption("Create Customer", CreateCustomerUser));
                m.Add(new MenuOption("Change Customer Name", ChangeCustomerName));
                m.Add(new MenuOption("Reset Customer Password", ChangeCustomerPassword));
                m.Add(new MenuOption("Change Customer Plan", ChangeCustomerPlan));
                m.Add(new MenuOption("Compare Customer Plan to Other Plans", ComparePlans));
                m.Add(new MenuOption("Record Customer Payment", CustomerPayment));
                m.Add(new MenuOption("Delete Customer A User", DeleteCustomerUser));
                return m;
            }
        }
        // Menu Handler methods
        public void ComparePlans()
        {
            Customer u = Utility.GetSelection(LibraryDB.CustomerList.ToArray());
            decimal total = u.TotalUsage;         
            foreach (Plan p in LibraryDB.Plans)
                Console.WriteLine("{0,-10} - Cost: {1,8:c} The allowance - Usage {2,8:c}" , p.Name, p.Amount, p.CallValue - total);
        }

        public void ChangeCustomerPlan()
        {
            Customer u = Utility.GetSelection(LibraryDB.CustomerList.ToArray());
            Plan p = Utility.GetSelection(LibraryDB.Plans.ToArray());
            Console.WriteLine("Current Plan\n{0}", p);
            string confirm = Utility.GetUserName("\nRoll Over to this Plan (y/n)? ");
            if (confirm.ToLower() == "y") u.CustomerPlan = p;
            else Console.WriteLine("Unchange Plan");
            Console.WriteLine("New Plan {0}", p);
        }

        public void CustomerPayment()
        {
            Customer u = Utility.GetSelection(LibraryDB.CustomerList.ToArray());
            Console.WriteLine("Owing Amount: {0:c}", u.TotalUsage);
            //decimal amt;
            //do Console.Write("Enter Payment Amount: ");
            // while (decimal.TryParse(Console.ReadLine(), out amt) == false || amt < 0 || amt > u.TotalUsage);
            string confirm = Utility.GetUserName("Confirm User Payment to Roll Over Old data (y/n)? ");
            if (confirm.ToLower() == "y") u.RecordPayment(u.TotalUsage);
            // copy u.CustomerUsage to OldTransactions and clear CustomerUsage for new month           
        }
        private void ListCustomerUsers()
        {
            foreach (Customer u in LibraryDB.CustomerList)
                if (u is Customer) Console.WriteLine("\t- {0}", u);
        }

        private void CreateCustomerUser()
        {
            string name = Utility.GetUserName("Enter Customer Full Name: ");
            List<User> temp = Utility.ExistingName(name);
            if (temp.Count != 0)
            {
                foreach (User u in temp) Console.WriteLine(u);
                string confirm = Utility.GetUserName("Add another Customer (y/n)? ");
                if (confirm.ToLower() != "y") return;
            }
            string usr = Utility.GetUserName("Enter User Name: ");
            while (Utility.ExistingUser(usr) != null)
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

            // create exception class 
            for (int i = 0; i < LibraryDB.Plans.Count; i++)
                Console.WriteLine("{0}. {1}", i + 1, LibraryDB.Plans[i]);
            int choice;
            do Console.Write("Enter your Plan (1..{0}): ", LibraryDB.Plans.Count);
            while (int.TryParse(Console.ReadLine(), out choice) == false || choice < 1 || choice > LibraryDB.Plans.Count);
            LibraryDB.CustomerList.Add(new Customer(name, usr, first, LibraryDB.Plans[choice-1]));
            LibraryDB.Users.Add(LibraryDB.CustomerList[LibraryDB.CustomerList.Count-1]);
        }

        public static void ChangeCustomerName()
        {
            Customer u = Utility.GetSelection(LibraryDB.CustomerList.ToArray());
            string name = Utility.GetUserName("Enter new Customer Name: ");
            u.Name = name;
        }

        public static void DeleteCustomerUser()
        {
            Customer u = Utility.GetSelection(LibraryDB.CustomerList.ToArray());
            decimal total = u.TotalUsage;
            // use exception class
            if (total != 0) Console.WriteLine("Can't delete the customer - Must pay the balace first");
            else
            {
                string confirm = Utility.GetUserName("Permanet delete this record (y/n): ");
                if (confirm.ToLower() == "y")
                {
                    LibraryDB.CustomerList.Remove(u);
                    LibraryDB.Users.Remove(u);
                }
            }
        }

        public static void ChangeCustomerPassword()
        {
            Customer u = Utility.GetSelection(LibraryDB.CustomerList.ToArray());
            string first;
            do
            {
                Console.Write("Password: ");
                first = Utility.GetPassword();
                Console.Write("Re-Enter new Password: ");
                string second = Utility.GetPassword();
                if (first != second) first = "";
            } while (first == "");
            u.Password = first;
           
        }

        // Convert object to string object Type for display predefined attributes format

        public override string ToString()
        {
            return string.Format("Staff {0}", base.ToString());
        }
    }
}