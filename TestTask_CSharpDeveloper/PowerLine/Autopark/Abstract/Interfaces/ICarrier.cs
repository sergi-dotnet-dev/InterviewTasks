using System;

namespace Autopark.Abstract.Interfaces
{
    /// <summary>
    /// Carrier contract represents car methods 
    /// </summary>
    public interface ICarrier
    {
        /// <summary>
        /// Checks that cat can to add another thing after instance
        /// </summary>
        /// <param name="obj">Passengers count to add</param>
        /// <returns></returns>
        Boolean IsCarHasEmprtySpace(UInt16 obj);
        /// <summary>
        /// Add something to car
        /// </summary>
        /// <param name="obj">Objects count to add</param>
        void AddToCar(UInt16 obj);
    }
}
