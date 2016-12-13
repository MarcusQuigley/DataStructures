using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing.Tree
{
    class TreeNode<T> : IComparable<T>
        where T : IComparable<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value {get;private set;}
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }

        public int CompareTo(T other)
        {
            return this.Value.CompareTo(other);
        }
    }
}
