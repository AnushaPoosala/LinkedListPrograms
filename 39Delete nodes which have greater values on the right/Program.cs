using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://thecodingsimplified.com/delete-nodes-which-have-greater-values-on-the-right/
//Delete nodes which have greater values on the right
namespace _39Delete_nodes_which_have_greater_values_on_the_right
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 8 39 5
        public Node DeleteNodeWhichHaveGreaterValuesOnItsRight(Node head)
        {
            if (head == null || head.next == null) { return head; }
            Node reveresdHead=this.ReverseLinkedList(head);
            Node tempNode = reveresdHead;
            int max= reveresdHead.data;
            while(tempNode.next!=null)
            {
               if(tempNode.next.data>max)
                {
                    max = tempNode.next.data;
                    tempNode = tempNode.next;
                }
                else
                {
                    tempNode.next = tempNode.next.next;
                }
            }
            return ReverseLinkedList(reveresdHead);
        }
        public Node ReverseLinkedList(Node head)
        {
            //Recursion
            if (head == null || head.next == null) { return head; }
            Node newNode = ReverseLinkedList(head.next);
            Node curr = head.next;
            curr.next = head;
            head.next = null; //head is like prev in below iteration approach
            return newNode;

            /* Iteration
            if(head== null || head.next == null) { return head; }
            Node prev=head;
            Node curr = head.next;
            while (curr!=null)
            {
                Node next = curr.next;

                curr.next = prev;
                //prev.next = null;

                prev = curr;
                curr = next;
            }
            head.next = null;
            return prev;*/
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
            head = a.Insert(888, head);
            // head = a.Insert(5, head);
            head = a.Insert(39, head);
            head = a.Insert(589, head);
            //head = a.Insert(12, head);
            a.PrintList(head); Console.WriteLine();
            head=a.DeleteNodeWhichHaveGreaterValuesOnItsRight(head);
            Console.WriteLine("after Deleting nodes which have greater values on the right");
            a.PrintList(head);
        }
    }
}