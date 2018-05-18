/*************************************************************
** File: CreditCard.cs
** Author/s: Justin Rough
** Description:
**     The CreditCard class that inherits from the Account
** class for demonstrating inheritance.
*************************************************************/
using System;

namespace BankAccounts
{
    class CreditCard : Account
    {
        public CreditCard(decimal balance, decimal limit) : base(balance)
        {
            _Limit = limit;
        }

        private decimal _Limit;
        public decimal Limit
        {
            get { return _Limit; }
            set { _Limit = value; }
        }

        public void Payment(decimal amount)
        {
            _Balance += amount;
        }

        public bool Purchase(decimal amount)
        {
            bool result = true;

            if(-_AvaliableBalance + amount <= _Limit)
                _AvaliableBalance -= amount;
            else
                result = false;

            return result;
        }

        public new decimal Balance
        {
            get { return -_AvaliableBalance; }
        }

        public override string ToString()
        {
            string result;

            if (_AvaliableBalance < 0)
                result = string.Format("Balance: {0:c} owed", -_AvaliableBalance);
            else if(_AvaliableBalance == 0)
                result = base.ToString();
            else
                result = base.ToString() + " in credit";

            result += ", limit " + _Limit.ToString("c");

            return result;
        }
    }
}