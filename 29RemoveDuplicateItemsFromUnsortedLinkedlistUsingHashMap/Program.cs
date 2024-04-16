using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Remove Duplicate Items from unsorted linked list using HashMap .HashSet
//https://www.youtube.com/watch?v=Y4JQBzghL3k&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=30
namespace _29RemoveDuplicateItemsFromUnsortedLinkedlistUsingHashMap
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public void RemoveDuplicateItemsFromUnsortedLinkedlistUsingHashSet(Node node)
        {
            HashSet<int> nodes = new HashSet<int>();
            Node head = node;
            Node prev = null;
            while (node != null)
            {
                if (!nodes.Contains(node.data))
                {
                    nodes.Add(node.data);
                    prev = node;
                    node = node.next;
                }
                else
                {
                    prev.next = node.next;
                    node = node.next;
                }
            }
            while(head!=null) { Console.WriteLine(head.data); head = head.next; }
                
        }
        public Node RemoveDuplicateItemsFromUnsortedLinkedlistUsingHashMap(Node node)
        {
            if (node == null) return null;
            Dictionary<int, int> dic = new Dictionary<int, int>();

            Node head = node;
            Node prev = null;
            while (node!= null)
            {
                if(!dic.ContainsKey(node.data))
                {
                    dic[node.data] = 1;
                    prev = node;
                    node = node.next;
                }
                else
                {
                    prev.next = node.next;
                    node = node.next;
                }
            }
            return head;
        }
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
                node = RemoveDuplicatesFromListIterativeRecursive(node);
            }
            else
            {
                node.next = RemoveDuplicatesFromListIterativeRecursive(node.next);
            }
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
            
            Linked a = new Linked();

            //root2 = a.Insert(12, root2);
            //root2 = a.Insert(99, root2);
            //root2 = a.Insert(18, root2);
            //root2 = a.Insert(8, root2);
            //root2 = a.Insert(18, root2);
            //root2 = a.Insert(118, root2);
            //root2 = a.Insert(118, root2);
            root2 = a.Insert(2, root2);
            root2 = a.Insert(3, root2);
            root2 = a.Insert(4, root2);
            root2 = a.Insert(4, root2);
            root2 = a.Insert(4, root2);
            root2 = a.Insert(5, root2);
            root2 = a.Insert(6, root2);
            root2 = a.Insert(6, root2);
            root2 = a.Insert(4, root2);
            root2 = a.Insert(6, root2);

            a.PrintList(root2);
            Console.WriteLine();

            //root2 = a.MergeSort(root2);
            //a.PrintList(root2);
            //Console.WriteLine();
            //Node NoDuplicteEleLinkedList = a.RemoveDuplicatesFromListIterativeRecursive(root2);
            //a.PrintList(NoDuplicteEleLinkedList);
            a.RemoveDuplicateItemsFromUnsortedLinkedlistUsingHashSet(root2);
            root2= a.RemoveDuplicateItemsFromUnsortedLinkedlistUsingHashMap(root2);
            a.PrintList(root2);
        }
    }
}
