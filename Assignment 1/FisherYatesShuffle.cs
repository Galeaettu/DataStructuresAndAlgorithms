using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// The Fisher-Yates Shuffle
    /// </summary>
    public class FisherYatesShuffle
    {
        /// <summary>
        /// The random number provider
        /// </summary>
        protected IRandomProvider random;

        /// <summary>
        /// The default constructor uses the inbuilt Random class
        /// </summary>
        public FisherYatesShuffle()
        {
            random = new RandomAdapter();
        }

        /// <summary>
        /// This constructor allows for the programmer using the FisherYatesShuffle class to inject a dependancy
        /// </summary>
        /// <param name="random">This instance represents a dependancy that is injected. 
        /// The instance that implements the IRandomProvider interface will be used to provide random numbers.</param>
        public FisherYatesShuffle(IRandomProvider random)
        {
            this.random = random;
        }
    }
}
