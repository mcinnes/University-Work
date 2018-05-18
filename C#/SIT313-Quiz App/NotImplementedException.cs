using System;
namespace JSONTest
{
    public class NotImplementedException: System.Exception 
    {
        public NotImplementedException()
        {
        }
        public NotImplementedException(string message):base(message)
        {
            
        }
    }
}
