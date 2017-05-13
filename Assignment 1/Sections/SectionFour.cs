using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Assignment_1.Sections
{
    public class SectionFour : Section
    {
        public SectionFour()
        {

        }

        private int[] generateArray(int arraySize, bool random)
        {
            var r = new Random();
            int[] array = new int[arraySize];
            for (int i = 0; i < array.Length; i++)
            {
                if (random)
                {
                    array[i] = r.Next(1000);
                }
                else
                {
                    array[i] = i;
                }
            }
            return array;
        }

        public void scenarioOne()
        {
            int[] problemSizes = { 1024, 5120, 25600, 128000 }; ;
            //integers 1 to N shuffled using the Fisher-Yates algorthim 
            for (int i = 0; i < problemSizes.Length; i++)
            {
                int[] array = generateArray(problemSizes[i], false);
                Console.WriteLine("Problem Size " + problemSizes[i] + " : ");
                FisherYatesShuffle fShuffle = new FisherYatesShuffle();
                array = fShuffle.Shuffle(array);
                Stopwatch stopWatch = new Stopwatch();

                //mergeSort testing
                MergeSort<int> mergeS = new MergeSort<int>(array);
                
                long[] runSpeeds = new long[100];
                long runSpeedsSum = 0;
                for (int a = 0; a < runSpeeds.Length; a++)
                {
                    stopWatch.Start();

                    var arraySorted = mergeS.sort();

                    stopWatch.Stop();
                    runSpeeds[i] = stopWatch.ElapsedTicks;
                    runSpeedsSum += runSpeeds[i];
                }

                //avreage
                Console.WriteLine("Merge Sort (Average): " + runSpeedsSum / runSpeeds.Length);
                //heapSort testing
                stopWatch = new Stopwatch();

                //mergeSort testing
                Heap<int> Heap = new Heap<int>(array);
                runSpeeds = new long[100];
                runSpeedsSum = 0;
                for (int a = 0; a < runSpeeds.Length; a++)
                {
                    stopWatch.Start();
                    var arraySorted = Heap.sortHeap();
                    stopWatch.Stop();
                    runSpeeds[i] = stopWatch.ElapsedTicks;
                    runSpeedsSum += runSpeeds[i];
                }



                Console.WriteLine("Heap Sort (Average): " + runSpeedsSum / runSpeeds.Length);
                //bucket Sort
                BucketSort<int> bucketSort = new BucketSort<int>(array);
                runSpeeds = new long[100];
                runSpeedsSum = 0;
                for (int a = 0; a < runSpeeds.Length; a++)
                {
                    stopWatch.Start();
                    var arraySorted = bucketSort.bucketSort();
                    stopWatch.Stop();
                    runSpeeds[i] = stopWatch.ElapsedTicks;
                    runSpeedsSum += runSpeeds[i];
                }

                Console.WriteLine("Bucket Sort (Average): " + runSpeedsSum / runSpeeds.Length);

            }
        }

        public void scenarioTwo()
        {
            int[] problemSizes = { 1024, 5120, 25600, 128000 };
            BlumBlumShub shub = new BlumBlumShub();

            //integers 1 to N shuffled using the Fisher-Yates algorthim 
            for (int i = 0; i < problemSizes.Length; i++)
            {
                long[] randomNumbers = { shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100), shub.Next(100) };
                //minium of 12 numbers
                int min = (int)randomNumbers[0];
                for (int a = 1; a < randomNumbers.Length; a++)
                {
                    if (randomNumbers[a] < min)
                    {
                        min = (int)randomNumbers[a];
                    }
                }

                int[] array = generateArray(min, true);
                Console.WriteLine("Problem Size (randomly chhosen from 12 values) " + problemSizes[i]+ " : ");
                FisherYatesShuffle fShuffle = new FisherYatesShuffle();
                array = fShuffle.Shuffle(array);
                Stopwatch stopWatch = new Stopwatch();

                //mergeSort testing
                MergeSort<int> mergeS = new MergeSort<int>(array);
                long[] runSpeeds = new long[100];
                long runSpeedsSum = 0;
                for (int a = 0; a < problemSizes[i]; a++)
                {
                    stopWatch.Start();
                    mergeS.sort();
                    stopWatch.Stop();
                    runSpeeds[i] = stopWatch.ElapsedTicks;
                    runSpeedsSum += runSpeeds[i];
                }
                //avreage


                Console.WriteLine("Merge Sort (Average): " + runSpeedsSum / runSpeeds.Length);
                //heapSort testing
                stopWatch = new Stopwatch();

                //mergeSort testing
                Heap<int> Heap = new Heap<int>(array);
                runSpeeds = new long[100];
                runSpeedsSum = 0;
                for (int a = 0; a < problemSizes[i]; a++)
                {
                    stopWatch.Start();
                    Heap.sortHeap();
                    stopWatch.Stop();
                    runSpeeds[i] = stopWatch.ElapsedTicks;
                    runSpeedsSum += runSpeeds[i];
                }

                Console.WriteLine("Heap Sort (Average): " + runSpeedsSum / runSpeeds.Length);

                //bucket Sort
                BucketSort<int> bucketSort = new BucketSort<int>(array);
                runSpeeds = new long[100];
                runSpeedsSum = 0;
                for (int a = 0; a < problemSizes[i]; a++)
                {
                    stopWatch.Start();
                    var arraySorted = bucketSort.bucketSort();
                    stopWatch.Stop();
                    runSpeeds[i] = stopWatch.ElapsedTicks;
                    runSpeedsSum += runSpeeds[i];
                }
                Console.WriteLine("Bucket Sort (Average): " + runSpeedsSum / runSpeeds.Length);

            }
        }
    }
}
