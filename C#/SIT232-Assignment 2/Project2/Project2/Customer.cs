using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Project2
{
    class Customer : User, IMenuSet
    {
        private Plan _CustomerPlan;
        private List<Usage> _CustomerUsage;
        private string _ID;
        private decimal _TotalUsage;

        // Property
        public List<MenuOption> MenuOptions
        {
            get
            {
                List<MenuOption> m = new List<MenuOption>();
                m.Add(new MenuOption("List All Usage Transactions", ListUage));
                m.Add(new MenuOption("New Data Usage Transaction", RecordDataUsage));
                m.Add(new MenuOption("New Message Transaction", RecordNewMessage));
                m.Add(new MenuOption("New Call Transaction", RecordNewCall));
                return m;
            }
        }
        public string ID {  get { return _ID; }  }

        public Plan CustomerPlan
        {
            get { return _CustomerPlan; }
            set { _CustomerPlan = value; }
        }

        public List<Usage> CustomerUsage
        {
            get { return _CustomerUsage; }
            set { _CustomerUsage = value; }
        }

        public decimal TotalUsage
        {  get { return _TotalUsage; }
           set { _TotalUsage = value; }
        }

 
        // constructors
        public Customer(string name, string userName, string password, Plan plan) : base(name, userName, password)
        {
            do
            {
                _ID = Utility.GetContact();
                if(LibraryDB.CustomerList.Count > 1)
                  for(int i = 0; i < LibraryDB.CustomerList.Count -1; i++)
                    if (_ID  == LibraryDB.CustomerList[i].ID) _ID = "";
            } while (_ID == "");
            _CustomerPlan = plan;
            _CustomerUsage = new List<Usage>();
            _TotalUsage = 0;
        }

        public Customer(Customer u): base(u)
        {
            _ID = u.ID;
            _CustomerPlan = u.CustomerPlan;
            _CustomerUsage = new List<Usage>(u.CustomerUsage);
            _TotalUsage = u.TotalUsage;
        }
        // destructor
        ~Customer()
        {
            _CustomerUsage.Clear();
            _CustomerPlan = null;
            _CustomerUsage = null;
        }

        // Service method for StaffUser Class Menu Option
        public void RecordPayment(decimal amt)
        {
            if (amt > 0)
                _TotalUsage -= amt;
        }

        // Menu Handler methods
        public void ListUage()
        {
            Console.WriteLine("Recorded Usage Statement Line");
            foreach (Usage u in CustomerUsage) Console.WriteLine(u);

            Console.WriteLine("\nThe total Usage cost: {0:c}", _TotalUsage);
        }

        public void RecordDataUsage()
        {
            Usage temp = new Usage(Utility.GetUnit());
            if (_TotalUsage + temp.Cost < _CustomerPlan.CallValue)
            {
                _CustomerUsage.Add(temp);
                _TotalUsage += temp.Cost;
                _CustomerUsage.Sort();
            }
            else Console.WriteLine("*** Account need to be recharged before down load data ***\n");
        }

        public void RecordNewMessage()
        {
            Usage temp = new MessageUsage();

            if (_TotalUsage + temp.Cost < _CustomerPlan.CallValue) 
            {
                _CustomerUsage.Add(temp);
                _TotalUsage += temp.Cost;
                _CustomerUsage.Sort();        
            }
            else Console.WriteLine("*** Account need to be recharged before send the new Message ***\n");
        }

        public void RecordNewCall()
        {
            Usage temp = new CallUsage();
            if (_TotalUsage + temp.Cost < _CustomerPlan.CallValue)
            {
                _CustomerUsage.Add(temp);
                _TotalUsage += temp.Cost;
                _CustomerUsage.Sort();
            }
            else Console.WriteLine("*** Account need to be recharged before send the new Call ***\n");
        }
        // Convert object to string object Type for display predefined attributes format

        public override string ToString()
        {
            return string.Format("Customer Account ID {0} - {1} Total Owing {2:c}", _ID, base.ToString(), _TotalUsage);
        }
    }
}
