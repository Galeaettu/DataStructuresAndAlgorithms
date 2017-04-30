using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Sections
{
    /// <summary>
    /// Section 1
    /// Implement and apply the Fisher-Yates shuffle
    /// </summary>
    class SectionOne
    {
        public SectionOne()
        {

        }

        /// <summary>
        /// AlmostOrdered will return an array of integers that are almost-ordered
        /// </summary>
        /// <param name="n">The length of the array of integers to be returned.</param>
        /// <param name="p">The percentage of numbers in the array that are out of place.</param>
        /// <returns>An array of n numbers, 1 to n (no duplicates). (100-p)% of the numbers are in their correct order.
        /// p% of the numbers are out of place.</returns>
        /// <example>If n = 200, and p = 3, then AlmostOrdered produces an array of size 100.
        /// These numbers are sorted, but 3 (or 3%) numbers from the sequence are moved to a different place.</example>
        /// 
        /// Adapted from https://stackoverflow.com/questions/37419736/almost-ordered-not-sorting-the-exact-amount-of-values-i-give-it
        int[] AlmostOrdered(int n, double p)
        {
            IRandomProvider random = new RandomAdapter();

            if (p > 100)
            {
                throw new InvalidOperationException("Cannot shuffle more than 100% of the numbers");
            }

            int shuffled = 0;

            // Create and Populate an array
            int[] array = new int[n];
            for (int i = 1; i <= n; i++)
            {
                array[i - 1] = i;
            }

            // Calculate numbers to shuffle
            int numsOutOfPlace = (int)Math.Round(n * (p / 100));

            long firstRandomIndex = 0;
            long secondRandomIndex = 0;
            do
            {
                firstRandomIndex = random.Next(n - 1);

                // to make sure that the two numbers are not the same
                do
                {
                    secondRandomIndex = random.Next(n - 1);

                } while (firstRandomIndex == secondRandomIndex);


                int temp = array[firstRandomIndex];
                array[firstRandomIndex] = array[secondRandomIndex];
                array[secondRandomIndex] = temp;

                shuffled++;
            }
            // Shuffles and adds numbers to the array while the length of the array is less than the numbers out of place calculated.
            while (shuffled < numsOutOfPlace);
            return array;
        }
    }
}
