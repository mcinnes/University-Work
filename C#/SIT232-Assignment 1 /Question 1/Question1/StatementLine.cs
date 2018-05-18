using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
namespace Question1
{
    class StatementLine
    {
        // Define data attributes
        private string _ServiceID;
        private string _Description;
        private Account _PhoneAccount;
        private static List<StatementLine> _RecordMessageLines = new List<StatementLine>();
        private static List<StatementLine> _RecordCallLines = new List<StatementLine>();

        // public properties
        public string ServiceID
        {
            get { return _ServiceID; }
        }
       
        public string Description
        {
            get { return _Description; }
        }

        public Account PhoneAccount
        {
            get { return _PhoneAccount; }
        }
        public static ReadOnlyCollection<StatementLine> RecordMessageLines
        {
            get { return _RecordMessageLines.AsReadOnly(); }
        }

        public static ReadOnlyCollection<StatementLine> RecordCallLines
        {
            get { return _RecordCallLines.AsReadOnly(); }
        }       
        
        // Encapsulate Custom constructor
        private StatementLine(string id, string description)
        {
            _ServiceID = id;
            _Description = description;
        }

        // Service method return the match MessageAccount id StatementLine record or null object if it is not found
        public static StatementLine StatementMessageID(string id)
        {
            StatementLine result = null;
            foreach (StatementLine l in _RecordMessageLines)
            {
                if (l.ServiceID == id)
                {

                    result = l;
                    break;
                }
            }
           
            return result;
        }
        // Service method return the match CallAccount id StatementLine record or null object if it is not found
        public static StatementLine StatementCallID(string id)
        {
            StatementLine result = null;
            foreach (StatementLine l in _RecordCallLines)
            {
                if (l.ServiceID == id)
                {
                    result = l;
                    break;
                }
            }

            return result;
        }

        // Service method return new MessageAccount creating status is true - if it is not existing on the List
        public static bool CreateMessageAccount(string id, string description, int usage, double credit)
        {
          if (StatementMessageID(id) != null)
               return false;

            StatementLine line = new StatementLine(id, description);
            line._PhoneAccount = new MessageAccount(line, usage, credit);       
            _RecordMessageLines.Add(line);

            return true;
        }
        // Service method return new CallAccount creating status is true - if it is not existing on the List
        public static bool CreateCallAccount(string id, string description, double defaultUsage, double credit)
        {
           if (StatementCallID(id) != null)
                 return false;

            StatementLine line = new StatementLine(id, description);
            line._PhoneAccount = new CallAccount(line, defaultUsage, credit);
            _RecordCallLines.Add(line);

            return line != null;
        }
        //Service method to record new ServiceItem for the _PhoneAccount attribute
        public bool Record(string description, AccountType usage, out ServiceItem items)
        {
            return _PhoneAccount.Record(description, usage, out items);
        }
        // Override ToString() function to format the StatementLine class object as a string data type object
        public override string ToString()
        {
            return string.Format("{0} Starting Credit: {1,7:c} Used Credit: {2,7:c} Available: {3,7:c}\n\t- {4,-20} Allowed Usage Unit: {5,5}\n\n", _ServiceID, _PhoneAccount.Credit, _PhoneAccount.UsedCredit, _PhoneAccount.Credit - _PhoneAccount.UsedCredit, _Description, _PhoneAccount);
        }
    }
}
