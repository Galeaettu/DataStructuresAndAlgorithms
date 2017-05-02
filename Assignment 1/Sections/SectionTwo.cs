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
        int[] unqiueNumbers;

        public SectionTwo()
        {
            blumBlumShub = new BlumBlumShub();//implement Blum Blum Shub random generator
            randomShuffle = new AlgorithmBShuffling(blumBlumShub);//Randomizing by shuffling, Algorithm B, by defualt using original RNG

            fisherYatesShuffle = new FisherYatesShuffle(randomShuffle);//using the FisherYatesShuffle with blumBlumShub random gen
        }


        //The FisherYatesShuffle implemented in Task 1 has an overloaded constructor that accepts a
        //random number generator as parameter. Use the FisherYatesShuffle and pass the random
        //number generator implemented in task 1 as parameter, to shuffle the sequence 1,2,3,4 for
        //24,000 times.
        int[,] shuffle1234()
        {
            var numberOfShuffleing = 24000;
            int[] array = { 1, 2, 3, 4 };
            int[,] shuffledArrays = new int[numberOfShuffleing, array.Length];
            for (int i = 0; i < numberOfShuffleing; i++)
            {
                var shuffledArray = fisherYatesShuffle.Shuffle(array);
                //store every number of the generate array into a dimesion of the 2d array
                for (int i2 = 0; i2 < shuffledArray.Length; i2++)
                {
                    shuffledArrays[i, i2] = shuffledArray[i2];
                }
                //printArray (shuffledArray);

            }
            return shuffledArrays;
        }


        int generatePermutationUnqiueNumber(int premuationIndex)
        {
            if (shuffledArray == null)
            {
                shuffledArray = shuffle1234();//holds 24000 diffrent combinations of [1,2,3,4]
            }
            int[] premutation = getOneDFromTwoD(premuationIndex, shuffledArray);//{shuffledArray[0,0],shuffledArray[0,1],shuffledArray[0,2],shuffledArray[0,3]}; 
            int t = shuffledArray.GetLength(1);//get the length of the second dimesion that is to say 4

            //Step 1:
            //r = t, f = 0
            int r = t;
            int f = 0;
            int s = 0;//s is required for steop 2


            //Find the maximum value in the permutation between positions 0 and r-1.
            do
            {
                //Step 2:
                int tempBiggestPos = 0;
                for (int i = 0; i < r; i++)
                {//removing r-1,seemes to solve the issue
                    //Let s represent the position of the maximum value found (and therefore, 0 <= s <= r-1).
                    if (tempBiggestPos < premutation[i])
                    {
                        tempBiggestPos = premutation[i];
                        s = i;
                    }
                }
                //f = r * f + s
                f = r * f + s;

                //Step 3:
                //Swap the item in position s with the item in position r – 1
                int tempS = premutation[s];
                premutation[s] = premutation[r - 1];
                premutation[r - 1] = tempS;
                r = r - 1;
            } while (r > 1);//Step 4:
            //r = r -1
            //if ( r > 1 ) GOTO Step 2 else return the value f as the result
            return f;
        }


        /**
         * Stores the number of time a given value (1..24) presents itself
         * */
        private int[] numberOfOccurances()
        {

            int possibleCombinations = 24;
            int[] occured = new int[possibleCombinations];

            foreach (var number in unqiueNumbers)
            {
                occured[number]++;
            }
            return occured;
        }


        //A chi-square test for independence can be carried out to try to determine if the Fisher Yates
        //Algorithm is biased and tends to return a particular permutation more often than others.
        private float chiSquareTest()
        {
            if (unqiueNumbers == null)
            {
                unqiueNumbers = genrateUnqiueNumbers();
            }
            int[] f = numberOfOccurances();

            float x = 0f;
            float p = (1f / 24f);
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
        int[] genrateUnqiueNumbers()
        {
            int[] numbers = new int[shuffledArray.GetLength(0)];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = generatePermutationUnqiueNumber(i);
                //Console.WriteLine (i + ": " + numbers [i]);
            }
            return numbers;
        }



        //Returns a single int[] array from a 2D array at the specifed position
        private int[] getOneDFromTwoD(int position, int[,] twoDarray)
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
                          ".\n   Testing Random Shuiffle : " + blumBlumShub.Next(100) + " , " + blumBlumShub.Next(100) + " , " + blumBlumShub.Next(100) +
                          ".\n   Testing unqiuue value for premuation at index 5 : " + generatePermutationUnqiueNumber(5) +
                          "\n    ChiTest Value " + chiSquareTest());
            //genrateUnqiueNumbers ();

            //printArray(shuffle1234 ());
        }
    }
}
