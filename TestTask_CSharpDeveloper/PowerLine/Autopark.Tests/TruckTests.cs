using Autopark.Code;
namespace Autopark.Tests
{
    [TestClass]
    public class TruckTests
    {
        private const Double tolerance = 0.01d;
        #region Constructor tests
        [TestMethod]
        public void Ctor_NegativeParametrValue_ArgumentExceptionreturned()
        {
            try
            {
                Truck truck = new("truck", -2, 40, -23, 4);
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
                Truck truck = new("truck", 0, 40, 17, 4);
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
            Truck truck = new("truck", 15, 40, 17, 4);
            Assert.IsTrue(truck != null);
        }
        #endregion
        #region Properties tests
        [TestMethod]
        public void GetCarType_CarTypeReturned()
        {
            Truck truck = new("truck", 15, 40, 17, 4);
            Assert.AreEqual("truck", truck.GetCatType);
        }
        [TestMethod]
        public void GetAverageFuelConsumption_AverageFuelConsumptionReturned()
        {
            Truck truck = new("truck", 15, 40, 17, 4);
            Assert.AreEqual(15, truck.GetAverageFuelConsumption);
        }
        [TestMethod]
        public void GetTankVolume_TankVolumeReturned()
        {
            Truck truck = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(40, truck.GetTankVolume);
        }
        [TestMethod]
        public void GetSpeed_SpeedReturned()
        {
            Truck truck = new("truck", 15, 40, 17, 4);
            Assert.AreEqual(17, truck.GetSpeed);
        }
        [TestMethod]
        public void GetMaxCargoWeight_MaxCargoWeightReturned()
        {
            Truck truck  = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(4ul, truck.GetMaxCargoWeight);
        }
        [TestMethod]
        public void GetCargoWeight_WhenInstanceCreated_ValueReturned()
        {
            Truck truck = new("passengercar", 15, 40, 17, 5000);
            Assert.AreEqual(0, truck.GetCargoWeight);
        }
        [TestMethod]
        public void GetCargoWeight_WhenCargoAdded_ValueReturned()
        {
            Truck truck = new("truck", 15, 40, 17, 500);
            truck.AddToCar(499);
            Assert.AreEqual(499, truck.GetCargoWeight);
        }
        #endregion
        #region Methods tests
        [TestMethod]
        public void MilesLeft_ArgumentExceptionReturned()
        {
            try
            {
                Truck truck = new("truck", 15, 40, 17, 4);
                truck.MilesLeft(-1);
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
            Truck truck = new("truck", 15, 40, 17, 4);
            Assert.AreEqual(truck.MilesLeft(30), 2, tolerance);
        }
        [TestMethod]
        public void PowerReserve_ValueReturned()
        {
            Truck truck = new("truck", 15, 40, 17, 500);
            Assert.AreEqual(truck.PowerReserve(truck.GetTankVolume, 450), 2.45d, tolerance);
        }
        [TestMethod]
        public void Time_MoreThanPowerReverse_ValueReturned()
        {
            Truck truck = new("truck", 15, 40, 17, 500);
            Assert.AreEqual(truck.Time(truck.GetTankVolume, 430), 0.156d, tolerance);
        }
        [TestMethod]
        public void Time_LessThanPowerReserve_ValueReturned()
        {
            Truck passengerCar = new("passengercar", 15, 40, 17, 4);
            Assert.AreEqual(passengerCar.Time(passengerCar.GetTankVolume, 2), 0.117d, tolerance);
        }
        [TestMethod]
        public void IsCarHasEmprtySpace_TrueReturned()
        {
            Truck passengerCar = new("passengercar", 15, 40, 17, 500);
            Assert.IsTrue(passengerCar.IsCarHasEmprtySpace(499));
        }
        [TestMethod]
        public void IsCarHasEmprtySpace_FalseReturned()
        {
            Truck passengerCar = new("passengercar", 15, 40, 17, 500);
            Assert.IsFalse(passengerCar.IsCarHasEmprtySpace(600));
        }
        #endregion
    }
}