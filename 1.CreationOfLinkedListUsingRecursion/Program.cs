using System;
//https://www.youtube.com/watch?v=dBBm5pltWe4&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU
//Creation of linked list using Recursion
//questions you should answer 
//1.Why we are creating object in GetNewNode Method why not just after LinkedList(before insert methode)
//2.how we are able to access root.next in Insert,Print methods without creating instance to Node.
//3. nullHandlingException, objectReference is not set to an instance exception
namespace Stack
{
    class Node
    {
        public int data;
        public Node next;
    }
    class LinkedList
    {
        public Node Insert(int ele, Node root)
        {
            if (root == null)
                return GetNewNode(ele, root);
            else
                root.next = Insert(ele, root.next);
            return root;
        }
        public Node GetNewNode(int ele, Node root)
        {
            Node node = new Node { data = ele, next = null };
            return node;
        }
        public void Print(Node root)
        {
            if (root == null)
                return;
            else
            {
                Console.Write("{0}  ", root.data);
                Print(root.next);
            }
            Console.WriteLine();
        }
    }


    class StackLinkedListImplementation
    {
        static void Main(string[] args)
        {
            Node root = null;
            LinkedList lL = new LinkedList();
            root = lL.Insert(12, root);
            root = lL.Insert(13, root);
            root = lL.Insert(14, root);
            root = lL.Insert(15, root);

            lL.Print(root);

            root = lL.Insert(16, root);
            lL.Print(root);

        }
    }
}