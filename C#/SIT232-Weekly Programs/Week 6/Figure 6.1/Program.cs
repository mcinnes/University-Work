/*************************************************************
** File: Program.cs
** Author/s: Justin Rough
** Description:
**     A simple example program (not particularly realistic)
** that demonstrates the key differences between method
** hiding, which uses static binding, and polymorphic methods,
** that use dynamic binding.
*************************************************************/
using System;

namespace OverrideAndHide
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bcObject = new BaseClass();
            DerivedClass dcObject = new DerivedClass();
            BaseClass baseReference = dcObject;

            bcObject.SimpleMethod();
            bcObject.PolymorphicMethod();

            dcObject.SimpleMethod();
            dcObject.PolymorphicMethod();

            baseReference.SimpleMethod();
            baseReference.PolymorphicMethod();
        }
    }
}
