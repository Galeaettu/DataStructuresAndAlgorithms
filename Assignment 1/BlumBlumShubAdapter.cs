using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// An adapter for the inbuilt class
    /// This allows the BlumBlumShub class to be used with the IRandomProvider Interface
    /// </summary>
    public class BlumBlumShubAdapter : IRandomProvider
    {
        /// <summary>
        /// The aggregated BlumBlumShub Class
        /// </summary>
        protected BlumBlumShub r = new BlumBlumShub();

        /// <summary>
        /// The Next method is used as an adapter for the BlumBlumShub Class
        /// </summary>
        /// <param name="maxValue">The maximum value, not inclusive</param>
        /// <returns>A number, generated using the RNG between 0 and maximum (non-inclusive)</returns>
        public long Next(int maxValue)
        {
            return (long)r.Next(maxValue);
        }
    }
}
