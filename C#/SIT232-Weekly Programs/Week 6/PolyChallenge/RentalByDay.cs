using System;
namespace PolyChallenge
{
    public class RentalByDay : Rental
    {
        
        public RentalByDay(Person person, int days)
        {
            //Base cost of $100 per day
            this.Cost = days * 100;
            this.Days = days;
            

            if (person == null)
            {
             Console.WriteLine("Rental for {0} days - ${1}", Days, Cost);
            } else {
                person.AddRental(this);
            }
            
        }
    }
}
