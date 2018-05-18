using System;
namespace Question1
{
	 class CallAccount : Account
	{
        private const int DEFAULT_USAGE = 1;
        private const double DEFAULT_COST = 1.0;
        
        private double _UsedUnit;
        private double _AvaliableUnits;
        private double _UsagePerUnit;
        
		public CallAccount(StatementLine line, double usage, double credit) : base(line, credit)
		{
            _AvaliableUnits = usage;
            _UsedUnit = 0;
            _UsagePerUnit = DEFAULT_COST;
            
		}
        
        CallAccount(double number)
        {
        
        }
        public double UsedUnit { get { return _UsedUnit;}}
        public double AvaliableUnits { get { return _AvaliableUnits;}}
        public double UsagePerUnit { get { return _UsagePerUnit;}}
        
        public override void AdjustAccount(AccountType usage)
        {
            if (usage is CallAccountUsage){
                CallAccountUsage callUsage = usage as CallAccountUsage;
                
                if (_AvaliableUnits - _UsedUnit >= callUsage.Usage) {
                    _UsedUnit = callUsage.Usage;
                    _UsedCredit = _UsedCredit + (_UsedUnit * _UsagePerUnit);
                }
            }          
        }
        
         public override bool Record(string description, AccountType usage, out ServiceItem item)
        {
            bool status = true;
            double numberOfRecordUsage = DEFAULT_USAGE;
            item = null;

            
            if (usage is CallAccountUsage)
            {
            
                CallAccountUsage callUsage = usage as CallAccountUsage;
                Console.WriteLine(callUsage.Usage);
                
                numberOfRecordUsage = Math.Ceiling(callUsage.Usage);
                 Console.Write("Num of record usage" + numberOfRecordUsage);
                _UsedUnit = _UsedUnit + numberOfRecordUsage;
               // _UsedCredit = _UsedCredit + (numberOfRecordUsage * _UsagePerUnit);
                item = new ServiceItem(numberOfRecordUsage, description, _UsagePerUnit);

                if (_AvaliableUnits - _UsedUnit >= callUsage.Usage)
                {
                    Console.Write(" 1 ");
                    _UsedUnit = _UsedUnit + callUsage.Usage;
                    //_UsedCredit = _UsedCredit + _UsedUnit * _UsagePerUnit;
                    item = null;
                }
                if (numberOfRecordUsage > _AvaliableUnits - _UsedUnit)
                {
                                    Console.Write(" 2 ");
                    numberOfRecordUsage = _AvaliableUnits - _UsedUnit;
                    item = null;
                }
                if (numberOfRecordUsage <= 0)
                {
                                    Console.Write(" 3\n");
                   status = false;
                    item = null;
                }
               
            }

            return status;
            
        }
        
        public override void RollOver()
        {
            _AvaliableUnits = _AvaliableUnits - _UsedUnit;
            _Credit = _Credit - (_UsedUnit * _UsagePerUnit);
            _UsedUnit = 0;
            _UsedCredit = 0;
        }
        
        public override string ToString()
        {
            //Fix spacing
            Console.WriteLine("Used" + _UsedUnit);
            Console.WriteLine("Av" + _AvaliableUnits);
#warning fix spacing;
            if (_UsedUnit > 0){
            return string.Format("{0}\n, UsedUnit={1} UsagePerUnit={2}, Used={3}, CurrentUnit={4}", AvaliableUnits, _UsedUnit, UsagePerUnit, (_UsagePerUnit*_UsedUnit), (_AvaliableUnits - _UsedUnit));
            } else {
                return string.Format("AvaliableUnits={0}", _AvaliableUnits);
            }
                
        }
	}
}
