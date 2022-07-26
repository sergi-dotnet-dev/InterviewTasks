using Autopark.Abstract.Interfaces;
using System;
namespace Autopark.Code
{

    public class Truck : CarBase, ICarrier
    {
        private UInt32 _cargoWeight = 0;
        private readonly UInt32 _maxCargoWeight;

        public UInt32 GetMaxCargoWeight => _maxCargoWeight;

        public Single GetCargoWeight => _cargoWeight;
        public Truck(String carType, Single averageFuelConsumption, UInt16 tankVolume, Single speed, UInt32 maxCargoWeight)
            : base(carType, averageFuelConsumption, tankVolume, speed)
            => _maxCargoWeight = maxCargoWeight;
        public override Double PowerReserve(Double currentTankVolume, UInt32 cargo)
        {
            UInt32 percent = cargo / 200;
            var decreaseFactor = percent * 4;
            return base.PowerReserve(currentTankVolume, decreaseFactor);
        }

        public override Double Time(Double currentTankVolume, Double distance)
        {
            if (distance > base.PowerReserve(currentTankVolume, _cargoWeight))
                return base.PowerReserve(currentTankVolume, _cargoWeight) / _speed;
            return base.Time(currentTankVolume, distance);
        }

        public Boolean IsCarHasEmprtySpace(UInt16 obj)
        {
            if (_cargoWeight + obj > _maxCargoWeight)
                return false;
            return true;
        }

        public void AddToCar(UInt16 obj)
        {
            if (IsCarHasEmprtySpace(obj))
                _cargoWeight += obj;
        }
    }
}