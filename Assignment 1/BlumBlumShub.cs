using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Reference: https://github.com/Evangielis/ModifiedBlumBlumShub/blob/master/ModifiedBlumBlumShub/BBSGenerator.cs
    /// </summary>
    public class BlumBlumShub : IRandomProvider
    {
        private const long p = 3263849;
        private const long q = 3263849;
        private const long seed = 6367859;

        private long m;
        private long state;

        public BlumBlumShub()
        {
            m = p * q;
            state = seed;
        }

        /// <summary>
        /// This output is used to construct integers.
        /// </summary>
        /// <returns>The next byte (0 or 1) according to the seed and the equation </returns>
        public bool NextByte()
        {
            var x = this.state;
            var next = x * x % this.m;
            this.state = next;
            return next % 2 == 0;
        }

        //https://stackoverflow.com/questions/680002/find-out-number-of-bits-needed-to-represent-a-positive-integer-in-binary
        /// <summary>
        /// Calculates the required number of bits needed to store an integer
        /// </summary>
        /// <param name="value">Number of bits needed to store an integer</param>
        /// <returns></returns>
        private int numberOFBits(int value)
        {
            int count = 0;
            while (value > 0)
            {
                count++;
                value = value >> 1;
            }
            return count;
        }


        //https://stackoverflow.com/questions/5283180/how-can-i-convert-bitarray-to-single-int
        /// <summary>
        /// Returns an integer value from an array of bits
        /// </summary>
        /// <param name="bitArray">An array of 1s and 0s</param>
        /// <returns></returns>
        private int getIntFromBits(BitArray bitArray)
        {
            int value = 0;
            for (int i = 0; i < bitArray.Count; i++)
            {
                if (bitArray[i])
                    value += Convert.ToInt32(Math.Pow(2, i));
            }

            return value;
        }

        /// <summary>
        /// Generates a random number from random bits
        /// </summary>
        /// <param name="max">The maximum number (non inclusive) that the random number generated will be</param>
        /// <returns></returns>
        public long Next(int max)
        {
            
            int requiredBits = numberOFBits(max);
            BitArray bytes = new BitArray(requiredBits);
            int currentValue = max + 1;
            while (currentValue > max)
            {
                for (int i = 0; i < requiredBits; i++)
                {
                    bool randomBit = NextByte();
                    bytes[i] = randomBit;
                }
                currentValue = getIntFromBits(bytes);
            }

            return currentValue;
        }        
    }
}
