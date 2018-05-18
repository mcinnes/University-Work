
using System.Collections.Generic;


namespace Project2
{
    static class LibraryDB
    {
        // attributes
        private static List<User> _Users = new List<User>();
        private static List<Customer> _CustomerList = new List<Customer>();
        private static List<Plan> _Plans = new List<Plan>();
        // propeties
        public static List<Customer> CustomerList
        {
            get { return _CustomerList;  }
        }        

        public static List<User> Users
        {
            get { return _Users; }
        }


        public static List<Plan> Plans
        {
            get { return _Plans; }
        }
    }
}
