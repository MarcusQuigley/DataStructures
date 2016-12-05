using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    class MyLinkedList<T> :ICollection<T>
    {
        private AnLinkedListNode<T> head;
        private AnLinkedListNode<T> tail;

        public void Add(T item)
        {
            AddLast(item);   
        }

        public void AddLast(T item)
        {
            AnLinkedListNode<T> node = new AnLinkedListNode<T>(item);
            if (head == null) //empty list
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;
            Count++;
        }

        public void AddFirst(T item)
        {
            AnLinkedListNode<T> node = new AnLinkedListNode<T>(item);
            if (head == null)
            {
                //head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                //head = node;
            }
            head = node;
            Count++;

        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            AnLinkedListNode<T> node = head;
            while (node!=null)
            {
                if (node.Value.Equals(item))
                    return true;
                node = node.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            AnLinkedListNode<T> node = head;
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
            AnLinkedListNode<T> node = head;
            AnLinkedListNode<T> previous = null;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    if (previous == null)//first list element
                    {
                        head =null;
                        tail = null;
                    }
                    else
                    {
                        if (node.Next == null) //last list element
                        {
                            previous.Next = null;
                            tail = previous;
                        }
                        else //middle.. list element
                        {
                            previous.Next = node.Next;
                        }
                    }

                    Count--;
                    return true;
                }
                //else
                previous = node;
                node = node.Next;

            }
            return false;
        }

        public bool RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
                if (head == null)
                    tail = null;
                Count--;
                return true;
            }
            return false;
        }

        public bool RemoveLast()
        {
            if (head != null)
            {
                AnLinkedListNode<T> node = head;
                AnLinkedListNode<T> previous = null;
                while (node != null)
                {
                    if (node.Next == null)
                    {
                        if (previous == null)
                        {
                            head = null;
                            tail = null;
                        }
                        else
                        {
                            previous.Next = null;
                            tail = previous;
                        }
                        Count--;
                        return true;
                    }
                    previous = node;
                    node = node.Next;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            AnLinkedListNode<T> node = head;
              while (node != null)
              {
                  yield return node.Value;
                  node = node.Next;
              }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
