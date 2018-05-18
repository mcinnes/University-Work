using System;
using System.Collections.Generic;
namespace PolyChallenge
{
    public class Person
    {
        private string _Surname;
        private string _Firstname;
        private int _RentalCount;
        private List<Rental> rentalList;
        
        public Person(string surname, string firstname)
        {
            rentalList = new List<Rental>();
            _Surname = surname;
            _Firstname = firstname;
        }
        
        public bool AddRental(Rental rental)
        {
            if (_RentalCount <= 4) {
                _RentalCount++;
                rentalList.Add(rental);  
                return true;
            } else {
                return false;
            }
        }
        
        public void PrintRentals()
        {
            Console.WriteLine("{0}, {1}", _Surname, _Firstname);
            foreach (Rental rental in rentalList){

                if (rental is RentalByDay)
                {
                    Console.WriteLine("\tRental for {0} days - ${1}", rental.Days, rental.Cost);
                }
                if (rental is RentalByKM)
                {
                    Console.WriteLine("\tRental for {0}km - ${1}", rental.Distance, rental.Cost);
                }
            }
        }
        
    }
}
