using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//29: Detect & Remove Loop in linked list
//https://www.youtube.com/watch?v=zNMy47gX8qQ&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=34
//https://www.youtube.com/watch?v=2Kd0KKmmHFc
//https://www.youtube.com/watch?v=Fj1ywT9ETQk
namespace _34Detect___Remove_Loop_in_linked_list
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node DetectRemoveLoopInLL(Node node)
        {
            if (node == null || node.next == null) return node;
         
            Node slow = node; Node fast = node;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;
            }
            if (slow == fast)
            {
                if(slow==node)
                {
                   while(fast.next!=slow)
                    {
                        fast = fast.next;
                    }
                    Console.WriteLine("the junction point is: {0}", slow.data);
                }
                else
                {
                    slow = node;
                    while (slow.next != fast.next)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }

                    Console.WriteLine("the junction point is: {0}", slow.next.data);
                }
                fast.next = null;
            }
            return node;
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

            root = a.Insert(1, root);
            root = a.Insert(2, root);
            root = a.Insert(3, root);
            root = a.Insert(4, root);
            root = a.Insert(5, root);
            root = a.Insert(6, root);
            root = a.Insert(7, root);

            //root = a.Insert(8, root);
            //root = a.Insert(9, root);
            //root = a.Insert(10, root);

            //Node root2 = root.next.next.next.next.next.next.next;
            //a.PrintList(root2);
            root.next.next.next.next.next.next.next = root.next.next.next;


            //a.PrintList(root);
            //Console.WriteLine();

            Node afterRemovingLoop= a.DetectRemoveLoopInLL(root);
            a.PrintList(afterRemovingLoop);
        }
    }
}