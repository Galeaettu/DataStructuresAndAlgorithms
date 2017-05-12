using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Adapted from http://algorithmist.com/index.php/Merge_sort
    /// </summary>
    public class MergeSort<T> where T : IComparable
    {
        T[] array;
        public MergeSort(T[] array)
        {
            this.array = array;
        }


        public T[] sort()
        {
            return mergesort(array);
        }


        private T[] mergesort(T[] a)
        {
            int n = a.Length;
            if (n == 1) return a;

            T[] l1 = splitArray(a, 0, (n / 2));
            T[] l2 = splitArray(a, (n / 2), n);

            l1 = mergesort(l1);
            l2 = mergesort(l2);

            return merge(l1, l2);
        }

        T[] merge(T[] a, T[] b)
        {
            T[] c = new T[a.Length + b.Length];
            int sizeOfA = a.Length, sizeOfB = b.Length;

            int cIndex = 0, aIndex = 0, bIndex = 0;
            while (sizeOfA > 0 && sizeOfB > 0)
            {
                if (a[aIndex].CompareTo(b[bIndex]) > 0)
                {
                    c[cIndex] = b[bIndex];
                    b[bIndex] = default(T);
                    sizeOfB--;
                    bIndex++;
                }
                else
                {
                    c[cIndex] = a[aIndex];
                    a[aIndex] = default(T);
                    sizeOfA--;
                    aIndex++;
                }
                cIndex++;

            }

            foreach (var item in a)
            {
                if (!item.Equals(default(T)))
                {
                    c[cIndex] = item;
                    cIndex++;
                }
            }

            foreach (var item in b)
            {
                if (!item.Equals(default(T)))
                {
                    c[cIndex] = item;
                    cIndex++;
                }
            }
            return c;
        }




        private T[] splitArray(T[] array, int start, int end)
        {
            T[] splitedArray = new T[end - start];
            int count = 0;
            for (int i = start; i < end; i++)
            {
                splitedArray[count] = array[i];
                count++;
            }
            return splitedArray;
        }
    }
}
