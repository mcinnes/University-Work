/*
Matt McInnes
mpmcinne
214119048
*/
using System;

namespace BankAccount
{
    class BankAccount
    {
        static void Main(string[] args)
        {
            MonthlyStatement account = new MonthlyStatement(0.00f, 4.95f);

            account.RecordDay(1.00f, 0.10f);	// Day 01
            account.RecordDay(2.00f, 0.20f);	// Day 02
            account.RecordDay(3.00f, 0.30f);	// Day 03
            account.RecordDay(4.00f, 0.40f);	// Day 04
            account.RecordDay(5.00f, 0.50f);	// Day 05
            account.RecordDay(6.00f, 0.60f);	// Day 06
            account.RecordDay(7.00f, 0.70f);	// Day 07
            account.RecordDay(8.00f, 0.80f);	// Day 08
            account.RecordDay(9.00f, 0.90f);	// Day 09
            account.RecordDay(10.00f, 1.00f);	// Day 10
            account.RecordDay(11.00f, 1.10f);	// Day 11
            account.RecordDay(12.00f, 1.20f);	// Day 12
            account.RecordDay(13.00f, 1.30f);	// Day 13
            account.RecordDay(14.00f, 1.40f);	// Day 14
            account.RecordDay(15.00f, 1.50f);	// Day 15
            account.RecordDay(16.00f, 1.60f);	// Day 16
            account.RecordDay(17.00f, 1.70f);	// Day 17
            account.RecordDay(18.00f, 1.80f);	// Day 18
            account.RecordDay(19.00f, 1.90f);	// Day 19
            account.RecordDay(20.00f, 2.00f);	// Day 20
            account.RecordDay(21.00f, 2.10f);	// Day 21
            account.RecordDay(22.00f, 2.20f);	// Day 22
            account.RecordDay(23.00f, 2.30f);	// Day 23
            account.RecordDay(24.00f, 2.40f);	// Day 24
            account.RecordDay(25.00f, 2.50f);	// Day 25
            account.RecordDay(26.00f, 2.60f);	// Day 26
            account.RecordDay(27.00f, 2.70f);	// Day 27
            account.RecordDay(28.00f, 2.80f);	// Day 28
            account.RecordDay(29.00f, 2.90f);	// Day 29
            account.RecordDay(30.00f, 3.00f);	// Day 30
            account.RecordDay(31.67f, 3.10f);	// Day 31

            Console.Write(account.ToString());
        }
    }
}
