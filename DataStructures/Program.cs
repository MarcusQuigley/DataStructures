using DataStructures.Arrays;
using DataStructures.LinkedList;
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
            TestArray();
            Console.Read();
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
