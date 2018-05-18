/*************************************************************
** File: BaseClass.cs
** Author/s: Justin Rough
** Description:
**     Trivial base class used for demonstrating the
** differences between method hiding and polymorphic methods.
*************************************************************/
using System;

namespace OverrideAndHide
{
    class BaseClass
    {
        public void SimpleMethod()
        {
            Console.WriteLine("This is BaseClass.SimpleMethod()");
        }

        public virtual void PolymorphicMethod()
        {
            Console.WriteLine("This is BaseClass.PolymorphicMethod()");
        }
    }
}
