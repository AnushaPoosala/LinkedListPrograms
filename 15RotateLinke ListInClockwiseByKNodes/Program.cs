using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Rotate the Linked List in clock-wise by k nodes iteration
//https://www.youtube.com/watch?v=2h8FBHivjxo&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=15
//k=1 ip:1->2->3->4->5,null op:5->1->2->3->4,null  k=2 ip:1->2->3->4->5,null op:4->5->1->2->3,null
namespace _15RotateLinke_ListInClockwiseByKNodes
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        /*
         * It'll rotate the linked list clockwise by k nodes
         */
        public Node RotateClockwise(int position, Node node)
        {
            if (node == null ||node.next==null)
                return null;

            int sizeOfLinkedList = GetSizeOfList(node);
            position = position % sizeOfLinkedList;

            if(position== sizeOfLinkedList)
                return node;

            Node rightPartInClockWiseNode = null; Node actualNode = node; Node head = null;

            while(sizeOfLinkedList-position>0)
            {
                rightPartInClockWiseNode = node;
                node= node.next;
                sizeOfLinkedList--;
            }
            head = rightPartInClockWiseNode.next;       Node tempHead = head;
            rightPartInClockWiseNode.next = null;
            while(head.next!=null)
            { head = head.next; }

            head.next = actualNode;
            return tempHead;
        }

        public int GetSizeOfList(Node node)
        {
            if (node == null)
            {
                return 0;
            }

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
            {
                return;
            }

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

            Console.WriteLine("Original List:");
            a.PrintList(root);
            Console.WriteLine();

            root = a.RotateClockwise(2, root);

            Console.WriteLine("List after rotating clockwise by 2 nodes:");
            a.PrintList(root);
            Console.WriteLine();
        }
    }
}
