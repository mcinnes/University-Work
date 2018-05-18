using System;
namespace Question1
{
	 class CallAccountUsage : AccountType
	{
        private double _Usage;

        public CallAccountUsage(double usage)
        {
            _Usage = usage;
        }
        public double Usage { get { return _Usage; } }

	}
}
