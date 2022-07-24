using System;

namespace TestTask_CSharpDeveloper.SquareCalculate.Abstract
{
    /// <summary>
    /// Base abstract class for two type of shapes: circle and ellipse
    /// </summary>
    public abstract class NoAngleShapeBase : ShapeBase
    {
        protected Double _semiAxisA;
        protected Double _semiAxisB;
        private const Double PI = 3.14d;

        /// <summary>
        /// Calculates circle square using radius and assignes calculated value to a field
        /// </summary>
        /// <returns>Value represents circle square</returns>
        public override Double Square()
        {
            if (_square == default)
                return _square = PI * _semiAxisA * _semiAxisB;
            else
                return _square;
        }
        /// <summary>
        /// Method checks if two objects being compared are equal using field equality test
        /// </summary>
        /// <param name="obj">Comparsion object</param>
        /// <returns>true if comparsion object is equal to this, else false</returns>
        public override Boolean Equals(Object obj)
        {
            var other = obj as NoAngleShapeBase;
            if (other == null)
                return false;
            else
                return (_semiAxisA == other._semiAxisA && _semiAxisB == other._semiAxisB);
        }
        /// <summary>
        /// Method presents class name in string format with parent class
        /// </summary>
        /// <returns>Class name</returns>
        public override String ToString()
            => base.ToString() + $".{nameof(NoAngleShapeBase)}";
        /// <summary>
        /// Create simple hash code
        /// </summary>
        /// <returns>Object hash code</returns>
        public override int GetHashCode()
        {
            int hashCode = 695497833;
            hashCode = hashCode * -1521134295 + _semiAxisA.GetHashCode();
            hashCode = hashCode * -1521134295 + _semiAxisB.GetHashCode();
            return hashCode;
        }
    }
}
