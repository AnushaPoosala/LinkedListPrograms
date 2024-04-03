﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Search node in Linked List
//https://www.youtube.com/watch?v=IFi-bY02N-4&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=14
namespace _14SearchNodeInLinkedList
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }
    public class LinkedList
    {
        public Node InsertLast(Node node, int data)
        {
            if (node == null) return NewNode(data);
            else
            {
                node.Next = InsertLast(node.Next, data);
            }
            return node;
        }
        public Node NewNode(int data)
        {
            Node node = new Node() { Data = data, Next = null }; return node;
        }
        public void Print(Node node)
        {
            if (node == null) Console.WriteLine("node is null empty now");
            else
            {
                Console.WriteLine(node.Data);
                Print(node.Next);
            }
        }
        public Node DeleteAtPosition(Node node, int position)
        {
            if (position < 1) { Console.WriteLine("position should be greater than 0"); return null; }
            if (node == null && position > 0) { Console.WriteLine("position should be greater than 0 and node is null"); return null; }
            if (node == null && position == 1) { Console.WriteLine("nothing is there in the list to delete"); return null; }
            if (node != null && position == 1)
            {
                return node.Next;
            }
            if (node != null && position > 1)
            {
                node.Next = DeleteAtPosition(node.Next, position - 1);

            }
            return node;
        }

        public int LinkedListSizeRecursion(Node node)
        {
            if (node == null) return 0;

            return 1 + LinkedListSizeRecursion(node.Next);
        }

        public int SearchNodeInLinkedList(Node node, int element)
        {
            if(node== null) { Console.WriteLine("Node is empty , No element exists in the Nide");  }
            int count = 1;
            while(node!=null)
            {
                if(node.Data==element)
                    return count;
                count++;
                node = node.Next;
            }
            Console.WriteLine("element does not exists in the LinkedList");
            return 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node = null; int size = 0;
            LinkedList ll = new LinkedList();
            node = ll.InsertLast(node, 1);
            node = ll.InsertLast(node, 2);
            node = ll.InsertLast(node, 2);
            node = ll.InsertLast(node, 3);
            node = ll.InsertLast(node, 4);
            node = ll.InsertLast(node, 5);
            node = ll.InsertLast(node, 6);
            ll.Print(node);
            Console.WriteLine("LinkedList size is:{0}", ll.LinkedListSizeRecursion(node));
            Console.WriteLine("Node is found at position:{0}", ll.SearchNodeInLinkedList(node,4)); Console.WriteLine();

            node = ll.DeleteAtPosition(node, 3);

            ll.Print(node);
            Console.WriteLine("LinkedList size is:{0}", ll.LinkedListSizeRecursion(node));
            Console.WriteLine("Node is found at position:{0}", ll.SearchNodeInLinkedList(node,4)); Console.WriteLine();
        }
    }
}
