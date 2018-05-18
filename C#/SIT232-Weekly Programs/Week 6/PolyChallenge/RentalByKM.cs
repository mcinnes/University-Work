using System;
namespace PolyChallenge
{
    public class RentalByKM : Rental
    {
        
        public RentalByKM(Person person, decimal distance)
        {
            //Base cost of $100 per day
            this.Cost = 30 + (distance * 0.5m) * 1.1m;
            this.Distance = distance;
            
            
            if (person == null)
            {
             Console.WriteLine("Rental for {0} days - ${1}", this.Distance, this.Cost);
            } else {    
             person.AddRental(this);
            }
            
        }
    }
}
