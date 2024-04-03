using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Delete Front Node of list
//https://www.youtube.com/watch?v=HegaVfl3DXs&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=9
namespace _9DeleteFrontNodeOfLinkedlist
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
        public Node DeleteFront(Node node)
        {
            if (node == null)
            {
                return null;
            }

            return node.Next;
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
            node=ll.DeleteFront(node);
            ll.Print(node);
        }
    }
}
