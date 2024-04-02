using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=Gf2k0wPPLVA&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=7
//Linked List in Java - 4 (Iterative Method) : Insert element at any given position
namespace _7InsertElementAtAnyGivenPositionIterative_Method
{
    internal class Program
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }
        public class LinkedList
        {
            public Node InsertLast(int data, Node root)
            {
                if (root == null)
                    return NewNode(data);
                Node actualNode = root;
                while(root.Next!=null)
                {
                    root=root.Next;
                }
                Node newNode = NewNode(data);
                root.Next= newNode;
                return actualNode;
            }
            public Node NewNode(int data)
            {
                Node node = new Node() { Data = data, Next = null };
                return node;
            }
            public void Print(Node root)
            {
                while(root!=null)
                {
                    Console.WriteLine(root.Data);
                    root = root.Next;
                }
                if (root == null) return;
                Console.WriteLine();
            }

            public Node InsertAtPositionUsingIteration(int position, int data, Node node)
            {
                if (position < 1)
                {
                    Console.WriteLine("Position can not be less than 1: It is Invalid");return null;
                }
                if (node == null && position > 1)
                { Console.WriteLine("When node is null we can insert only at position1: Invalid Position"); return null; }
                if (node == null && position == 1) return NewNode(data);
                if (node != null && position == 1) { Node newNode = NewNode(data); newNode.Next = node; return newNode; }

                Node actualNode = node; Node prev=null;
                while (node != null && position>1) 
                {
                    prev = node;
                    node = prev.Next;
                    position--;
                }
                Node newNode2 = NewNode(data);
                prev.Next= newNode2;
                newNode2.Next = node;

                return actualNode;
            }
        }
        static void Main(string[] args)
        {
            Node node = null;
            LinkedList ll = new LinkedList();
            node = ll.InsertLast(1, node);
            node = ll.InsertLast(2, node);
            node = ll.InsertLast(3, node);
            node = ll.InsertLast(5, node);
            node = ll.InsertLast(6, node);
            node = ll.InsertLast(7, node);
            ll.Print(node);

            node = ll.InsertAtPositionUsingIteration(4, 4, node);
            ll.Print(node);
        }
    }
}
