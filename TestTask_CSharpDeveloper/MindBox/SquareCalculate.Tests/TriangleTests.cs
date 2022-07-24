using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTask_CSharpDeveloper.SquareCalculate.Code;

namespace SquareCalculate.Tests
{
    [TestClass]
    public class TriangleTests
    {
        private const Double tolerance = 0.00000001d;
        #region Constructor tests
        [TestMethod]
        public void TriangleCtor_NegativeParam_ArgumentExceptionReturned()
        {
            try
            {
                Triangle triangle = new Triangle(-2, 123d, 2222222222.2323133d);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [TestMethod]
        public void TriangleCtor_ZeroParam_ArgumentExceptionReturned()
        {
            try
            {
                Triangle triangle = new Triangle(13555, 0, 2222222222.2323133d);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void TriangleCtor_InstanceReturned()
        {
            Triangle triangle = new Triangle(1, 2, 2.5d);
            Assert.AreEqual(true, triangle != null);
        }
        [TestMethod]
        public void TriangleCtor_IncorrectSideValue_ArgumentExceptionReturned()
        {
            try
            {
                Triangle triangle = new Triangle(2, 4, 9);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
        #endregion
        #region Properties tests
        [TestMethod]
        public void GetSquare_NotRectTriangle_SquareReturned()
        {
            Triangle triangle = new Triangle(2, 2.4d, 2);
            Assert.AreEqual(1.92d, triangle.GetSquare, tolerance);
        }
        [TestMethod]
        public void GetSquare_RectTriangle_SquareReturned()
        {
            Triangle triangle = new Triangle(5, 4, 3);
            Assert.AreEqual(6, triangle.GetSquare, tolerance);
        }
        [TestMethod]
        public void GetIsRectangular_TrueReturned()
        {
            Triangle triangle = new Triangle(5, 4, 3);
            Assert.AreEqual(true, triangle.GetIsRectangular);
        }
        [TestMethod]
        public void GetIsRectangular_FalseReturned()
        {
            Triangle triangle = new Triangle(3, 6, 4);
            Assert.AreNotEqual(true, triangle.GetIsRectangular);
        }
        #endregion
        #region Methods tests
        [TestMethod]
        public void Square_NotRectTriangle_SquareReturned()
        {
            Triangle triangle = new Triangle(2, 2.4, 2);
            Assert.AreEqual(1.92, triangle.Square(), tolerance);
        }
        [TestMethod]
        public void Square_RectTriangle_SquareReturned()
        {
            Triangle triangle = new Triangle(5, 4, 3);
            Assert.AreEqual(6, triangle.Square(), tolerance);
        }
        #endregion
        #region Override methods tests
        [TestMethod]
        public void Equals_TrueReturned()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            var triangle1 = new Triangle(3, 5, 4);

            Assert.AreEqual(true, triangle.Equals(triangle1));
        }
        [TestMethod]
        public void Equals_FalseReturned()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            var triangle1 = new Triangle(3, 6, 4);

            Assert.AreNotEqual(true, triangle.Equals(triangle1));
        }
        [TestMethod]
        public void GetHashCode_SameObjects_TrueReturned()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            var triangle1 = new Triangle(3, 5, 4);

            Assert.AreEqual(triangle1.GetHashCode(), triangle.GetHashCode());
        }
        [TestMethod]
        public void GetHashCode_DifferentObjects_FalseReturned()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            var triangle1 = new Triangle(3, 6, 4);

            Assert.AreNotEqual(triangle1.GetHashCode(), triangle.GetHashCode());
        }
        #endregion
    }
}
