﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  https://www.youtube.com/watch?v=S3Onk7-qmS0&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=10
//Delete element at given position  in LinkedList using recursion

namespace _10DeleteElementAtGivenPositionRecursion
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
            if (node == null) Console.WriteLine("node is null empty now \n");
            else
            {
                Console.WriteLine(node.Data);
                Print(node.Next);
            }
        }
        public Node DeleteAtPosition(Node node,int position)
        {
            if (position < 1) { Console.WriteLine("position should be greater than 0");return null; }
            if(node==null && position > 0) { Console.WriteLine("position should be greater than 0 and node is null"); return null; }
            if(node==null && position == 1) { Console.WriteLine("nothing is there in the list to delete");return null; }
            if(node!=null && position==1)
            {
                return node.Next;
            }
            if(node!=null && position>1)
            {
                node.Next = DeleteAtPosition(node.Next, position - 1);
                
            }
            return node;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node = null;
            LinkedList ll = new LinkedList();
            node = ll.InsertLast(node, 1);
            node = ll.InsertLast(node, 2);
            node = ll.InsertLast(node, 2);
            node = ll.InsertLast(node, 3);
            node = ll.InsertLast(node, 4);
            node = ll.InsertLast(node, 5);
            node = ll.InsertLast(node, 6);
            ll.Print(node);
            node=ll.DeleteAtPosition(node,3);
            ll.Print(node);
        }
    }
}
