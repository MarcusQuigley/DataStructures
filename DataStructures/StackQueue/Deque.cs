using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.StackQueue
{
    class Deque<T>
    {
        DoubleLinkedList<T> _items = new DoubleLinkedList<T>();

        public void EnqueueFirst(T value)
        {
            _items.AddFirst(value);
        }

        public void EnqueueLast(T value)
        {
            _items.AddLast(value);
        }

        public T DequeueFirst()
        {
            if (_items.Count==0)
                throw new InvalidOperationException();

            T value = _items.Head.Value;
            _items.RemoveFirst();
            return value;
        }

        public T DequeueLast()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException();

            T value = _items.Tail.Value;
            _items.RemoveLast();
            return value;
        }

        public T PeekFirst()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException();

            return _items.Head.Value;
        }

        public T PeekLast()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException();

            return _items.Tail.Value;
        }

        public int Count {
            get { return _items.Count; }
        }
    }
}
