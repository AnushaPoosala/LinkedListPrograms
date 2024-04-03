using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://www.youtube.com/watch?v=fMOf3KST2Ig&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=8
//Delete last node of list
namespace _8DeleteLastNodeOfList
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }
    public class LinkedList
    {
        public Node InsertLast(Node node,int data)
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
            Node node = new Node() { Data = data, Next = null };return node;
        }
        public void Print(Node node)
        {
           if(node==null) Console.WriteLine("node is null empty now \n");
           else
            {
                Console.WriteLine(node.Data);
                Print(node.Next);
            }
        }
        public Node DeleteLast(Node node)
        {   /*  using iteration
            if (node.Next == null || node == null)
                return null;
            Node actualNode = node;
            Node prev=null;
            while (node.Next != null) 
            {
                prev = node;
                node = node.Next;
            }
            prev.Next = null;
            return actualNode;  */


            /*//Using iteration best approach2
            if (node.Next == null || node == null)
                return null;
            while (node.Next.Next != null)
                node = node.Next;
            node.Next = null;
            return node; */


            //Using iteration best approach1
            if (node.Next == null || node == null)
                return null;
            Node temp = node;
            while(temp.Next.Next != null)
                temp = temp.Next;
            temp.Next = null;
            return node; 

            /*//using Recursion
            if (node.Next == null || node == null)
                return null;
            if(node.Next.Next==null)
            {
                node.Next = null;
                return node;
            }
            node.Next = DeleteLast(node.Next); return node; */
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
            node = ll.InsertLast(node, 3);
            node = ll.InsertLast(node, 4);
            node = ll.InsertLast(node, 5);
            node = ll.InsertLast(node, 6);
            ll.Print(node);
            ll.DeleteLast(node);
            ll.Print(node);
        }
    }
}
