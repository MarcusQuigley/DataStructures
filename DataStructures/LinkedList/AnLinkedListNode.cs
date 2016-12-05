using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    class AnLinkedListNode<T>
    {
        public AnLinkedListNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; internal set; }
        public AnLinkedListNode<T> Next { get; internal set; }
    }
}
