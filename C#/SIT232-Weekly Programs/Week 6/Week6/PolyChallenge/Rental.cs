using System;
namespace PolyChallenge
{
    public class Rental
    {
        private decimal _Cost;
        private int _Days;
        private decimal _Distance;
        
        public Rental()
        {
            
        }
        public decimal Cost
        {
            set { _Cost = value;}
            get { return _Cost;}
        }
        
        public decimal Distance
        {
            set { _Distance = value;}
            get { return _Distance;}
        }
        
        public int Days
        {
            set { _Days = value;}
            get { return _Days;}
        }
        
    }
}
