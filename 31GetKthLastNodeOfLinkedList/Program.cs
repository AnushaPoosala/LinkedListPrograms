using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Get Kth Last Node of Linked List
//https://www.youtube.com/watch?v=36BGcKvIkJM&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=31
namespace _31GetKthLastNodeOfLinkedList
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public void GetKthLastNode(Node node, int k)
        {
            if(k<1 || node==null)
            { Console.WriteLine("K is invalid or node is null"); return; }
           
            Node pointerReachesTillfinal = node;
            int k2 = k;
            while(k>1)
            {
                pointerReachesTillfinal = pointerReachesTillfinal.next;k--;
                if(pointerReachesTillfinal == null)
                {
                    Console.WriteLine("k is greater than node size");return;
                }
            }
            Node pointerStartsAfterKNodes = node;
            while (pointerReachesTillfinal.next != null)
            {
                pointerReachesTillfinal = pointerReachesTillfinal.next;
                pointerStartsAfterKNodes= pointerStartsAfterKNodes.next;
            }

            Console.WriteLine("{0}th postion from last is:{1}", k2,pointerStartsAfterKNodes.data);
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
            //root = a.Insert(5, root);
            //root = a.Insert(12, root);
            //root = a.Insert(4, root);
            //root = a.Insert(400, root);
            //root = a.Insert(401, root);

            a.PrintList(root);
            Console.WriteLine();

            a.GetKthLastNode(root, 2);

        }
    }
}