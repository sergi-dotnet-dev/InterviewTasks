using System;

namespace TestTask_CSharpDeveloper.SquareCalculate.Abstract
{
    /// <summary>
    /// Base abstract class of different shapes
    /// </summary>
    public abstract class ShapeBase
    {
        protected Double _square = default;

        /// <summary>
        /// Square private field property.
        /// If Square was not determine yet, calculate Square, else return Square value
        /// </summary>
        public Double GetSquare
        {
            get
            {
                if (_square == default)
                    Square();
                return _square;
            }
        }
        /// <summary>
        /// Calculate shape square
        /// </summary>
        /// <returns>Square value</returns>
        public abstract Double Square();
        /// <summary>
        /// Method presents class name in string format
        /// </summary>
        /// <returns>Class name</returns>
        public override String ToString()
            => nameof(ShapeBase);
    }
}