using System;


namespace Project2
{
    class Usage : IComparable
    {
        // attributes
        private const decimal _Def = 3.0m;
        private string _UsageTime;
        private string _ContactNo;
        private int _UnitCharge;
        private decimal _Cost;
        // properties
        public string UsageTime { get { return _UsageTime; } }
        public string ContactNo { get { return _ContactNo; } }
        public int UnitCharge { get { return _UnitCharge; } }
        public decimal Cost { get { return _Cost; } }
        // constructors
        public Usage()
        {
            _UsageTime = Utility.GetDate();
            _ContactNo = Utility.GetContact();
            _UnitCharge = 1;
            _Cost = _UnitCharge * _Def;
        }

        public Usage(int unit)
        {
            _UsageTime = Utility.GetDate();
            _ContactNo = Utility.GetContact();
            _UnitCharge = unit;
            _Cost = _UnitCharge * _Def;
        }

        public Usage(int unit, decimal cost)
        {
            _UsageTime = Utility.GetDate();
            _ContactNo = Utility.GetContact();
            _UnitCharge = unit;
            _Cost = _UnitCharge * cost;
        }
        public Usage(string time, string contact, int unit, decimal cost)
        {
            _UsageTime = time;
            _ContactNo = contact;
            _UnitCharge = unit;
            _Cost = _UnitCharge * cost;
        }

        // Convert object to string object Type for display predefined attributes format
        public override string ToString()
        {
            string gb = string.Format("{0}.{1}", UnitCharge > 1 ? UnitCharge - 1 : 0, Utility.GetRandomNumber(1, 1000));
            return string.Format("{0,10} {1,-20} {2,6}  MB  {3,8:c} Data Usage", _UsageTime, _ContactNo, gb, _Cost);
        }

        //////////////////////////
        #region  IComparable to compare Members
        // specify how to compare a usage object with the class object
        public int CompareTo(object obj)
        {
            if (!(obj is Usage)) Console.WriteLine("Compared Object is not of Usage");
            // throw new ArgumentException("Compared Object is not of Usage");
            Usage u = obj as Usage;
            return UsageTime.CompareTo(u.UsageTime);
        }

        #endregion

        //////////////////////////////
    }

}
