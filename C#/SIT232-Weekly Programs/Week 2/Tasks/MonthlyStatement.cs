/*
Matt McInnes
mpmcinne
214119048
*/
using System;
using System.Text;

namespace BankAccount
{
    public class MonthlyStatement
    {
        private float _OpeningBalance;
        private float _InterestRate;

        private float[] _Deposits = new float[31];
        private float[] _Withdrawals = new float[31];
        private float[] _Balance = new float[31];
        private float[] _DailyInterest = new float[31];
        private int _DayCount = 0;

        
        public MonthlyStatement(float openingBalance, float interestRate)
        {
            _OpeningBalance = openingBalance;
            _InterestRate = interestRate;
        }

        private void CalculateInterest()
        {
            float dailyRate = (_InterestRate / 365) * 100;

            _DailyInterest[_DayCount] = _Balance[_DayCount] / dailyRate;
        }

        private float SumInterest(int maxIndex)
        {
            int count;

            float totalInterest = 0.0f;
            for (count = 0; count < maxIndex; count++)
            {
                totalInterest = _DailyInterest[count];
            }

            return (totalInterest);
        }

        public void RecordDay(float deposits, float withdrawals)
        {
            //EoM
            if (_DayCount > 31)
            {
                Console.WriteLine("Error: No more days in the month!");
                return;
            }

            //2+ days
            if (_DayCount > 0)
            {
                 _Deposits[_DayCount] = deposits;
                _Balance[_DayCount] = _Balance[_DayCount - 1] + deposits;
            }
            else
            {
            //First Day
             _Balance[_DayCount] = _OpeningBalance;

            _Deposits[_DayCount] = deposits;

            _Balance[_DayCount] = deposits;
            }
            //} this is correct balance
            //if balance is bigger or equal to withdrawals we continue with it
            if (_Balance[_DayCount] >= withdrawals)
            {   
                //write withdrawals as sent nume
                _Withdrawals[_DayCount] = withdrawals;
                //day balance is balance less withdrawals
                _Balance[_DayCount] -= withdrawals;
            }
            else
            {
                //if it isn't we do this
                Console.WriteLine("Error: Withdrawals of {0:c} on day {1} are unable to processed.  Available balance is {2:c}.", withdrawals, _DayCount + 1, _Balance[_DayCount]);
                //Zero out withdrawals
                _Withdrawals[_DayCount] = 0;
            }


            CalculateInterest();
            if (_DayCount == 31)
            {
                // Pay any interest on the 31st day of the month
                float totalInterest = SumInterest(_DayCount);
                _Deposits[_DayCount] = totalInterest;
                _Balance[_DayCount] += totalInterest;
            }

            //Next day
            _DayCount++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            float totalDeposits = 0.0f;
            float totalWithdrawals = 0.0f;

            // Header
            sb.Append("+-----+--------------+--------------+--------------+\n");
            sb.Append("| Day |     Deposits |  Withdrawals |      Balance |\n");
            sb.Append("+-----+--------------+--------------+--------------+\n");

            // Body
            for (int count = 0; count < this._DayCount; count++)
            {
                totalDeposits += _Deposits[count];
                totalWithdrawals += _Withdrawals[count];
                sb.AppendFormat("| {0,3:d} | {1,12:c} | {2,12:c} | {3,12:c} |\n", (count + 1), _Deposits[count], _Withdrawals[count], _Balance[count]);
            }

            // Footer
            sb.Append("+-----+--------------+--------------+--------------+\n");
            sb.AppendFormat("|     | {0,12:c} | {1,12:c} |              |\n", totalDeposits, totalWithdrawals);
            sb.Append("+-----+--------------+--------------+--------------+\n");

            return sb.ToString();
        }
    }
}
