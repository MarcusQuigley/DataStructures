using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    class BinaryTreeNode<T> : IComparable<T>
        where T : IComparable<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }
        public T Value { get; private set; }

        public int CompareTo(T other)
        {
            return this.Value.CompareTo(other);
        }
    }
}
