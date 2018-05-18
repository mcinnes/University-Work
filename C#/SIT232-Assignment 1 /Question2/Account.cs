using System;
namespace Question1
{
     abstract class Account
	{
        private string _ServiceID;
        protected double _Credit;
        protected double _UsedCredit;
        private StatementLine _Line;
        
        protected Account(){}
        
		protected Account(StatementLine line, double credit)
		{
            _ServiceID = line.ServiceID;
            _Credit = credit;
            _UsedCredit = 0;
            _Line = line;
		}
        Account (StatementLine line)
        {
            _Line = line;
            _ServiceID = line.ServiceID;
            _Credit = line.PhoneAccount.Credit;
            _UsedCredit = line.PhoneAccount.UsedCredit;
        }
        
        public string ServiceID{ get { return _ServiceID;}}
        internal double Credit { get { return _Credit;}}
        internal double UsedCredit { get { return _UsedCredit;}}
        internal StatementLine Line { get { return _Line;}}
        
        
        public abstract void AdjustAccount(AccountType usage);
        
        public abstract bool Record(string description, AccountType usage, out ServiceItem item);

        public abstract void RollOver();
        
	}
}
