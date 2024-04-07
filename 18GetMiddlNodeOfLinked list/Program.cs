using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Get middle node of linked list
//https://www.youtube.com/watch?v=XxD0Tf6WAkk&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=18
namespace _18GetMiddlNodeOfLinked_list
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        /*
         * It'll find the middle node of the linked list
         */
        public Node MiddleNode(Node node)
        {
            if (node == null)
            {
                return null;
            }
            Node slow = node;
            Node fast= node;
            while(fast!=null && fast.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        /*
         * getNewNode() method to generate a new node
         */
        public Node GetNewNode(int key)
        {
            Node a = new Node();
            a.next = null;
            a.data = key;
            return a;
        }

        /*
         * insert method is used to insert the element in Linked List
         */
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
            root = a.Insert(2, root);
            root = a.Insert(3, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
            root = a.Insert(11, root);
            root = a.Insert(1, root);
            root = a.Insert(2, root);
            root = a.Insert(3, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
            root = a.Insert(6, root);

            a.PrintList(root);
            Console.WriteLine();

            Node middle = a.MiddleNode(root);
            if(middle == null)
                Console.WriteLine("LinkedList does not contain middle");
            a.PrintList(middle);
        }
    }
}
