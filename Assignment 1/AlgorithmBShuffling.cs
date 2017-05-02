using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class AlgorithmBShuffling : IRandomProvider
    {
        private IRandomProvider random;
		private const uint vSize = 61;
		private long[] V;
		private long currentMaxValue = 0; 

		public AlgorithmBShuffling(){
			this.random = new RandomAdapter(); // using the orignial RNG by defualt
		}


        public AlgorithmBShuffling(IRandomProvider random)
		{
			this.random = random;
		}

		/// <summary>
		/// Generates an array V of size 61 (Step 2)
		/// </summary>
		/// <param name="maxValue">The maximum non-inclusive random number</param>
        private void generateVArray(int maxValue){
			currentMaxValue = maxValue;
            // Step 1: Create an array V of numbers of size 61
			V = new long[vSize];
			for (int i = 0; i < vSize; i++) {
				V [i] = random.Next(maxValue);	
			}

		}

		public long Next (int maxValue)
		{
			if (V == null || maxValue != currentMaxValue) {//incase the maxValue changes we need to repopulate the array
				generateVArray(maxValue);
			}
			// Step 3: Generate the next random number from the original RNG: Y
			long Y = random.Next(maxValue); 

			// Step 4: Let y = Math.Floor(61 ∗ Y / 2^31)
			long y = (long)Math.Floor((61*Y)/(Math.Pow(2,31)));
			
            // Step 5: Return V[y] and assign V[y] = Y
			long temp = V[y];
			V [y] = Y;
			return temp;

			// Step 6: Goto step 3.
		}
    }
}
