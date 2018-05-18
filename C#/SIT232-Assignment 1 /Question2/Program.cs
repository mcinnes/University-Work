using System;

namespace Question1
{
    class Program
    {
      

         private static void PreloadData()
        {
            //Create new type of Accounts
            StatementLine.CreateMessageAccount("0411222333", "M Plan Message", 50, 800);
            StatementLine.CreateCallAccount("0411222333", "M Plan Call Usage", 500, 800);

            StatementLine.CreateMessageAccount("0411333444", "XL Plan Message", 100, 2750);
            StatementLine.CreateCallAccount("0411333444", "XL Plan Call Usage", 2000, 2750);

            // Testing Adjust bonus free usage before Roll over to new Message Account statement
            StatementLine.StatementMessageID("0411222333").PhoneAccount.AdjustAccount(new MessageAccountUsage(-2));
            StatementLine.StatementMessageID("0411222333").PhoneAccount.RollOver();
            StatementLine.StatementMessageID("0411222333").PhoneAccount.AdjustAccount(new MessageAccountUsage(2));
            // Testing Adjust bonus free usage before Roll over to new Call Account statement
            StatementLine.StatementCallID("0411222333").PhoneAccount.AdjustAccount(new CallAccountUsage(-30));
            StatementLine.StatementCallID("0411222333").PhoneAccount.RollOver();
            StatementLine.StatementCallID("0411222333").PhoneAccount.AdjustAccount(new CallAccountUsage(30));
            // Testing Adjust bonus free usage before Roll over to new Message Account statement
            StatementLine.StatementMessageID("0411333444").PhoneAccount.AdjustAccount(new MessageAccountUsage(-10));
            StatementLine.StatementMessageID("0411333444").PhoneAccount.RollOver();
            // reject the next statement
            StatementLine.StatementMessageID("0411333444").PhoneAccount.AdjustAccount(new MessageAccountUsage(200));
            StatementLine.StatementMessageID("0411333444").PhoneAccount.AdjustAccount(new MessageAccountUsage(10));
            // Testing Adjust bonus free usage before Roll over to new Call Account statement
            StatementLine.StatementCallID("0411333444").PhoneAccount.AdjustAccount(new CallAccountUsage(1000));
            StatementLine.StatementCallID("0411333444").PhoneAccount.RollOver();
            // reject the next statement
            StatementLine.StatementCallID("0411333444").PhoneAccount.AdjustAccount(new CallAccountUsage(2000));

        }

        static void Main(string[] args)
        {
            PreloadData();

            Console.WriteLine("=====================");
            Console.WriteLine("Load Account Details");
            Console.WriteLine("=====================");
            foreach (StatementLine line in StatementLine.RecordMessageLines)
                Console.WriteLine("- {0}", line);
            foreach (StatementLine line in StatementLine.RecordCallLines)
                Console.WriteLine("- {0}", line);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Create new AccountStatement object
            AccountStatement record = new AccountStatement();
            ServiceItem item; // declare new ServiceItem object
            //Record new testing ServiceItem for different type of Account
            if (StatementLine.StatementMessageID("0411222333").Record("SMS 047123456", new MessageAccountUsage(5), out item) == true)
                record.Add(item);
            if (StatementLine.StatementCallID("0411333444").Record("Call 0411222333", null, out item) == true)
                record.Add(item);
            if (StatementLine.StatementMessageID("0411333444").Record("SMS 0411222333", null, out item) == true)
                record.Add(item);
            if (StatementLine.StatementCallID("0411222333").Record("Call 0413211893", new CallAccountUsage(49.2), out item) == true)
                record.Add(item);
            if (StatementLine.StatementCallID("0411222333").Record("Call 0418112734", new CallAccountUsage(5000), out item) == true)
                record.Add(item);
            if (StatementLine.StatementMessageID("0411333444").Record("SMS 018442564", null, out item) == true)
                record.Add(item);
            if (StatementLine.StatementCallID("0411333444").Record("Call 018442564", new CallAccountUsage(300), out item) == true)
                record.Add(item);
            if (StatementLine.StatementCallID("0411333444").Record("Call 017312896", new CallAccountUsage(2000), out item) == true)
                record.Add(item);

            Console.WriteLine("=======");
            Console.WriteLine("Recorded Usage");
            Console.WriteLine("=======");
            Console.WriteLine(record.GetText());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("====================");
            Console.WriteLine("Current Account Usage");
            Console.WriteLine("====================");
            foreach (StatementLine line in StatementLine.RecordMessageLines)
                Console.WriteLine("- {0}", line);
            foreach (StatementLine line in StatementLine.RecordCallLines)
                Console.WriteLine("- {0}", line);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
        }
    }
}
