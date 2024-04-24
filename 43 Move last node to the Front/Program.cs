using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//43  Move last node to the Front
//https://www.youtube.com/watch?v=ccWYq9HtXHQ&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=43
namespace _43_Move_last_node_to_the_Front
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 37 5 12 99 37
        public Node MoveLastNodeToTheFront(Node head)
        {
            //best approach
            if (head == null || head.next == null)
            {
                return head;
            }
            Node node = head;

            while (node.next.next != null)
            {
                node = node.next;
            }

            node.next.next = head;
            head = node.next;

            node.next = null;
            return head;
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
            head = a.Insert(3, head);
            head = a.Insert(4, head);
            head = a.Insert(5, head);
            head = a.Insert(6, head);
           // head = a.Insert(7, head);
            a.PrintList(head); Console.WriteLine();
            head = a.MoveLastNodeToTheFront(head);
            a.PrintList(head);
        }
    }
}