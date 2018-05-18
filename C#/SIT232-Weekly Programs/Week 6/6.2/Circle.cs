/*************************************************************
** File: Circle.cs
** Author/s: Justin Rough
** Description:
**     The class for representing a circle, which derives from
** the Shape base class.
*************************************************************/
using System;

namespace Shapes
{
    class Circle : IShape
    {
        public Circle(double radius)
        {
            _Radius = radius;
        }

        private double _Radius;
        public double Radius
        {
            get { return _Radius; }
            set { _Radius = value; }
        }

        public double GetArea()
        {
            return Math.PI * _Radius * _Radius;
        }
        public double GetPerimeter()
        {
            return 2 * _Radius * Math.PI;
        }
    }
}
