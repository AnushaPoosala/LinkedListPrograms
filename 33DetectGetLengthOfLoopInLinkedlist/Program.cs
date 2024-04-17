using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Detect & get Length of loop in linked list
//https://www.youtube.com/watch?v=3LkH9zEr0ck&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=33
namespace _33DetectGetLengthOfLoopInLinkedlist
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public int CheckIfLoopPresentInLL(Node node)
        {
            if (node == null || node.next == null) return -1;
            Node slow = node; Node fast = node;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;

            }
            int count = 1;
            if (slow == fast)
            {
                while (slow.next != fast)
                {
                    slow = slow.next;
                    count++;
                }
                return count;
            }
            return -1;
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
                Console.WriteLine("node is null");
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

            root = a.Insert(18, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
            root = a.Insert(8, root);
            root = a.Insert(10, root);
            root = a.Insert(9, root);
            root = a.Insert(5, root);

            //root = a.Insert(1, root);
            //root = a.Insert(2, root);
            //root = a.Insert(2, root);

            //Node root2 = root.next.next.next.next.next.next.next;
            //a.PrintList(root2);
           root.next.next.next.next.next.next.next=root.next.next;


            //a.PrintList(root);
            //Console.WriteLine();

            Console.WriteLine(a.CheckIfLoopPresentInLL(root));

        }
    }
}