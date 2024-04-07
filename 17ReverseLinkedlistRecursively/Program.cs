using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//17.Reverse linked list Recursively
//https://www.youtube.com/watch?v=8FD6EGQI2-4&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=17
namespace _17ReverseLinkedlistRecursively
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node ReverseLinkedListRecursively(Node head)
        {
            //Approach 1: Recursion
            if (head == null || head.next == null) return head;

            Node newNode = ReverseLinkedListRecursively(head.next);

            Node front = head.next;
            front.next = head;
            head.next = null;
            return newNode;
               

            /*//Approach2: Iteration
            if (head == null || head.next == null) return head;

            Node prev = head;
            Node curr = head.next;
            while (curr != null) 
            {
                Node next = curr.next;

                curr.next = prev;
                prev = curr;
                curr = next;
            }
            head.next = null;
            return prev;  */

            /*//Approach3 using collections
            LinkedList<int> list=new LinkedList<int>();
            list.AddLast(11);
            list.AddLast(12);
            list.AddLast(13);
            list.AddLast(14);
            list.AddLast(15);
            foreach(var ele in list) Console.Write("{0} ",ele);
             list.Reverse(); Console.WriteLine();
            foreach (var ele in list) Console.Write("{0} ", ele);
            return null;
            */
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
            //root = a.Insert(3, root);
            root = a.Insert(2, root);
            root = a.Insert(3, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
           // root = a.Insert(6, root);

            Console.WriteLine("Original List:");
            a.PrintList(root);
            Console.WriteLine();

            root = a.ReverseLinkedListRecursively(root);

            Console.WriteLine("List after reversing recursively:");
            a.PrintList(root);
            Console.WriteLine();
        }
    }
}
