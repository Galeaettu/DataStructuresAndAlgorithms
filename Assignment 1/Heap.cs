using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Adapted from: 
    /// -    https://miafish.wordpress.com/2015/03/16/c-min-heap-implementation/
    /// -    https://en.wikipedia.org/wiki/Binary_heap#Heap_operations
    /// -    http://www.algorithmist.com/index.php/Heap_sort
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> where T : IComparable
    {
        HeapElement<T>[] elements;
        int heapSize;

        public HeapElement<T>[] Elements { get { return elements; } }

        //public int currentHeapSize = 0;

        public Heap(int heapSize)
        {
            elements = new HeapElement<T>[heapSize];

            buildHeap();
            //HeapElement
        }

        /// <summary>
        /// This constuctor will populate the heap with the values of the array giving them the same priority has the size of their value
        /// </summary>
        /// <param name="array">Array. Of objects</param>
        public Heap(T[] array)
        {
            heapSize = array.Length;
            elements = new HeapElement<T>[heapSize];
            int i = 0;
            foreach (var item in array)
            {
                elements[i] = new HeapElement<T>(Convert.ToInt32(item), item);
                i++;
            }
        }

        /// <summary>
        /// This array will contain a priority which satisfies the priority queue
        /// </summary>
        /// <param name="array">Array. of heapElement each element containg a value and a priority</param>
        public Heap(HeapElement<T>[] array)
        {
            elements = array;
        }

        public T[] sortHeap()
        {
            buildHeap();
            int n = elements.Length - 1;
            for (int i = n; i >= 0; i--)
            {
                swap(0, i);
                //n = n - 1;
                Heapify(0, i - 1);
            }

            return heapElementsToArray();
        }


        private T[] heapElementsToArray()
        {
            T[] values = new T[elements.Length];
            int i = 0;
            foreach (var item in elements)
            {
                values[i] = item.value;
                i++;
            }
            return values;
        }

        public HeapElement<T>[] buildHeap()
        {
            int n = elements.Length - 1;
            int start = (int)Math.Floor((double)(n / 2));
            for (int i = start; i >= 0; i--)
            {
                Heapify(i, n);
            }
            return Elements;
        }

        private void Heapify(int i, int n)
        {
            int left = 2 * i;
            int right = 2 * i + 1;
            int max, min = 0;

            if (left <= n && elements[left].priority > elements[i].priority)
            {
                max = left;
            }
            else
            {
                max = i;
            }

            if (right <= n && elements[right].priority > elements[max].priority)
            {
                max = right;
            }

            if (max != i)
            {
                swap(i, max);
                Heapify(max, n);
            }
        }

        private void swap(int a, int b)
        {
            var temp = elements[a];
            elements[a] = elements[b];
            elements[b] = temp;
        }

    }
}
