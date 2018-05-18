
namespace Project2
{
    class CallUsage : Usage
    {
        // attribute
        private const decimal _DefCost = 1m;
        //Constructors
        public CallUsage() : base(Utility.GetUnit(), _DefCost) { }
        public CallUsage(string time, string contact) : base(time, contact, Utility.GetUnit(), _DefCost) { }
        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            int unit = UnitCharge;
            int min = unit > 1? UnitCharge - 1 : 0;
            int sec = Utility.GetRandomNumber(1, 60);
            return string.Format("{0,10} {1,-20} {2,3:d2}:{3,2:d2}  sec {4,8:c} Call Usage", UsageTime, ContactNo, min, sec, Cost);
        }
    }
}
