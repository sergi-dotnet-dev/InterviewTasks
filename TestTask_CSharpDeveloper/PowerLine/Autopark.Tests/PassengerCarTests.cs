using Autopark.Code;
namespace Autopark.Tests
{
    [TestClass]
    public class PassengerCarTests
    {
        private const Double tolerance = 0.01d;
        #region Constructor tests
        [TestMethod]
        public void Ctor_NegativeParametrValue_ArgumentExceptionreturned()
        {
            try
            {
                PassengerCar passengerCar = new("passengercar", -2, 40, -23, 4);
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
                PassengerCar passengerCar = new("passengercar", 0, 40, 17, 4);
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
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.IsTrue(passengerCar != null);
        }
        #endregion
        #region Properties tests
        [TestMethod]
        public void GetCarType_CarTypeReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual("passengercar", passengerCar.GetCatType);
        }
        [TestMethod]
        public void GetAverageFuelConsumption_AverageFuelConsumptionReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(15, passengerCar.GetAverageFuelConsumption);
        }
        [TestMethod]
        public void GetTankVolume_TankVolumeReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(40, passengerCar.GetTankVolume);
        }
        [TestMethod]
        public void GetSpeed_SpeedReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(17, passengerCar.GetSpeed);
        }
        [TestMethod]
        public void GetMaxPassengersCount_MaxPassengersCountReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(4, passengerCar.GetMaxPassengersCount);
        }
        [TestMethod]
        public void GetPassengersCount_WhenInstanceCreated_PassengersCountReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(1, passengerCar.GetPassengersCount);
        }
        [TestMethod]
        public void GetPassengersCount_WhenPassengersAdded_PassengersCountReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            passengerCar.AddToCar(2);
            Assert.AreEqual(3, passengerCar.GetPassengersCount);
        }
        #endregion
        #region Methods tests
        [TestMethod]
        public void MilesLeft_ArgumentExceptionReturned()
        {
            try
            {
                PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
                passengerCar.MilesLeft(-1);
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
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(passengerCar.MilesLeft(30), 2, tolerance);
        }
        [TestMethod]
        public void PowerReserve_ValueReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(passengerCar.PowerReserve(passengerCar.GetTankVolume, passengerCar.GetPassengersCount), 2.50d, tolerance);
        }
        [TestMethod]
        public void Time_MoreThanPowerReverse_ValueReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(passengerCar.Time(passengerCar.GetTankVolume, 430), 0.147d, tolerance);
        }
        [TestMethod]
        public void Time_LessThanPowerReserve_ValueReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(passengerCar.Time(passengerCar.GetTankVolume, 2), 0.117d, tolerance);
        }
        [TestMethod]
        public void IsCarHasEmprtySpace_TrueReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.IsTrue(passengerCar.IsCarHasEmprtySpace(2));
        }
        [TestMethod]
        public void IsCarHasEmprtySpace_FalseReturned()
        {
            PassengerCar passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.IsFalse(passengerCar.IsCarHasEmprtySpace(4));
        }
        #endregion
    }
}