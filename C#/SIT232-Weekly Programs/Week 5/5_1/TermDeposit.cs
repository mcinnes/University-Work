using System;
namespace BankAccounts
{
	class TermDeposit : Account 
{
    public TermDeposit(decimal balance, int term) : base(balance) 
    {
        _Term = term;
        CalculateInterest(10);
       //Console.WriteLine("{0}", CalculateInterest(_Balance).ToString);    
    }
    private int _Term;
    public int Term
    {
        get { return _Term;}
    }
    
    public override string ToString()
    {
        return string.Format("[TermDeposit: Term={0}]", Term);
    }
    
    public void CalculateInterest(decimal interestRate)
    {
        //Balance * Rate / percent / 12 months * Term
        decimal interest = ((_AvaliableBalance * interestRate) / 100) / (12 * _Term);
        
        Console.WriteLine("Interest is: ${0:F2}", interest * 100);
    }
}
}
