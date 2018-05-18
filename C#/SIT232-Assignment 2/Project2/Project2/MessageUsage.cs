
namespace Project2
{
    class MessageUsage : Usage
    {
        // attribute
        private const int _DefUnit = 1;
        private const decimal _DefCost = 0.5m;
        //Constructors
        public MessageUsage() : base(_DefUnit, _DefCost) { }
        public MessageUsage(string time, string contact) : base(time, contact, _DefUnit, _DefCost) { }
        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            return string.Format("{0,10} {1,-20} {2,6} Unit {3,8:c} Message Usage", UsageTime, ContactNo, UnitCharge, Cost);
        }
    }
}
