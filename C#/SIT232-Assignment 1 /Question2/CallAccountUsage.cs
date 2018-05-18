using System;
namespace Question1
{
	public class CallAccountUsage : AccountType
	{
		private readonly double _Usage;

		public CallAccountUsage(double usage)
		{
            _Usage = usage;
		}
		public double Usage { get { return _Usage; } }

	}
}
