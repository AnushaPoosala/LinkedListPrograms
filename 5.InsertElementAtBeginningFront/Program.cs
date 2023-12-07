using LinkedList;
using System;
// https://www.youtube.com/watch?v=6gXuLS92bh8&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=5 this video, we're going to reveal exact steps to create Linked list in java...
//Insert element at beginning/front

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
        public Node InsertAtLast(int ele, Node root)
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
        public Node InsertAtFront(int ele, Node root)
        {
            Node newNode = GetNewNode(ele);
            newNode.Next = root;
            return newNode;
        }
    }

    // LinkedList class to initiate the operation.
    class LinkedListApp
    {
        static void Main(string[] args)
        {
            Node root = null;
            Linked ll = new Linked();
            root = ll.InsertAtLast(12, root);
            root = ll.InsertAtLast(13, root);
            root = ll.InsertAtLast(14, root);
            root = ll.InsertAtLast(15, root);
            root = ll.InsertAtLast(16, root);

            ll.Print(root);
            Console.WriteLine();

            root = ll.InsertAtFront(1, root);
            ll.Print(root);

        }
    }
}