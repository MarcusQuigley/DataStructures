using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Testing.Tree
{
    class BinaryTree<T>
        where T : IComparable<T>
    {
        
         TreeNode<T> _root = null;

        public BinaryTree()
        {

        }

        public int Count
        {
            get;private set;
        }

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(value);
            }
            else
            {
                TreeNode<T> node = _root;
                while (node != null)
                {
                    int result = node.Value.CompareTo(value);
                    if (result > 0) //less than node
                    {
                        if (node.LeftChild == null)
                        {
                            node.LeftChild = new TreeNode<T>(value);
                            break;
                        }
                        else
                            node = node.LeftChild;
                    }
                    else if (result<0) //value greater than node
                    {
                        if (node.RightChild == null)
                        {
                            node.RightChild = new TreeNode<T>(value);
                            break;
                        }
                        else
                            node = node.RightChild;
                    }
                 }
            }
            Count++;
        }

        public bool Contains(T item)
        {
            TreeNode<T> parent = null;
            return (FindWithParent(item, out parent) != null);
        }

        private TreeNode<T> FindWithParent(T item, out TreeNode<T> parent)
        {
            TreeNode<T> current = _root;
            parent = null;

            while (current != null)
            {
                int result = (current.Value.CompareTo(item));
                if (result > 0) //less than parent
                {
                    parent = current;
                    current = current.LeftChild;
                }
                else if (result < 0) //less than parent
                {
                    parent = current;
                    current = current.RightChild;
                }
                else // result!
                {
                    break;
                }
            }
            return current;

        }


        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(_root, action);
        }

        void PreOrderTraversal(TreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(node.LeftChild, action);
                PreOrderTraversal(node.RightChild, action);
            }
        }

        public void InOrderTraversel(Action<T> action)
        {
            InOrderTraversel(action, _root);
        }

        void InOrderTraversel(Action<T> action, TreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversel(action, node.LeftChild);
                action(node.Value);
                InOrderTraversel(action, node.RightChild);
            }
        }


    }
}
