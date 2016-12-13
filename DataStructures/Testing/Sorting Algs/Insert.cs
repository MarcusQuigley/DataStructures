using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing.Sorting_Algs
{
    class Insert<T>
        where T: IComparable<T>
    {

        public void Sort(T[] items)
        {
            int sortedIndex = 1;
            for (int i = 1; i < items.Length; i++)
            {
                if (items[i].CompareTo(items[i - 1]) < 1)
                {
                    T[] tempArray=new T[sortedIndex];
                    Array.Copy(items, 0, tempArray, 0, sortedIndex);
                    int indexToPlace = FindIndex(tempArray, items[i]);
                    T tempItem = items[i];
                    Array.Copy(items, indexToPlace, items, indexToPlace + 1,   sortedIndex -indexToPlace);
                    items[indexToPlace] = tempItem;
                }
                sortedIndex++;
            }

        }

        private int FindIndex(T[] tempArray, T t)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i].CompareTo(t) > 0)
                    return i;
            }
            throw new InvalidOperationException();
        }
    }
}
