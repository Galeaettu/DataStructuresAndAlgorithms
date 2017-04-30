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

        /// <summary>
        /// Adapted from https://gist.github.com/mikedugan/8249637
        /// </summary>
        /// <param name="a">The array to be shuffled</param>
        /// <returns>A shuffled array using Fisher-Yates</returns>
        public int[] Shuffle(int[] a)
        {
            int[] shuffled = a;

            // go through array, starting at the last-index
            for (var i = shuffled.Length - 1; i >= 0; i--)
            {
                var swapIndex = random.Next(i);         // get num between 0 and index, index not included
                if (swapIndex == i) continue;           // don't replace with itself
                var temp = shuffled[i];                 // get item at index i...
                shuffled[i] = shuffled[swapIndex];      // set index i to new item
                shuffled[swapIndex] = temp;             // place temp-item to swap-slot
            }

            return shuffled;
        }
    }
}
