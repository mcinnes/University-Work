using System;
namespace Question1
{
	 class MessageAccount : Account
	{

        private int _Usage;
        
        public MessageAccount(int usage)
		{
            _Usage = usage;
            Console.WriteLine("usage-mess " + Usage);
		}
      public MessageAccount(StatementLine line, int usage, double credit):base(line.ServiceID, line.Description, usage, credit)
       {
        
       }
        public int Usage { get { return _Usage; } set { _Usage = value;} }

	}
}
