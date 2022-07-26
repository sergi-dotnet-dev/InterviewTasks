using Autopark.Abstract.Interfaces;
using System;

namespace Autopark.Code
{
    public sealed class PassengerCar : CarBase, ICarrier
    {
        private UInt16 _passengersCount = 1;
        private readonly UInt16 _maxPassengerCount;

        public UInt16 GetPassengersCount => _passengersCount;
        public UInt16 GetMaxPassengersCount => _maxPassengerCount;
        public PassengerCar(String carType, Single averageFuelConsumption, UInt16 tankVolume, Single speed, UInt16 maxPassengersCount)
            : base(carType, averageFuelConsumption, tankVolume, speed)
            => _maxPassengerCount = maxPassengersCount;
        public override Double PowerReserve(Double currentTankVolume, UInt32 passengersCount = 1)
        {
            if(passengersCount > _maxPassengerCount) passengersCount = _maxPassengerCount;
            var decreaseFactor = 6 * passengersCount;
            return base.PowerReserve(currentTankVolume, decreaseFactor);
        }

        public override Double Time(Double currentTankVolume, Double distance)
        {
            if (distance > PowerReserve(currentTankVolume, _passengersCount))
                return PowerReserve(currentTankVolume, _passengersCount) /_speed;
            return base.Time(currentTankVolume, distance);
        }
        public Boolean IsCarHasEmprtySpace(UInt16 obj)
        {
            if (_passengersCount + obj > _maxPassengerCount)
                return false;
            return true;
        }
        public void AddToCar(UInt16 obj)
        {
            if (IsCarHasEmprtySpace(obj))
                _passengersCount += obj;
        }
    }
}