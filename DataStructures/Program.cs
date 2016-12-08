using DataStructures.Arrays;
using DataStructures.LinkedList;
using DataStructures.Sorting_Algorithms;
using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestLinkedList();
            // TestArray();
            // TestBinaryTree();
            //TestBubbleSort();
            TestInsertionSort();
            Console.Read();
        }

        private static void TestInsertionSort()
        {
            int[] items = new int[] { 3, 7, 4, 4, 6, 5, 8 };
            DisplayArray<int>(items);
            Console.WriteLine();
            new InsertionSort<int>().Sort(items);
            DisplayArray<int>(items);
        }

        private static void TestBubbleSort()
        {
            int[] items = new int[] {3,7,4,4,6,5,8 };
            DisplayArray<int>(items);
            Console.WriteLine();
            new BubbleSort<int>().Sort(items);
            DisplayArray<int>(items);
        }

      static  void DisplayArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }

        private static void TestBinaryTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(8);
            tree.Add(4);
            tree.Add(2);
            tree.Add(3);
            tree.Add(10);
            tree.Add(6);
            tree.Add(7);

            Console.WriteLine("Tree contains 6?: {0}", tree.Contains(6));
            Console.WriteLine("Tree contains 16?: {0}", tree.Contains(16));
            Console.WriteLine("Tree contains 10?: {0}", tree.Contains(10));
        }

        static void TestLinkedList()
        {
            //AnLinkedListNode<int> one = new AnLinkedListNode<int>(1);
            //AnLinkedListNode<int> two = new AnLinkedListNode<int>(4);
            //AnLinkedListNode<int> three = new AnLinkedListNode<int>(7);
            //AnLinkedListNode<int> four = new AnLinkedListNode<int>(3);

            MyLinkedList<int> list = new MyLinkedList<int>();

            list.Add(1);
            list.Add(4);
            list.Add(7);
            list.Add(3);
            IEnumerator<int> en = list.GetEnumerator();
            while (en.MoveNext())
                Console.WriteLine(en.Current);

            list.AddFirst(0);
            Console.WriteLine("---");
            IEnumerator<int> en2 = list.GetEnumerator();
            while (en2.MoveNext())
                Console.WriteLine(en2.Current);
            Console.WriteLine("---");
            Console.WriteLine("remove 4 ? {0}",list.Remove(4));
            Console.WriteLine("---");


            en2 = list.GetEnumerator();
            while (en2.MoveNext())
                Console.WriteLine(en2.Current);
            Console.WriteLine("---");

            Console.WriteLine("remove 3 ? {0}", list.Remove(3));
            Console.WriteLine("---");

            en2 = list.GetEnumerator();
            while (en2.MoveNext())
                Console.WriteLine(en2.Current);
            Console.WriteLine("---");

            Console.WriteLine("remove first ? {0}", list.RemoveFirst());
            en2 = list.GetEnumerator();
            while (en2.MoveNext())
                Console.WriteLine(en2.Current);
            Console.WriteLine("---");
        }

        static void TestArray()
        {
            MyArray<int> arr = new MyArray<int>();

            arr.Add(2);
            arr.Add(1);
            arr.Add(4);
            arr.Add(7);
            arr.Add(3);

            IEnumerator<int> en = arr.GetEnumerator();
            while (en.MoveNext())
                Console.WriteLine(en.Current);
            Console.WriteLine("---");
            arr.RemoveAt(4);

              en = arr.GetEnumerator();

            while (en.MoveNext())
                Console.WriteLine(en.Current);
            Console.WriteLine("---");
        }
    }
}
