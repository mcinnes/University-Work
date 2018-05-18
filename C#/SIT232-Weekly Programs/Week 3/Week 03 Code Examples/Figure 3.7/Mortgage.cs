/*************************************************************
** File: Mortgage.cs
** Author/s: Justin Rough
** Description:
**     A class for storing the data for a mortgage (home loan)
** which demonstrates the use of static and constant class
** members.
*************************************************************/
using System;

namespace Mortgage
{
    class Mortgage
    {
        private const ushort DAYS_PER_YEAR = 365;
        private const double DEFAULT_INTEREST_RATE = 0.085; // 8.5% per annum
        private static double _InterestRate = DEFAULT_INTEREST_RATE;
        public static double InterestRate
        {
            get { return _InterestRate; }
            set { _InterestRate = value; }
        }

        public Mortgage(decimal balance)
        {
            _Balance = balance;
        }

        private decimal _Balance;
        public decimal Balance
        {
            get { return _Balance; }
        }

        public void RecordPayment(decimal value)
        {
            _Balance -= value;
        }

        public void ChargeInterest(ushort days)
        {
            double rate = (_InterestRate * days / DAYS_PER_YEAR);
            double interestCharge = rate * Convert.ToDouble(_Balance);
            _Balance += Math.Round(Convert.ToDecimal(interestCharge), 2, MidpointRounding.AwayFromZero);
        }
    }
}