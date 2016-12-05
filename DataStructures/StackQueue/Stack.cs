using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Stack<T>
    {
        MyLinkedList<T> _stack;

        public Stack()
        {
            _stack = new MyLinkedList<T>();
        }

        public void Push(T item)
        {
            _stack.AddLast(item);
         }

        public T Pop()
        {
            if (_stack.Count > 0)
            {
                T item = _stack.Tail.Value;
              
                    _stack.RemoveLast();
                    return item;
             }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public T Peek()
        {
            if (_stack.Count > 0)
            {
                T item = _stack.Tail.Value;
                return item;
                //if (item != null)
                //    _stack.RemoveLast();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int Count
        {
            get { return _stack.Count; }
        }
    }
}
