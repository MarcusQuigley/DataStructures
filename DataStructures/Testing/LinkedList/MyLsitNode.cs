using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing.LinkedList
{
    class MyLsitNode<T>
    {
        public MyLsitNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get; private set;
        }
        public MyLsitNode<T> Next
        {
            get; set; }

    }
}
