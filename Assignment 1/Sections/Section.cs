using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Sections
{
    public abstract class Section
    {
        public Section()
        {
        }

        protected void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i != array.Length - 1)
                    Console.Write(" , ");
                else
                    Console.Write(" . ");
            }
            Console.WriteLine("");
        }

        protected void printArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\n [");
                for (int i2 = 0; i2 < array.GetLength(1); i2++)
                {
                    Console.Write(array[i, i2]);
                    Console.Write(" , ");

                }
                Console.Write("]");
            }
            Console.WriteLine("");
        }

    }
}
