using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Count occurrence of a value
//https://www.youtube.com/watch?v=PmvcLwwLUJw&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=44
namespace _44Count_occurrence_of_a_value
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 37 5 12 99 37
        public int MoveLastNodeToTheFront(Node head, int ele)
        {
            //best approach
            if (head == null)
            {
                return -1;
            }
            Node node = head; int count = 0;

            while (node!= null)
            {
                if (node.data == ele)
                    count++;
                node = node.next;
            }
            return count;
            /*
             Node fast = head; Node prev = null;
            while (fast.next != null && fast.next.next != null)
            {
                prev = fast;
                fast = fast.next.next;
            }
            if (fast.next != null)
            {
                prev=fast;
                fast = fast.next;
            }
            prev.next = null;
            fast.next =head;
            return fast;
            */
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
            head = a.Insert(5, head);
            head = a.Insert(8, head);
            // head = a.Insert(7, head);
            a.PrintList(head); Console.WriteLine();
            Console.WriteLine(a.MoveLastNodeToTheFront(head,5));
        }
    }
}