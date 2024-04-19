using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://thecodingsimplified.com/delete-middle-node-of-linked-list/
//  Delete Middle Node of Linked List
namespace _35Delete_Middle_Node_of_Linked_List
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node DeleteMiddleNodeOfLinkedList(Node head)
        {
            if (head == null)
            {
                return head;
            }

            Node slow, fast;
            Node prev = null;
            slow = fast = head;
            while (fast!= null && fast.next!= null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            prev.next = slow.next;
            return head;
        }

        /*
         * getNewNode() method to generate a new node
         */
        public Node GetNewNode(int key)
        {
            Node a = new Node();
            a.next = null;
            a.data = key;
            return a;
        }

        /*
         * insert method is used to insert the element in Linked List
         */
        public Node Insert(int key, Node node)
        {

            if (node == null)
                return GetNewNode(key);
            else
                node.next = Insert(key, node.next);

            return node;
        }

        /*
         * It'll print the complete linked list
         */
        public void PrintList(Node node)
        {
            if (node == null)
            {
                return;
            }

            System.Console.Write(node.data + " ");
            PrintList(node.next);
        }
    }

    public class LinkedListApp
    {

        public static void Main(string[] args)
        {

            Node head = null;
            Linked a = new Linked();

            head = a.Insert(12, head);
            head = a.Insert(99, head);
            head = a.Insert(37, head);
            head = a.Insert(5, head);
            head = a.Insert(25, head);
            head = a.Insert(26, head);
            //head = a.Insert(27, head);
            a.PrintList(head);
            head =a.DeleteMiddleNodeOfLinkedList(head);
            Console.WriteLine("ll after deleting middle ele");
            a.PrintList(head);
        }
    }
}
