using System;
namespace Question1
{
	class MessageAccount : Account
	{
		private const int DEFAULT_USAGE = 1;
		private const double DEFAULT_COST = 0.5;

        private int _UsedUnit;
		private int _AvaliableUnits;
		private double _UsagePerUnit;

        public MessageAccount(StatementLine line, int usage, double credit) :base(line, credit)
		{
            _AvaliableUnits = usage;
            _UsedUnit = 0;
            _UsagePerUnit = DEFAULT_COST;
            
		}
        public int UsedUnit { get { return _UsedUnit;}}
        public int AvaliableUnits { get { return _AvaliableUnits;}}
        public double UsagePerUnit { get { return _UsagePerUnit;}}
        
        public override void AdjustAccount(AccountType usage)
        {
            if (usage is MessageAccountUsage){
                MessageAccountUsage callUsage = usage as MessageAccountUsage;
                
                if (_AvaliableUnits - _UsedUnit >= callUsage.Usage) {
                    _UsedUnit = _UsedUnit + callUsage.Usage;
                    _UsedCredit = _UsedCredit + _UsedUnit * _UsagePerUnit;
                }
            }   
        }
        public override bool Record(string description, AccountType usage, out ServiceItem item)
        {
            bool status = true;
            int numberOfRecordUsage = DEFAULT_USAGE;
            item = null;
            if (usage is MessageAccountUsage)
            {
                MessageAccountUsage messageUsage = usage as MessageAccountUsage;
                 
                  
                    _UsedUnit = _UsedUnit + numberOfRecordUsage;
                    _UsedCredit = _UsedCredit + (numberOfRecordUsage * _UsagePerUnit);
                    
                if (_AvaliableUnits - _UsedUnit >= messageUsage.Usage)
                {
                    _UsedUnit = _UsedUnit + messageUsage.Usage;
                    _UsedCredit = _UsedCredit + _UsedUnit * _UsagePerUnit;
                    //item = null;
                }
                else if (numberOfRecordUsage > _AvaliableUnits - _UsedUnit)
                {
                    numberOfRecordUsage = _AvaliableUnits - _UsedUnit;
                   // item = null;
                }
                else if (numberOfRecordUsage <= 0)
                {
                   status = false;
                    item = null;
                }
               
            }
            item = new ServiceItem(numberOfRecordUsage, description, _UsagePerUnit);

            
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
#warning fix spacing;
             if (_UsedUnit > 0){
            return string.Format(" {0}\n UsedUnit: {1} @ ${2:N2}, Used: {3}, CurrentUnit: {4}", AvaliableUnits, _UsedUnit, _UsagePerUnit, (_UsagePerUnit*_UsedUnit), (_AvaliableUnits - _UsedUnit));
            } else {
                return string.Format("AvaliableUnits={0}", _AvaliableUnits);
            }
        }
	}
}
