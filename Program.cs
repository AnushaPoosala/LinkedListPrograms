using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//https://www.youtube.com/watch?v=_VWBbcl_EYA&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=6
//4 - Insert element at given position in LinkedList
namespace _6InsertElementAtGivenPositionUsingRecursion
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
            public Node InsertLast(int data,Node root)
            {
                if (root == null)
                    return NewNode(data);
                else
                {
                    root.Next = InsertLast(data, root.Next);
                    return root;
                }
            }
            public Node NewNode(int data)
            {
                Node node=new Node() {  Data = data,Next=null  };
                return node;
            }
            public void Print(Node root)
            {
                if (root == null) return;
                else
                {
                    Console.WriteLine(root.Data);
                    Print(root.Next);
                }
                Console.WriteLine();
            }

            public Node InsertAtPositionUsingRecursion(int position, int data, Node node)
            {
                if( position<1)
                    Console.WriteLine("Position can not be less than 1: It is Invalid");
                if(node==null && position>1)
                    Console.WriteLine("When node is null we can insert only at position1: Invalid Position");
                if (node == null && position == 1) return NewNode(data);
                if(node!=null && position == 1) { Node newNode = NewNode(data); newNode.Next = node; return newNode; }

                node.Next = InsertAtPositionUsingRecursion(position-1, data, node.Next);
                return node;
            }
        }
        static void Main(string[] args)
        {
            Node node = null;
            LinkedList ll=new LinkedList();
            node=ll.InsertLast(1, node);
            node = ll.InsertLast(2, node);
            node = ll.InsertLast(3, node);
            node = ll.InsertLast(5, node);
            node = ll.InsertLast(6, node);
            node = ll.InsertLast(7, node);
            ll.Print(node);

            node = ll.InsertAtPositionUsingRecursion(4, 4, node);
            ll.Print(node);
        }
    }
}
