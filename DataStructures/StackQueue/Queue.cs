using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.StackQueue
{
    class Queue<T>
    {
        MyLinkedList<T> _queue;

        public Queue()
        {
           _queue = new MyLinkedList<T>(); 
        }

        public void Enqueue(T item)
        {
            _queue.Add(item);
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException();

            T item = _queue.Head.Value;
            _queue.RemoveFirst();
            return item;
         }

        public T Peek()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException();

            return _queue.Head.Value;
        }

        public int Count
        {
            get { return _queue.Count; }
        }
    }
}
