/*************************************************************
** File: DerivedClass.cs
** Author/s: Justin Rough
** Description:
**     Trivial derived class used for demonstrating the
** differences between method hiding and polymorphic methods.
*************************************************************/
using System;

namespace OverrideAndHide
{
    class DerivedClass : BaseClass
    {
        public new void SimpleMethod()
        {
            Console.WriteLine("This is DerivedClass.SimpleMethod()");
        }

        public override void PolymorphicMethod()
        {
            Console.WriteLine("This is DerivedClass.PolymorphicMethod()");
        }
    }
}
