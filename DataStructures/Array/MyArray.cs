using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Arrays
{
    class MyArray<T> : IList<T>
    {
        T[] _items;

        public MyArray():this(0) {}

        public MyArray(int capacity)
        {
            _items = new T[capacity];
        }

        void GrowArray()
        {
            int length = _items.Length == 0 ? 16 : _items.Length << 1;
            T[] newArray = new T[length];
            _items.CopyTo(newArray, 0);
            _items = newArray;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            if (Count == _items.Length)
                GrowArray();
            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();

            int shiftStart = index + 1;
          //  if (shiftStart < Count)
            {
                Array.Copy(_items, shiftStart, _items, index, Count - shiftStart);
            }
            Count--;

        }

        public T this[int index]
        {
            get
            {
                if (index > Count)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index > Count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
                GrowArray();

            _items[Count++] = item;
        }

        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        public bool Contains(T item)
        {
            return (IndexOf(item) != -1);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //for (int i = 0; i < Count; i++)
            //{
                
            //    array[arrayIndex++] = _items[i];
            //}

            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    //Array.Copy(_items, i + 1, _items, i, Count - i);
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
