using System;
namespace Question1
{
	 class MessageAccountUsage : AccountType
	{
        private int _Usage;
        
		public MessageAccountUsage(int usage)
		{
            _Usage = usage;
		}
        public int Usage { get { return _Usage; } }


	}
}
