using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T value)
        {
            this.Value = value;
        }

        public DoubleLinkedListNode<T> Previous { get; internal set; }
        public DoubleLinkedListNode<T> Next { get; internal set; }
        public T Value;
    }
}
