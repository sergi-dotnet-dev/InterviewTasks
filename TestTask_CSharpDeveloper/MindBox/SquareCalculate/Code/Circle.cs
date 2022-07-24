using System;
using TestTask_CSharpDeveloper.SquareCalculate.Abstract;

namespace TestTask_CSharpDeveloper.SquareCalculate.Code
{
    /// <summary>
    /// Class represents Circle
    /// </summary>
    public sealed class Circle : NoAngleShapeBase
    {
        /// <summary>
        /// Constructor that takes a radius parameter as an argument
        /// </summary>
        /// <param name="radius">Represents circle radius</param>
        /// <exception cref="ArgumentException">Throw if argument has a wrong value (value is negative or zero)</exception>
        public Circle(Double radius)
        {
            _semiAxisA = radius <= 0d
                ? throw new ArgumentException("Value can not be negative or zero")
                : radius;
            _semiAxisB = _semiAxisA;
        }
        /// <summary>
        /// Raduis field property
        /// </summary>
        public Double GetRadius => _semiAxisA;

        /// <summary>
        /// Method presents Circle class info in string format
        /// </summary>
        /// <returns>Class name and radius value</returns>
        public override String ToString()
            => $"Hierarchy: {base.ToString()} Shape: {nameof(Circle)}. Radius= {_semiAxisA}";
    }
}
