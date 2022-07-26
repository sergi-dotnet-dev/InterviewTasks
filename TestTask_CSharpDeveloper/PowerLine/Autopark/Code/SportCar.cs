using Autopark.Abstract.Interfaces;
using System;

namespace Autopark.Code
{
    /// <summary>
    /// Type represents Sport car
    /// </summary>
    public class SportCar : CarBase, ICarrier
    {
        private const UInt16 _maxPassengersCount = 2; 
        private UInt16 _passengersCount;

        /// <summary>
        /// PassengerCount field Get property
        /// </summary>
        public UInt16 GetPassengersCount => _passengersCount;
        /// <summary>
        /// MaxPassengerCount field Get property
        /// </summary>
        public UInt16 GetMaxPassengersCount => _maxPassengersCount;
        /// <summary>
        /// Constructor creates type instance
        /// </summary>
        /// <param name="carType">Automobile type</param>
        /// <param name="averageFuelConsumption">Average fuel are consume by car</param>
        /// <param name="tankVolume">Car tank volume</param>
        /// <param name="speed">Car speed</param>
        public SportCar(String carType, Single averageFuelConsumption, UInt16 tankVolume, Single speed)
            : base(carType, averageFuelConsumption, tankVolume, speed) 
            => _passengersCount = 1;
        /// <summary>
        /// Calculates car power reserve which depends by tank volume and passengers count
        /// </summary>
        /// <param name="currentTankVolume">Car curent tank fill</param>
        /// <param name="passengersCount">Car current passengers</param>
        /// <returns></returns>
        public override Double PowerReserve(Double currentTankVolume, UInt32 passengersCount) 
            => base.PowerReserve(currentTankVolume, passengersCount);
        /// <summary>
        /// Calculates how many hours required to cover the distance
        /// </summary>
        /// <param name="currentTankVolume">Car curent tank fill</param>
        /// <param name="distance">Distance to cover</param>
        /// <returns></returns>
        public override Double Time(Double currentTankVolume, Double distance)
        {
            if (distance> PowerReserve(currentTankVolume, _passengersCount))
                return PowerReserve(currentTankVolume, _passengersCount) / _speed;
            return base.Time(currentTankVolume, distance);
        }
        /// <summary>
        /// Checks that cat can to add another passengers after instance
        /// </summary>
        /// <param name="obj">Passengers count to add</param>
        /// <returns></returns>
        public Boolean IsCarHasEmprtySpace(UInt16 obj)
        {
            if (_passengersCount + obj > _maxPassengersCount)
                return false;
            return true;
        }
        /// <summary>
        /// Add passengers to car
        /// </summary>
        /// <param name="obj">Passengers count to add</param>
        public void AddToCar(UInt16 obj)
        {
            if (IsCarHasEmprtySpace(obj))
                _passengersCount += obj;
        }
    }
}
