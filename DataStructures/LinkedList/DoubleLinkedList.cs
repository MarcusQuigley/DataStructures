using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    class DoubleLinkedList<T> : ICollection<T>
    {
        DoubleLinkedListNode<T> _head;
        DoubleLinkedListNode<T> _tail;

        public DoubleLinkedList()
        {

        }

        public DoubleLinkedListNode<T> Head
        {
            get { return _head; }
        }

        public DoubleLinkedListNode<T> Tail
        {
            get { return _tail; }
        }
 
        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(item);
            if (_head == null)
            {
                 _head = node;
                _tail = node;
            }
            else
            {
                node.Next = _head;
                _head.Previous = node;
                _head = node;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(item);
            if (_head == null)//first Item
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }
            Count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            DoubleLinkedListNode<T> node = _head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
           DoubleLinkedListNode<T> node = _head;
           while (node != null)
           {
               array[arrayIndex++] = node.Value;
               node = node.Next;
           }
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
            DoubleLinkedListNode<T> node = _head;
            while (node == null)
            {
                if (node.Value.Equals(item))
                {
                    if (node.Previous == null) //first
                    {
                        node.Next = _head;
                        _head.Previous = null;
                    }
                    else if (node.Next == null) //last
                    {
                        node.Previous = _tail;
                        _tail.Next = null;
                    }
                    else //in middle
                    {
                        node.Previous.Next = node.Next;
                        node.Next.Previous = node.Previous;
                    }
                    Count--;
                    return true;
                }

                node = node.Next;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (_head == null)
                return;

            _head =    _head.Next;
            _head.Previous = null;
            Count--;

        }

        public void RemoveLast()
        {
            if (_head == null)
                return;

            _tail.Previous = _tail;
            _tail.Next = null;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleLinkedListNode<T> node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          //  return ((IEnumerator<T>).this).GetEnumerator();
              return  GetEnumerator();
        }
    }
}
