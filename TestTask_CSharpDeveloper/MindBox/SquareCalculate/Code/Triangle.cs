using System;
using TestTask_CSharpDeveloper.SquareCalculate.Abstract;

namespace TestTask_CSharpDeveloper.SquareCalculate.Code
{
    /// <summary>
    /// Represents Triangle shape
    /// </summary>
    public sealed class Triangle : ShapeBase
    {
        private readonly Double _sideA;
        private readonly Double _sideB;
        private readonly Double _sideC;
        private readonly Boolean _isRectangular = default;
        private Double[] catets;
        /// <summary>
        /// Constructor that takes a sides parameters as an arguments. Checks if triangle is rectangle
        /// </summary>
        /// <param name="sideA">Side parameter</param>
        /// <param name="sideB">Side parameter</param>
        /// <param name="sideC">Side parameter</param>
        /// <exception cref="ArgumentException">Throw if sides values are negative or zero</exception>
        public Triangle(Double sideA, Double sideB, Double sideC)
        {
            if (sideA <= 0d || sideB <= 0d || sideC <= 0d)
                throw new ArgumentException("Value can not be negative or zero");

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            _isRectangular = IsRectangular();
            

            //Local method that checks triangle is rectangular
            Boolean IsRectangular()
            {
                //Find largest side
                Double result = _sideA < _sideB || _sideA < _sideC ? _sideB < _sideC ? _sideC : _sideB : _sideA;

                catets = IsIncorrectTriangleSides(result);
                return (result * result == catets[0] * catets[0] + catets[1] * catets[1]);

                //Checks that single side is not longer than the sum of two others
                //Throw exception if true, else assignes potential catets values
                Double[] IsIncorrectTriangleSides(Double side)
                {
                    if (side == _sideA)
                    {
                        catets = new Double[2];
                        catets[0] = _sideB;
                        catets[1] = _sideC;
                        foreach (var catet in catets)
                            side -= catet;

                        if (side > 0) throw new ArgumentException("One side longer than the sum of others");
                        return catets;
                    }
                    else if (side == _sideB)
                    {
                        catets = new Double[2];
                        catets[0] = _sideA;
                        catets[1] = _sideC;
                        foreach (var catet in catets)
                            side -= catet;

                        if (side > 0) throw new ArgumentException("One side longer than the sum of others");
                        return catets;
                    }
                    else
                    {
                        catets = new Double[2];
                        catets[0] = _sideB;
                        catets[1] = _sideA;
                        foreach (var catet in catets)
                            side -= catet;

                        if (side > 0) throw new ArgumentException("One side longer than the sum of others");
                        return catets;
                    }
                }
            }
        }
        /// <summary>
        /// Return true if triangle is rectangular, else false
        /// </summary>
        public Boolean GetIsRectangular
            => _isRectangular;
        /// <summary>
        /// Calculates triangle square using 3 sides or 2 sides, if triangle is rectangle
        /// </summary>
        /// <returns>Triangle square</returns>
        public override Double Square()
        {
            if (_isRectangular)
                return RectTriangleSquare();

            return _square = HeronMethod();

            /// <summary>
            /// Heron's formula that calculates triangle square using 3 sides values
            /// </summary>
            /// <returns>Triangle square</returns>
            Double HeronMethod()
            {
                Double perimeterHalf = PerimeterHalf();
                return Math.Sqrt(perimeterHalf * (perimeterHalf - _sideA) * (perimeterHalf - _sideB) * (perimeterHalf - _sideC));

                //Local method that calculate a half of perimeter using 3 sides values
                Double PerimeterHalf()
                    => (_sideA + _sideB + _sideC) / 2d;
            }

            Double RectTriangleSquare()
            {
                _square = 0.5d;
                foreach (var side in catets)
                    _square *= side;
                return _square;
            }
        }
        /// <summary>
        /// Checks two objects equality
        /// </summary>
        /// <param name="obj">Comparsion object</param>
        /// <returns>true if objects fields values are equal, else false</returns>
        public override Boolean Equals(Object obj)
        {
            Triangle other = obj as Triangle;
            if (obj == null)
                return false;
            return (other._sideA == _sideA || other._sideA == _sideB || other._sideA == _sideC)
                &&(other._sideB == _sideA || other._sideB == _sideB || other._sideB == _sideC)
                &&(other._sideC == _sideA || other._sideC == _sideB || other._sideC == _sideC);
        }
        /// <summary>
        /// Create a simple object hash code
        /// </summary>
        /// <returns>Object hash code</returns>
        public override Int32 GetHashCode()
        {
            Int32 hashCode = 1777949731;
            hashCode += (Int32)GetSquare * 123355566;
            return hashCode;
        }
        /// <summary>
        /// Presents object info in string format
        /// </summary>
        /// <returns>Object info</returns>
        public override String ToString()
        {
            return base.ToString() + $"Shape: {nameof(Triangle)} with sides equals: {_sideA}, {_sideB}, {_sideC}";
        }
    }
}
