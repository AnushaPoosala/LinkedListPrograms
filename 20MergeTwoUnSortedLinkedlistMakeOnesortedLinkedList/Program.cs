using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Merge two Linked list(Merge 2 unsorted linkedlists and give a linked list in a sorted way)
//Code is from strivers Merge sort
//https://github.com/AnushaPoosala/LinkedListPrograms/blob/main/19SortLinkedList/Program.cs
//https://www.youtube.com/watch?v=8ocB7a_c-Cc
//https://www.youtube.com/watch?v=iAvB3fxAvI4&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=20

namespace _20MergeTwoUnSortedLinkedlistMakeOnesortedLinkedList
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node Merge2UnsortedLinkedListsintoSingleSortedLinkedList(Node node1,Node node2)
        {
            return MergeTwoLinkedLists(MergeSort(node1), MergeSort(node2));
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
            Node root = null;
            Linked a = new Linked();

            Node root2 = null;
            root2 = a.Insert(12, root2);
            root2 = a.Insert(99, root2);
            root2 = a.Insert(37, root2);
            root2 = a.Insert(8, root2);
            root2 = a.Insert(18, root2);

            root = a.Insert(7, root);
            root = a.Insert(4, root);
            root = a.Insert(1, root);
            root = a.Insert(8, root);
            root = a.Insert(10, root);
            root = a.Insert(-9, root);
            root = a.Insert(6, root);
            root = a.Insert(5, root);
            root = a.Insert(3, root);
            root = a.Insert(2, root);

            a.PrintList(root);
            Console.WriteLine();
            a.PrintList(root2);
            Console.WriteLine();

            Node sorted = a.Merge2UnsortedLinkedListsintoSingleSortedLinkedList(root,root2);
            a.PrintList(sorted);
        }
    }
}