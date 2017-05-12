using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class HeapElement<T> where T : IComparable
    {
        public int priority { get; set; }
        public T value { get; set; }

        public HeapElement(int priority, T value)
        {
            this.priority = priority;
            this.value = value;
        }
    }
}
