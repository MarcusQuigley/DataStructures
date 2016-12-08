using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting_Algorithms
{
    class BaseSort<T> where T : IComparable<T>
    {
        internal void DisplayArray(T[] array)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
