using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://thecodingsimplified.com/check-if-two-linked-lists-are-identical/
//Check if two Linked Lists are identical
namespace _40Check_if_two_Linked_Lists_are_identical
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {           
        public bool CheckIf2LLsAreIdentical(Node head1, Node head2)
        {
            if (head1 == null && head2 == null)
            {
                return true;
            }
            while(head1!=null && head2!=null) 
            {
                if (head1.data != head2.data)
                    return false;
                head1 = head1.next;
                head2 = head2.next;
            }

            return (head1 == null && head2 == null);

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

            Node head1 = null;
            Linked a = new Linked();

            head1 = a.Insert(12, head1);
            head1 = a.Insert(99, head1);
            head1 = a.Insert(37, head1);
            // head = a.Insert(5, head1);
            head1 = a.Insert(397, head1);
            head1 = a.Insert(99, head1);
            head1 = a.Insert(12, head1);
            a.PrintList(head1); Console.WriteLine();

            Node head2 = null;
            head2 = a.Insert(12, head2);
            head2 = a.Insert(99, head2);
            head2 = a.Insert(37, head2);
            //head2 = a.Insert(5, head2);
            head2 = a.Insert(397, head2);
            head2 = a.Insert(99, head2);
            head2 = a.Insert(12, head2);
            head2 = a.Insert(5, head2);
            a.PrintList(head2); Console.WriteLine();

            Console.WriteLine(a.CheckIf2LLsAreIdentical(head1,head2));
            //a.PrintList(head);
        }
    }
}
