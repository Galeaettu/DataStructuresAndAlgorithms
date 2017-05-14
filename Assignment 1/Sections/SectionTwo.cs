using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Sections
{
    public class SectionTwo
    {
        BlumBlumShub blumBlumShub;
        AlgorithmBShuffling randomShuffle;
        FisherYatesShuffle fisherYatesShuffle;
        int[,] shuffledArray;
        int[] uniqueNumbers;

        public SectionTwo()
        {
            // Blum Blum Shub RNG
            blumBlumShub = new BlumBlumShub();

            // Randomizing by shuffling, Algorithm B, by defualt using original RNG
            randomShuffle = new AlgorithmBShuffling(blumBlumShub);

            // Fisher-Yates Shuffle with Blum Blum Shub RNG
            fisherYatesShuffle = new FisherYatesShuffle(randomShuffle);
        }


        //The FisherYatesShuffle implemented in Task 1 has an overloaded constructor that accepts a
        //random number generator as parameter. Use the FisherYatesShuffle and pass the random
        //number generator implemented in task 1 as parameter, to shuffle the sequence 1,2,3,4 for
        //24,000 times.
        int[,] shuffleNumbers()
        {
            var shuffleNum = 24000;
            int[] numArray = { 1, 2, 3, 4 };
            int[,] shuffledArrays = new int[shuffleNum, numArray.Length];
            for (int i = 0; i < shuffleNum; i++)
            {
                var shuffledArray = fisherYatesShuffle.Shuffle(numArray);
                //store every number of the generate array into a dimesion of the 2d array
                for (int j = 0; j < shuffledArray.Length; j++)
                {
                    shuffledArrays[i, j] = shuffledArray[j];
                }
            }
            return shuffledArrays;
        }


        int generatePermutationUnqiueNumber(int permutationIndex)
        {
            // Gets the shuffled array if it was not created
            if (shuffledArray == null)
            {
                shuffledArray = shuffleNumbers();
            }
            int[] permutation = getSingleArray(permutationIndex, shuffledArray);
            int t = shuffledArray.GetLength(1);

            //Step 1:
            //r = t, f = 0
            int r = t;
            int f = 0;

            int s = 0;


            //Find the maximum value in the permutation between positions 0 and r-1.
            do
            {
                //Step 2:
                int largeNum = 0;
                for (int i = 0; i < r; i++)
                {
                    //Let s represent the position of the maximum value found (and therefore, 0 <= s <= r-1).
                    if (largeNum < permutation[i])
                    {
                        largeNum = permutation[i];
                        s = i;
                    }
                }

                f = r * f + s;

                //Step 3:
                //Swap the item in position s with the item in position r – 1
                int tempS = permutation[s];
                permutation[s] = permutation[r - 1];
                permutation[r - 1] = tempS;
                r = r - 1;
            } while (r > 1);//Step 4:
            //r = r -1
            //if ( r > 1 ) GOTO Step 2 else return the value f as the result
            return f;
        }


        /// <summary>
        /// Returns the number time that a number between 1 and 24 is visible
        /// </summary>
        /// <returns>Occurance number</returns>
        private int[] numberOfOccurances()
        {

            int possibleCombinations = 24;
            int[] occured = new int[possibleCombinations];

            foreach (var number in uniqueNumbers)
            {
                //increase occurance number of number
                occured[number]++;
            }
            return occured;
        }


        //A chi-square test for independence can be carried out to try to determine if the Fisher Yates
        private float chiSquareTest()
        {
            if (uniqueNumbers == null)
            {
                uniqueNumbers = genrateUniqueNumbers();
            }
            int[] f = numberOfOccurances();

            float x = 0f;
            float p = (1f / 24f);
            
            //for each possible value of f
            for (int i = 0; i <= 23; i++)
            {
                x += (float)(Math.Pow(f[i], 2) / p);
            }
            x = (x / 24000) - 24000;
            return x;
        }

        //For each of the 24,000 repetitions, calculate the value f as shown above and store the
        //frequency of the f i.e. the number of times each of the 24 possible values for f has been
        //returned by the algorithm.
        int[] genrateUniqueNumbers()
        {
            int[] numbers = new int[shuffledArray.GetLength(0)];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = generatePermutationUnqiueNumber(i);
            }
            return numbers;
        }



        //Returns a single int[] array from a 2D array at the specifed position
        private int[] getSingleArray(int position, int[,] twoDarray)
        {
            if (position > twoDarray.GetLength(0))
            {
                throw new Exception("2D Array does not contain the specifed index");
            }

            int[] array = new int[twoDarray.GetLength(1)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = twoDarray[position, i];
            }
            return array;
        }

        public void main()
        {
            Console.Write("Sectio Two" +
                          " \n   Testing Blum Blum Shub Numbers : " + blumBlumShub.Next(100) + " , " + blumBlumShub.Next(100) + " , " + blumBlumShub.Next(100) +
                          ".\n   Testing Random Shuffle : " + blumBlumShub.Next(100) + " , " + blumBlumShub.Next(100) + " , " + blumBlumShub.Next(100) +
                          ".\n   Testing unique value for permutation at index 5 : " + generatePermutationUnqiueNumber(5) +
                          "\n    ChiTest Value " + chiSquareTest());
        }
    }
}
