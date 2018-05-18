using System;
namespace Question1
{
    public class AccountUsage
    {
        public AccountUsage()
        {
        }
        
        public static double AccountType(AccountType usage){
        
        if (usage is CallAccountUsage){
            return 1.00;
        } else if (usage is SMSMessageAccountUsage) {
            return 0.5;
        } else {
            return 0.75;
        }
        
        }
        
    }
}
