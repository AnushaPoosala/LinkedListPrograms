using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  Rotate the Linked List in Anticlock-wise by k nodes
//https://www.youtube.com/watch?v=IMCCmLkO7o0&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=17
namespace _16RotateLinke_ListInAntiClockwiseByKNodes
{
    class Node
    {
        public Node next;
        public int data;
    }
    class Linked
    {
        public Node RotateAntiClockwise(int position, Node node)
        {
            if (node == null || position < 0)
                return null;

            int sizeOfLinkedList = GetSizeOfList(node);
            position = position % sizeOfLinkedList;

            if (position == 0)
                return node;

             Node actualNode = node; Node head = null;

            while(position>1)
            {
                node = node.next;
                position--;
            }
            head = node.next;
            Node mainHead = head;
            node.next = null;

            while (head.next != null)
                head = head.next;

            head.next = actualNode;
            return mainHead;
           
        }

        public int GetSizeOfList(Node node)
        {
            if (node == null)
                return 0;

            return 1 + GetSizeOfList(node.next);
        }

        public Node GetNewNode(int key)
        {
            Node a = new Node();
            a.next = null;
            a.data = key;
            return a;
        }

        public Node Insert(int key, Node node)
        {
            if (node == null)
                return GetNewNode(key);
            else
                node.next = Insert(key, node.next);

            return node;
        }

        public void PrintList(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.data + " ");
            PrintList(node.next);
        }
    }

    public class LinkedListApp
    {
        public static void Main(string[] args)
        {
            Node root = null;
            Linked a = new Linked();

            root = a.Insert(1, root);
            root = a.Insert(2, root);
            root = a.Insert(3, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
            root = a.Insert(6, root);

            Console.WriteLine("Original List:");
            a.PrintList(root);
            Console.WriteLine();

            root = a.RotateAntiClockwise(4, root);

            Console.WriteLine("List after rotating clockwise by 4 nodes:");
            a.PrintList(root);
            Console.WriteLine();
        }
    }
}
