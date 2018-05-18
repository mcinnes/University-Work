using System;

namespace PolyChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Person jane = new Person("Bloggs", "Jane");
            Person joe = new Person("Bloggs", "Joe");
            Person peter = new Person("Piper", "Peter");
            Person penny = new Person("Piper", "Penny");
            
            new RentalByDay(jane, 5); 
            new RentalByDay(jane, 2); 
            jane.PrintRentals();
            
            new RentalByDay(joe, 8); 
            new RentalByKM(joe, 15); 
            joe.PrintRentals();
            
            new RentalByDay(peter, 1); 
            new RentalByKM(peter, 85); 
            peter.PrintRentals();
            
            new RentalByDay(penny, 5); 
            new RentalByKM(penny, 42); 
            penny.PrintRentals();

            Console.Write("Quote for ");  new RentalByDay(null, 10);
            Console.Write("Quote for ");  new RentalByKM(null, 10);

        }
    }
}
