using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing
{
    class MyArray2<T> : IList<T>
    {
        T[] _items;
        public MyArray2() :this(0) { }

        public MyArray2(int capacity)
        {
            _items = new T[capacity];
        }

        void GrowList()
        {
            int currentLength = _items.Length == 0 ? 16 : _items.Length << 1;
            T[] temp = new T[currentLength];
            _items.CopyTo(temp, 0);
            _items = temp; 
        }


        public T this[int index]
        {
            get
            {
                if (index > _items.Length)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index > _items.Length)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public int Count
        {
            get;private set;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
                GrowList();
            _items[Count++] = item;
         }

        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        public bool Contains(T item)
        {
             
            return (IndexOf(item)!=-1);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                yield return _items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index > _items.Length)
                throw new IndexOutOfRangeException();
            if (Count + 1 > _items.Length)
                GrowList();

            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            //if (!Contains(item)) return false;
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    //Array.Copy(_items,i,_items,i-1,Count-1);
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > Count)
                throw new IndexOutOfRangeException();

            Array.Copy(_items,index+1,_items,index, Count-index);
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
