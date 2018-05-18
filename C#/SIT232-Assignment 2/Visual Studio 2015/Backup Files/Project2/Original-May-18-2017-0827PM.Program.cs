using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        public static void LoadData()
        {
           
           
            //Add all customer to user list - for login & search or delete
           

            // Load Test data by auto generate 20 usage records for a month for customer 1 (Alice) and customer 2 (Thomas)
           

        }

        public static void Main()
        {
            LoadData(); // load testing data

            LoadUsers();
            LoadPlans();
            LoadCustomers();

            string stop = Console.ReadLine();
            // define a list of IMenuSet to provide and handle with different user's menu options
            List<IMenuSet> MenuUser = new List<IMenuSet>();
            IMenuSet currentUser;
            do
            {
                foreach (IMenuSet u in LibraryDB.Users) MenuUser.Add(u);

                Console.Clear();
                currentUser = User.GetLogin() as IMenuSet;

                if (currentUser != null)
                {
                    Console.WriteLine("\nWelcome {0}\n", (currentUser as User).Name);
                    List<MenuOption> options = currentUser.MenuOptions;

                    int choice = 1;
                    while (choice != 0)
                    {
                        for (int i = 0; i < options.Count; i++)
                            Console.WriteLine("{0}. {1}", i + 1, options[i].Description);
                        Console.WriteLine("+++++++++++++++++++++");
                        Console.WriteLine("0. Exit");
                        do
                        {
                            Console.Write("Enter your choice (0..{0}) ? ", options.Count);
                        } while (int.TryParse(Console.ReadLine(), out choice) == false || choice < 0 || choice > currentUser.MenuOptions.Count);
                        if (choice == 0) break;
                        else if (choice <= options.Count) currentUser.MenuOptions[choice - 1].Handler();
                    }
                }
            } while (currentUser != null);
            Console.ReadLine();
        }

        static void LoadPlans()
        {
            //Create Default Plan
            LibraryDB.Plans.Add(new Plan());
            //Load other plans from file
            string[] plans = System.IO.File.ReadAllLines(@"C:\Users\Matt\Documents\Plans.txt");
            foreach (string line in plans)
            {
                var values = line.Split(',');
                LibraryDB.Plans.Add(new Plan(values[0], Decimal.Parse(values[1]), Decimal.Parse(values[2]), Double.Parse(values[3])));
            }
        }
        static void LoadUsers()
        {
            //Users
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\Matt\Documents\WriteText.txt");
            foreach (string line in users)
            {
                var values = line.Split(',');
                if (values[0] == "Admin")
                {
                    LibraryDB.Users.Add(new Admin(values[1], values[2], values[3]));
                }
                else
                {
                    LibraryDB.Users.Add(new Staff(values[1], values[2], values[3]));
                }
            }
            foreach (User u in LibraryDB.Users) Console.WriteLine(u);
        }
        static void LoadCustomers()
        {
            //Customers
            string[] customers = System.IO.File.ReadAllLines(@"C:\Users\Matt\Documents\Customers.txt");
            foreach (string line in customers)
            {
                var values = line.Split(',');
                //D is the default plan
                if (values[3] == "D")
                {
                    LibraryDB.CustomerList.Add(new Customer(values[0], values[1], values[2], new Plan()));
                }
                else
                {
                    int PlanIndex = Int32.Parse(values[3]);
                    LibraryDB.CustomerList.Add(new Customer(values[0], values[1], values[2], new Plan(LibraryDB.Plans.ElementAt(PlanIndex))));
                }

            }
            //List users
            foreach (Customer u in LibraryDB.CustomerList) Console.WriteLine(u);
            //Add user logins to database
            foreach (Customer u in LibraryDB.CustomerList) LibraryDB.Users.Add(u);

            //Lets make some test data
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    LibraryDB.CustomerList[0].RecordNewMessage();
                    LibraryDB.CustomerList[1].RecordNewMessage();
                }
                else if (i % 3 == 0)
                {
                    LibraryDB.CustomerList[0].RecordNewCall();
                    LibraryDB.CustomerList[1].RecordNewCall();
                }
                else
                {
                    LibraryDB.CustomerList[0].RecordDataUsage();
                    LibraryDB.CustomerList[1].RecordDataUsage();
                }
            }

            //Display test data for each customer
            foreach (Customer u in LibraryDB.CustomerList)
            {
                Console.WriteLine(u);
                foreach (Usage usage in u.CustomerUsage) Console.WriteLine(usage);
            }
        }
    }
}
