using System;
namespace Question1
{
     public class Account
	{
        private string _ServiceID;
        private double _Credit;
        private double _UsedCredit;
        private StatementLine _Line;
        private const int DEFAULT_USAGE = 1;
        private const double DEFAULT_COST = 1.0;
        
        private double _UsedUnit;
        private double _AvaliableUnit;
        private double _UsagePerUnit;
        
        public Account()
        {
        }
		Account(StatementLine line, double usage)
		{
            _Line = line;
            _AvaliableUnit = usage;
            Console.WriteLine("line: " + line);
            //Why the shit is this null
            if (line != null){
                Console.WriteLine("Account line is not null" + line);
                _ServiceID = line.ServiceID;
                _Credit = line.PhoneAccount.Credit;
                _UsedCredit = line.PhoneAccount.UsedCredit;
                _UsagePerUnit = 0;
                _UsedUnit = 0;
            }
		}
        
        protected Account(string id, string description, double usage, double credit)
        {
#warning dont we have to init line?

            _ServiceID = id;
            _Credit = credit;
            _AvaliableUnit = usage;
            _UsagePerUnit = 0;
            _UsedUnit = 0;
            _UsedCredit = 0;
            
            Console.WriteLine("Protected: Av: {0}, Cr: {1}, SiD: {2}", _AvaliableUnit, _Credit, _ServiceID);

        }
        
        public string ServiceID{ get { return _ServiceID;}}
        internal double Credit { get { return _Credit;}}
        internal double UsedCredit { get { return _UsedCredit;}}
        internal StatementLine Line { get { return _Line;}}
        
        
        public void AdjustAccount(AccountType usage)
        {
            double _avaliableUnit = 0;
            
            if (usage != null){
            
                _UsagePerUnit = AccountUsage.AccountType(usage);
                
                if (usage is CallAccountUsage)
                {
                    CallAccountUsage Usage = usage as CallAccountUsage;
                    _avaliableUnit = Usage.Usage;
                } else {
                    MessageAccountUsage Usage = usage as MessageAccountUsage;
                    _avaliableUnit = Usage.Usage;
                }           
            }
            
            if ((_AvaliableUnit - _UsedUnit) > _avaliableUnit){
                _UsedUnit = _UsedUnit + _avaliableUnit;
            }
            _UsedCredit = _UsedCredit + (_avaliableUnit * _UsagePerUnit);
        }
        
        public bool Record(string description, AccountType usage, out ServiceItem item)
        {
            bool status = true;
            double numberOfRecordUsage = DEFAULT_USAGE;
            item = null;

            if (usage is CallAccountUsage)
            {
                CallAccountUsage Usage = usage as CallAccountUsage;
                numberOfRecordUsage = Math.Ceiling(Usage.Usage);
            } else if (usage is MessageAccountUsage) {
                MessageAccountUsage Usage = usage as MessageAccountUsage;
                numberOfRecordUsage = Convert.ToDouble(Usage.Usage);
            }
                
            _UsedUnit += numberOfRecordUsage;
            _UsedCredit += (numberOfRecordUsage * _UsagePerUnit);
            item = new ServiceItem(numberOfRecordUsage, description, _UsagePerUnit);

            Console.WriteLine(description);
            Console.WriteLine("NRU: "+numberOfRecordUsage);
            Console.WriteLine("Av: {0}, UU: {1}, UC: {2}, UPU:{3}", _AvaliableUnit, _UsedUnit, _UsedCredit, _UsagePerUnit);
            if (_AvaliableUnit - _UsedUnit >= numberOfRecordUsage)
            {
                            Console.WriteLine("1");

                _UsedUnit += numberOfRecordUsage;
                _UsedCredit += _UsedUnit * _UsagePerUnit;
                item = null;
            }
            if (numberOfRecordUsage > _AvaliableUnit - _UsedUnit)
            {
                            Console.WriteLine("2");

                numberOfRecordUsage = _AvaliableUnit - _UsedUnit;
                item = null;
            }
            if (numberOfRecordUsage < 0)
            {
                Console.WriteLine("3");
               status = false;
                item = null;
            }
            Console.WriteLine("NRU: "+numberOfRecordUsage);
            Console.WriteLine("Av: {0}, UU: {1}, UC: {2}, UPU:{3}", _AvaliableUnit, _UsedUnit, _UsedCredit, _UsagePerUnit);
            Console.WriteLine("\n\n");
            return status;
        }

        public void RollOver()
        {
        }
        
	}
}
