using System;
namespace Question1
{
	 class CallAccount : Account 
	{
        private double _Usage;
       public CallAccount(double usage)
       {
            _Usage = usage;
       }
        public CallAccount(StatementLine line, double usage, double credit):base(line.ServiceID, line.Description, usage, credit)
       {
        
       }
       public double Usage{ get { return _Usage;} set { _Usage = value;}}
	}
}
