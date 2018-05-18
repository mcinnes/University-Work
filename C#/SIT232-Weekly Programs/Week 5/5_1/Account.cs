/*************************************************************
** File: Account.cs
** Author/s: Justin Rough
** Description:
**     The Account base class used to demonstrate inheritance.
*************************************************************/
using System;

namespace BankAccounts
{
    class Account
    {
        protected Account(decimal balance)
        {
            _AvaliableBalance = balance;
            _Balance = AvaliableBalance;
        }

        private decimal _Balance;
        public decimal Balance
        {
            get { return _Balance; }
        }

       protected decimal _AvaliableBalance;
       protected decimal AvaliableBalance
        {
            get { return _AvaliableBalance; }
        }
        
        public override string ToString()
        {
            return string.Format("Balance: {0:c}", _Balance);
        }
    }
}
