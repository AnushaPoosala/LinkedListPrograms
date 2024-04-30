using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Swap nodes of given values without swapping data
//https://www.youtube.com/watch?v=tX3OqIFQjxU&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=45
// ip: 1->2->6->4-5->3->7->8->9->X         op: 1->2->3->4-5->6->7->8->9->X
namespace _45Swap_nodes_of_given_values_without_swapping_data
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            
        public Node PairWiseSwapelementsOfLinkedListWithOutDataSwapWithNodeSwap(Node head, int ele1, int ele2)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            Node tempHead = head; Node first = null; Node second = null;  Node prev1 = null;Node prev2 = null;

            while (tempHead != null)
            {
                if (tempHead.data == ele1) { first = tempHead; break; }
                prev1 = tempHead;
                tempHead = tempHead.next;
            }
            tempHead = head;
            while (tempHead != null)
            {
                if (tempHead.data == ele2) { second = tempHead; break; }
                prev2 = tempHead;
                tempHead = tempHead.next;
            }
            if(prev1!=null)
            {
                prev1.next = second;
            }
            else
            {
                head = second;
            }
            if (prev2 != null)
            {
                prev2.next = first;
            }
            else
            {
                head = first;
            }
            Node temp = first.next;
           first.next=second.next;
            second.next=temp;

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
            head = a.Insert(5, head);
            head = a.Insert(4, head);
            head = a.Insert(3, head);
            head = a.Insert(6, head);
            head = a.Insert(7, head);
            //head = a.Insert(8, head);
            //head = a.Insert(9, head);
            //head = a.Insert(10, head);
            // head = a.Insert(7, head);
            a.PrintList(head); Console.WriteLine();
            head = a.PairWiseSwapelementsOfLinkedListWithOutDataSwapWithNodeSwap(head,3,5);
            a.PrintList(head);
        }
    }
}