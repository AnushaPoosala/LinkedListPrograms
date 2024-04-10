using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Get Union set of two Linked Lists
//https://www.youtube.com/watch?v=b_n4w-MgoU4&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=22
namespace _21GetUnionSetOfTwoLinkedLists
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node UnionOf2UnsortedLinkedList(Node node1, Node node2)
        {
            Node left = MergeSort(node1);
            Node right = MergeSort(node2);
            return UnionOf2Lists(left, right);
        }
        public Node MergeSort(Node node)
        {
            if (node == null || node.next == null)
                return node;

            Node middle = MiddleNode(node);

            Node right = middle.next;
            middle.next = null;
            Node left = node;

            left = MergeSort(left);
            right = MergeSort(right);

            return MergeTwoLinkedLists(left, right);

        }
        public Node MergeTwoLinkedLists(Node list1, Node list2)
        {
            Node temp = new Node();
            Node final = temp;
            while (list1 != null && list2 != null)
            {
                if (list1.data < list2.data)
                {
                    temp.next = list1;
                    list1 = list1.next;
                }
                else
                { temp.next = list2; list2 = list2.next; }
                temp = temp.next;
            }
            if (list1 != null)
                temp.next = list1;
            if (list2 != null)
                temp.next = list2;

            return final.next;
        }
        public Node UnionOf2Lists(Node list1, Node list2)
        {
            Node temp = new Node();
            Node final = temp;

            while (list1 != null && list2 != null)
            {
                while (list1.next != null && list1.data == list1.next.data)
                {
                    list1 = list1.next;
                }
                while (list2.next != null && list2.data == list2.next.data)
                {
                    list2 = list2.next;
                }
                if (list1.data < list2.data)
                {
                    temp.next = list1;
                    list1 = list1.next;
                }
                else if (list1.data > list2.data)
                {
                    temp.next = list2;
                    list2 = list2.next;
                }
                else if (list1.data == list2.data)
                {
                    temp.next = list2;
                    list2 = list2.next;
                    list1 = list1.next;
                }
                temp = temp.next;
            }

            while (list1 != null)
            {
                while (list1.next != null && list1.data == list1.next.data)
                {
                    list1 = list1.next;
                }
                temp.next = list1;
                list1 = list1.next;
                temp = temp.next;
            }

            while (list2 != null)
            {
                while (list2.next != null && list2.data == list2.next.data)
                {
                    list2 = list2.next;
                }
                temp.next = list2;
                list2 = list2.next;
                temp = temp.next;
            }

            return final.next;
        }
        public Node MiddleNode(Node node)
        {
            if (node == null)
                return null;

            Node slow = node;
            Node fast = node.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
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
            Node root2 = null;
            Node root = null;
            Linked a = new Linked();

            root2 = a.Insert(12, root2);
            root2 = a.Insert(99, root2);
            root2 = a.Insert(18, root2);
            root2 = a.Insert(8, root2);
            root2 = a.Insert(18, root2);
            root2 = a.Insert(118, root2);
            root2 = a.Insert(118, root2);


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
            root = a.Insert(400, root);

            a.PrintList(root);
            Console.WriteLine();

            a.PrintList(root2);
            Console.WriteLine();

            Node sorted = a.UnionOf2UnsortedLinkedList(root, root2);
            a.PrintList(sorted);
        }
    }
}

