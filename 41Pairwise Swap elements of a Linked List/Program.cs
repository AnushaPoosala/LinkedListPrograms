using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=SdFVSUClsNI&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=41
// Pairwise Swap elements of a Linked List
namespace _41Pairwise_Swap_elements_of_a_Linked_List
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 37 5 12 99 37
        public Node PairWiseSwapelementsOfLinkedList(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            Node tempHead = head;
            while (tempHead.next != null && tempHead.next.next!=null) 
            {
                int temp = tempHead.data;
                tempHead.data = tempHead.next.data;
                tempHead.next.data = temp;

                tempHead = tempHead.next.next;
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
            head = a.PairWiseSwapelementsOfLinkedList(head);
            a.PrintList(head);
        }
    }
}