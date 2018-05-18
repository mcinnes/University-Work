using System;
namespace Question1
{
	public class MessageAccountUsage : AccountType
	{
		private readonly int _Usage;

		public MessageAccountUsage(int usage)
		{
            _Usage = usage;
		}

		public int Usage { get { return _Usage; } }

	}
}
