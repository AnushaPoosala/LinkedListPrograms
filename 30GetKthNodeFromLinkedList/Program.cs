using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Get Kth Node from Linked List
//https://www.youtube.com/watch?v=m3Lop4ZKs60&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=30
namespace _30GetKthNodeFromLinkedList
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public void GetKthNode(Node node, int k)
        {
            //approach 1
            if (k < 1 || node == null) return;
            for (int i = 1; i < k; i++)
            {
                node = node.next;
                if (node == null)
                {
                    Console.WriteLine("k is greater than Linkedlist length"); return;
                }
            }
            Console.WriteLine("{0}th ele in th linkedlist is: {1}", k, node.data);
            //approach2
            /*
            if (k < 1 || node == null)
            {
                Console.WriteLine("k is less than Linkedlist length or linked list is empty"); return;
            }
            int k2 = k;
            while (k > 1)
            {
                node = node.next;
                if (node == null)
                {
                    Console.WriteLine("k is greater than Linkedlist length"); return;
                }
                k--;
            }
            Console.WriteLine("{0}th ele in th linkedlist is: {1}", k2, node.data);
            */
            //approach3 : using recursion
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

            root = a.Insert(18, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
            root = a.Insert(8, root);
            root = a.Insert(10, root);
            root = a.Insert(9, root);
            root = a.Insert(5, root);
            root = a.Insert(5, root);
            root = a.Insert(12, root);
            root = a.Insert(4, root);
            root = a.Insert(400, root);
            root = a.Insert(401, root);

            a.PrintList(root);
            Console.WriteLine();

            a.GetKthNode(root,12);

        }
    }
}
