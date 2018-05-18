/*************************************************************
** File: Shape.cs
** Author/s: Justin Rough
** Description:
**     The base class for the Shapes example, containing only
** abstract methods.
*************************************************************/
using System;

namespace Shapes
{
    abstract class Shape
    {
        public abstract double GetArea();

        public abstract double GetPerimeter();
    }
}
