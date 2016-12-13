using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing.LinkedList
{
    class MyLinkedList<T> : ICollection<T>
    {
        MyLsitNode<T> _head;
        MyLsitNode<T> _tail;

        public int Count
        {
            get; private set;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            MyLsitNode<T> node = new MyLsitNode<T>(item);
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }
            _tail = node;
            Count++;
        }

        public void AddOLD(T item)
        {
            MyLsitNode<T> currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Next == null)
                {
                    currentNode.Next = new MyLsitNode<T>(item);
                    return;
                }
                else
                    currentNode = currentNode.Next;
            }
        }


        public bool Remove(T item)
        {
            MyLsitNode<T> previousNode = null;
            MyLsitNode<T> currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                        if (currentNode.Next == null)
                            _tail = previousNode;
                    }
                    else //removing head
                    {
                        _head = _head.Next;
                        if (_head == null) //head was only entry in list
                            _tail = null;
                    }

                    Count--;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public bool Remove1(T item)
        {
            MyLsitNode<T> previousNode = null;
            MyLsitNode<T> currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previousNode != null) //currentNode is not head
                    {
                        previousNode.Next = currentNode.Next;
                        if (currentNode.Next == null) //tail  
                            _tail = null;
                    }
                    else//head 
                    {
                        _head = _head.Next;
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    return true;
                    Count--;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            MyLsitNode<T> currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Next.Value.Equals(item))
                    return true;

                currentNode = currentNode.Next;
            }
            return false;
        }
        //
        // Summary:
        //     Copies the elements of the System.Collections.Generic.ICollection`1 to an System.Array,
        //     starting at a particular System.Array index.
        //
        // Parameters:
        //   array:
        //     The one-dimensional System.Array that is the destination of the elements copied
        //     from System.Collections.Generic.ICollection`1. The System.Array must have zero-based
        //     indexing.
        //
        //   arrayIndex:
        //     The zero-based index in array at which copying begins.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     array is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     arrayIndex is less than 0.
        //
        //   T:System.ArgumentException:
        //     The number of elements in the source System.Collections.Generic.ICollection`1
        //     is greater than the available space from arrayIndex to the end of the destination
        //     array.
        public void CopyTo(T[] array, int arrayIndex)
        {
            MyLsitNode<T> currentNode = _head;
            while (currentNode != null)
            {
                array[arrayIndex++] = currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyLsitNode<T> currentNode = _head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
 
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
