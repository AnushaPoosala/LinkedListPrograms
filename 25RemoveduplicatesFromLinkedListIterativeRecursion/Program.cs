using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//25RemoveduplicatesFromLinkedListIterativeRecursion
//https://www.youtube.com/watch?v=vf3vyjKqa1U&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=25
namespace _25RemoveduplicatesFromLinkedListIterativeRecursion
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node RemoveDuplicatesFromListIterativeRecursive(Node node)
        {   //Iterative Approach 
            /*
             Node sortedNode = MergeSort(node);
            Node final = new Node();
            Node final2 = final;
            while (sortedNode!=null)
            {
                while (sortedNode.next != null && sortedNode.data == sortedNode.next.data)
                {
                    sortedNode = sortedNode.next;
                }
                final.next = sortedNode;
                sortedNode = sortedNode.next;
                final = final.next;
            }
       
            return final2.next ; 
             */
            //imagine node is sorted here otherwise we have to create 2 methods 1. method we sort the node and cal the removeduplicaterecursive()
            
            if (node == null || node.next == null)
                return node;

            if (node.data == node.next.data) 
            {
                node.next = node.next.next;
                RemoveDuplicatesFromListIterativeRecursive(node);
            }
               
            else
                RemoveDuplicatesFromListIterativeRecursive(node.next);
            return node;
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

            a.PrintList(root2);
            Console.WriteLine();

            root2=a.MergeSort(root2);
            Node NoDuplicteEleLinkedList = a.RemoveDuplicatesFromListIterativeRecursive(root2);
            a.PrintList(NoDuplicteEleLinkedList);
        }
    }
}

