using System;
namespace Autopark
{
    /// <summary>
    /// Type represents base car entity
    /// </summary>
    public class CarBase
    {
        protected String _carType;
        protected Single _averageFuelConsumption;
        protected Int32 _tankVolume;
        protected Single _speed;

        public String GetCatType => _carType;
        public Single GetAverageFuelConsumption => _averageFuelConsumption;
        public Int32 GetTankVolume => _tankVolume;
        public Single GetSpeed => _speed;

        protected CarBase(String carType, Single averageFuelConsumption, UInt16 tankVolume, Single speed)
        {
            _carType = carType;
            if (averageFuelConsumption <= 0)
                throw new ArgumentException("Parameter averageFuelConsumption can not be negative or zero");
            _averageFuelConsumption = averageFuelConsumption;
            _tankVolume = tankVolume;
            if (speed <= 0)
                throw new ArgumentException("Parameter speed can not be negative or zero");
            _speed = speed;
        }
        public virtual Double MilesLeft(Double currentTankVolume)
        {
            if (currentTankVolume < 0d) throw new ArgumentException("Parameter currentTankVolume can not be negative");
            if(currentTankVolume > _tankVolume) currentTankVolume = _tankVolume;
            return currentTankVolume / _averageFuelConsumption;
        }
        public virtual Double PowerReserve(Double currentTankVolume, UInt32 decreaseFactor)
        {
            return MilesLeft(currentTankVolume) * (Double)((100d - decreaseFactor) / 100d);
        }
        public virtual Double Time(Double currentTankVolume, Double distance) 
            => distance / _speed;
    }
}