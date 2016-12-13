using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing.Sorting_Algs
{
    class Bubble<T>
        where T : IComparable<T>
    {

        public void Sort(T[] items)
        {

            bool sortHappened = false;

            do
            {
                sortHappened = false;
                for (int i = 0; i < items.Length - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) < 1)
                    {
                        Swap(items, i, i+1);
                        sortHappened = true;
                    }
                }

            }
            while (sortHappened);


        }

        void Swap(T[] items, int first, int second)
        {
            T temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
    }
}
