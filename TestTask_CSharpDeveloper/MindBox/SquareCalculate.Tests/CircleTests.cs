using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask_CSharpDeveloper.SquareCalculate.Code;
using System;

namespace SquareCalculate.Tests
{
    [TestClass]
    public class CircleTests
    {
        private const Double tolerance = 0.000001d;
        #region Constructor tests
        [TestMethod]
        public void CircleCtor_NegativeParam_ArgumentExceptionReturned()
        {
            try
            {
                Circle circle = new Circle(-2.2d);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void CircleCtor_ZeroParam_ArgumentExceptionReturned()
        {
            try
            {
                Circle circle = new Circle(0);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void CircleCtor_InstanceSuccessed()
        {
            Circle circle = new Circle(2);
            Assert.IsTrue(circle != null);
        }
        #endregion
        #region Properties tests
        [TestMethod]
        public void GetRadius_RadiusReturned()
        {
            var circle = new Circle(2);
            Assert.AreEqual(2, circle.GetRadius, tolerance);
        }
        [TestMethod]
        public void GetSquare_SquareReturned()
        {
            var circle = new Circle(2);
            Assert.AreEqual(12.56d, circle.GetSquare, tolerance);
        }
        #endregion
        #region Methods tests
        [TestMethod]
        public void Square_CorrectValueReturned()
        {
            Circle circle = new Circle(5.6d);
            Assert.AreEqual(98.4704d, circle.Square(), tolerance);
        }
        #endregion
        #region Ovveride methods tests
        [TestMethod]
        public void CircleToString_ExpectedStringReturned()
        {
            var circle = new Circle(2);
            Assert.AreEqual("Hierarchy: ShapeBase.NoAngleShapeBase Shape: Circle. Radius= 2", circle.ToString());
        }
        [TestMethod]
        public void CircleEquals_TrueReturned()
        {
            Circle circle = new Circle(3);
            var obj = new Circle(3);

            Assert.AreEqual(true, circle.Equals(obj));
        }
        [TestMethod]
        public void CircleEquals_FalseReturned()
        {
            Circle circle = new Circle(3);
            var obj = new Circle(2);

            Assert.AreEqual(false, circle.Equals(obj));
        }
        [TestMethod]
        public void CircleEquals_WhenObjectIsNullRef_FalseReturned()
        {
            Circle circle = new Circle(3);
            Circle obj = null;

            Assert.AreEqual(false, circle.Equals(obj));
        }
        [TestMethod]
        public void CircleGetHashCode_SameObjects_TrueReturned()
        {
            Circle circle = new Circle(3.2d);
            Circle circle1 = new Circle(3.2d);

            Assert.AreEqual(circle.GetHashCode(), circle1.GetHashCode());
        }
        [TestMethod]
        public void CircleGetHashCode_DifferentObjects_FalseReturned()
        {
            Circle circle = new Circle(3.2d);
            Circle circle1 = new Circle(3.22d);

            Assert.AreNotEqual(circle.GetHashCode(), circle1.GetHashCode());
        }
        #endregion
    }
}
