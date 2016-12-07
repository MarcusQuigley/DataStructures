using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        BinaryTreeNode<T> _head;

        public int Count
        {
            get;
            private set;
        }

        public void Add(T value)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
            if (_head == null)
            {
                _head = newNode;
                Count++;
                return;
            }
            //BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
            //node = _head;

            AddTo(_head, value);

        }

        // Recursive add algorithm. 
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (node.CompareTo(value) > 0) //new node is less
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new BinaryTreeNode<T>(value);
                    Count++;
                }
                else
                    AddTo(node.LeftChild, value);
            }
            else if (node.CompareTo(value) < 0) //new node is greater
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new BinaryTreeNode<T>(value);
                    Count++;
                }
                else
                    AddTo(node.RightChild, value);
            }
        }

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        //finds node as well as parent.
        //parent is used when removing
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> node = _head;
            parent = null;
            while (node != null)
            {
                int result = node.CompareTo(value);
                if (result > 0)//value is less than node
                {
                    parent = node;
                    node = node.LeftChild;
                }
                else if (result < 0) ////value is greater than node
                {
                    parent = node;
                    node = node.RightChild;
                }
                else //equals
                    break;
            }


            return node;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);
            if (current == null)//no node exists
            {
                return false;
            }

            if (current.RightChild == null) //no right child
            {
                if (parent == null) //remove head
                    _head = current.LeftChild;
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0) //parent greater than node
                        parent.LeftChild = current.LeftChild;
                    else if (result < 0)
                        parent.RightChild = current.LeftChild;
                }
            }
            else
            {
                if (current.RightChild.LeftChild == null) //no left of right child
                {
                    if (parent == null)//head
                        _head = current.RightChild;
                    else
                    {
                        int result = parent.CompareTo(current.Value);
                        if (result > 0)  //parent greater than node
                            parent.LeftChild = current.RightChild;
                        else
                            parent.RightChild = current.RightChild;
                    }
                }
                else //has left child of right child. This is the tricky scenario
                {
                    BinaryTreeNode<T> leftmost = current.RightChild.LeftChild;
                    BinaryTreeNode<T> leftmostParent = current.RightChild;
                    while (leftmost.LeftChild != null)
                    {
                        leftmostParent = leftmost;
                        leftmost = leftmost.LeftChild;
                    } // The parent's left subtree becomes the leftmost's right subtree. 
                    leftmostParent.LeftChild = leftmost.RightChild;
                    // Assign leftmost's left and right to current's left and right children. 
                    leftmost.LeftChild = current.LeftChild;
                    leftmost.RightChild = current.RightChild;

                    if (parent == null)//head
                    {
                        _head = leftmost;
                    }
                    else
                    {
                        int result = parent.CompareTo(current.Value);
                        if (result > 0)  //parent greater than node
                            parent.LeftChild = leftmost;
                        else
                            parent.RightChild = leftmost;
                    }
                }
            }
            Count--;
            return true;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.LeftChild);
                PreOrderTraversal(action, node.RightChild);
            }
        }
        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.LeftChild);
                PostOrderTraversal(action, node.RightChild);
                action(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.LeftChild);
                action(node.Value);
                InOrderTraversal(action, node.RightChild);
            }
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //public void AddOld(T value)
        //{
        //    //  BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);

        //    if (_head == null)
        //    {
        //        _head = new BinaryTreeNode<T>(value);
        //        Count++;
        //        return;
        //    }
        //    else
        //    {
        //        BinaryTreeNode<T> current = _head;
        //        AddToOld(current, value);
        //    }
        //}

        //private void AddToOld(BinaryTreeNode<T> current, T value)
        //{
        //    // while (current != null)
        //    {
        //        int result = current.CompareTo(value);
        //        if (result > 0) // value less than node
        //        {
        //            if (current.LeftChild == null)
        //            { current.LeftChild = new BinaryTreeNode<T>(value); Count++; }
        //            else
        //                AddToOld(current.LeftChild, value);
        //            // current = current.LeftChild;
        //        }
        //        else if (result < 0)
        //        {
        //            if (current.RightChild == null)
        //            {
        //                current.RightChild = new BinaryTreeNode<T>(value);
        //                Count++;
        //            }

        //            else
        //                AddToOld(current.RightChild, value);
        //            // current = current.RightChild;
        //        }
        //        else//equal..
        //        { }
        //    }
        //}

        //public bool ContainsOld(T value)
        //{
        //    BinaryTreeNode<T> parent;
        //    return (FindWithParentOLD(value, out parent) != null);

        //}

        //private BinaryTreeNode<T> FindWithParentOLD(T value, out BinaryTreeNode<T> parent)
        //{
        //    BinaryTreeNode<T> current = _head;
        //    parent = null;
        //    while (current != null)
        //    {
        //        int result = (current.CompareTo(value));
        //        if (result == 0) //match
        //            return current;
        //        else
        //        {
        //            if (result > 0) //value less than currnet
        //            {
        //                current = current.LeftChild;
        //            }
        //            else if (result < 0)
        //            {
        //                current = current.RightChild;
        //            }
        //            parent = current;
        //        }
        //    }
        //    return null;
        //}

    }
}
