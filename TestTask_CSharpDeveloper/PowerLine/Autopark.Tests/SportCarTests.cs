using Autopark.Code;
namespace Autopark.Tests
{
    [TestClass]
    public class SportCarTests
    {
        private const Double tolerance = 0.01d;
        #region Constructor tests
        [TestMethod]
        public void Ctor_NegativeParametrValue_ArgumentExceptionreturned()
        {
            try
            {
                SportCar sportcar= new("sportcar", -2, 40, -23);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.Write(ex.Message);
            }
        }
        [TestMethod]
        public void Ctor_ZeroParametrValue_ArgumentExceptionreturned()
        {
            try
            {
                SportCar sportcar = new("sportcar", 0, 40, 17);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.Write(ex.Message);
            }
        }
        [TestMethod]
        public void Ctor_CorrectParameters_InstanceReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.IsTrue(sportcar != null);
        }
        #endregion
        #region Properties tests
        [TestMethod]
        public void GetCarType_CarTypeReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual("sportcar", sportcar.GetCatType);
        }
        [TestMethod]
        public void GetAverageFuelConsumption_AverageFuelConsumptionReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(15, sportcar.GetAverageFuelConsumption);
        }
        [TestMethod]
        public void GetTankVolume_TankVolumeReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(40, sportcar.GetTankVolume);
        }
        [TestMethod]
        public void GetSpeed_SpeedReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(17, sportcar.GetSpeed);
        }
        [TestMethod]
        public void GetMaxPassengersCount_MaxPassengersCountReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(2, sportcar.GetMaxPassengersCount);
        }
        [TestMethod]
        public void GetPassengersCount_WhenInstanceCreated_PassengersCountReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(1, sportcar.GetPassengersCount);
        }
        [TestMethod]
        public void GetPassengersCount_WhenPassengersAdded_PassengersCountReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            sportcar.AddToCar(1);
            Assert.AreEqual(2, sportcar.GetPassengersCount);
        }
        #endregion
        #region Methods tests
        [TestMethod]
        public void MilesLeft_ArgumentExceptionReturned()
        {
            try
            {
                SportCar sportcar = new("sportcar", 15, 40, 17);
                sportcar.MilesLeft(-1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        [TestMethod]
        public void MilesLeft_ValueReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(sportcar.MilesLeft(30), 2, tolerance);
        }
        [TestMethod]
        public void PowerReserve_ValueReturned()
        {
            SportCar sportcar = new("passengercar", 15, 40, 17);
            Assert.AreEqual(sportcar.PowerReserve(sportcar.GetTankVolume, sportcar.GetPassengersCount), 2.63d, tolerance);
        }
        [TestMethod]
        public void Time_MoreThanPowerReverse_ValueReturned()
        {
            SportCar sportcar = new("passengercar", 15, 40, 17);
            Assert.AreEqual(sportcar.Time(sportcar.GetTankVolume, 430), 0.147d, tolerance);
        }
        [TestMethod]
        public void Time_LessThanPowerReserve_ValueReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.AreEqual(sportcar.Time(sportcar.GetTankVolume, 2), 0.117d, tolerance);
        }
        [TestMethod]
        public void IsCarHasEmprtySpace_TrueReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.IsTrue(sportcar.IsCarHasEmprtySpace(1));
        }
        [TestMethod]
        public void IsCarHasEmprtySpace_FalseReturned()
        {
            SportCar sportcar = new("sportcar", 15, 40, 17);
            Assert.IsFalse(sportcar.IsCarHasEmprtySpace(4));
        }
        #endregion
    }
}