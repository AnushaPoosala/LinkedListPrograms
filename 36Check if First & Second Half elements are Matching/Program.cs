using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://thecodingsimplified.com/check-if-first-second-half-elements-are-matching/
//Check if First & Second Half elements are Matching
namespace _36Check_if_First___Second_Half_elements_are_Matching
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 37 5 12 99 37
        public bool CheckIfFirstAndSecondHalfsAreMatching(Node head)
        {
            if (head == null || head.next==null)
            {
                return false;
            }

            Node slow, fast;
            Node prev = null;
            slow = fast = head;
            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            if(fast!=null)
            {
                slow = slow.next;
            }
            prev.next = null;
            Console.WriteLine("first half is:"); ; PrintList(head);
            Console.WriteLine("\nsecond half is:"); PrintList(slow);
            while (head != null) 
            {
                if(head.data!=slow.data) 
                { 
                    return false; 
                }
                slow = slow.next; head = head.next;
            }
            return true;
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

            head = a.Insert(12, head);
            head = a.Insert(99, head);
            head = a.Insert(37, head);
            //head = a.Insert(5, head);
            head = a.Insert(12, head);
            head = a.Insert(99, head);
            head = a.Insert(379, head);
            a.PrintList(head); Console.WriteLine();
            Console.WriteLine(a.CheckIfFirstAndSecondHalfsAreMatching(head));
            //a.PrintList(head);
        }
    }
}
