using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Delete alternate nodes in Linked List
//https://www.youtube.com/watch?v=REpMYKH-yLw&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=42
namespace _42Delete_alternate_nodes_in_Linked_List
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 37 5 12 99 37
        public Node DeleteAlternateNodesLinkedList(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            Node tempHead = head;
            while (tempHead!=null && tempHead.next != null)
            {
                 tempHead.next = tempHead.next.next;

                tempHead = tempHead.next;
            }
            return head;
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

            head = a.Insert(1, head);
            head = a.Insert(2, head);
            head = a.Insert(3, head);
            head = a.Insert(4, head);
            head = a.Insert(5, head);
            head = a.Insert(6, head);
           // head = a.Insert(7, head);
            a.PrintList(head); Console.WriteLine();
            head = a.DeleteAlternateNodesLinkedList(head);
            a.PrintList(head);
        }
    }
}