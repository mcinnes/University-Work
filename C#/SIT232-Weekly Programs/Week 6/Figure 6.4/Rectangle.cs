/*************************************************************
** File: Rectangle.cs
** Author/s: Justin Rough
** Description:
**     The class for representing a rectangle, which derives
** from the Shape base class.
*************************************************************/
using System;

namespace Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(double length, double height)
        {
            _Length = length;
            _Height = height;
        }

        private double _Height;
        public double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        private double _Length;
        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public override double GetArea()
        {
            return _Height * _Length;
        }
    }
}
