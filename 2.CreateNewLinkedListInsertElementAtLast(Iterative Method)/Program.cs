using LinkedList;
using System;
//https://www.youtube.com/watch?v=oUZMCVpd4NY&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=2

//Linked List in Java 1 (Iterative Method) -Create new Linked List | Insert element at last
//Source Code: https://thecodingsimplified.com/creation-of-linked-list-iterative/In this video, we're going to reveal exact steps to create Linked list in java...
//www.youtube.com

// (Iterative Method) - Create new Linked List | Insert element at last
namespace LinkedList
{
    // Node class contains the LinkedList Node Structure.
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }

    // Linked class contains the necessary functions to perform operations.
    class Linked
    {
        public Node Insert(int ele, Node root)
        {
            if (root == null)
                return GetNewNode(ele);

            Node fullNode = root;
            while (root.Next != null)
            {
                root = root.Next;
            }
            root.Next = GetNewNode(ele);
            return fullNode;
        }
        public Node GetNewNode(int ele)
        {
            Node node = new Node { Data = ele, Next = null };
            return node;
        }
        public void Print(Node root)
        {
            if (root == null)
                return;
            while (root != null)
            {
                Console.Write("{0} ", root.Data);
                root = root.Next;
            }
            //while (root.Next != null)
            //{
            //    Console.Write("{0} ", root.Data);
            //    root = root.Next;
            //}
            //Console.Write("{0} ", root.Data);
            //Console.WriteLine();

        }
    }

    // LinkedList class to initiate the operation.
    class LinkedListApp
    {
        static void Main(string[] args)
        {
            Node root = null;
            Linked ll = new Linked();
            root = ll.Insert(12, root);
            root = ll.Insert(13, root);
            root = ll.Insert(14, root);
            root = ll.Insert(15, root);
            root = ll.Insert(16, root);

            ll.Print(root);
        }
    }
}