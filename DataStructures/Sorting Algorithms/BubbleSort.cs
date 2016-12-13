using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sorting_Algorithms
{
    class BubbleSort<T> : BaseSort<T>
         where T: IComparable<T>
    {

        public void Sort(T[] items)
        {
            bool isSorted = false;
            while (isSorted == false)
            {
                isSorted = true;
                for (int i = 0; i < items.Length - 1; i++)
                {
                     if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        Swap(items, i, i + 1);
                        isSorted = false;
                    }
                }
                DisplayArray(items);
            }

            
        }


        //void DisplayArray(T[] array)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        Console.Write("{0} ", array[i]);
        //    }
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine();
        //}

        void Swap(T[] items, int item1, int item2)
        {
           if (item1 != item2)
            {
                T temp = items[item1];
                items[item1] = items[item2];
                items[item2] = temp;
            }
        }
    }
}
