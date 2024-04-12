using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=FzLsKI7Auhc&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=27
//Delete N nodes after M Nodes of a Linked List
namespace _27DeleteNNodesAfterMNodesOfLinkedList
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node DeleteNNodesAfterMNodes(Node node,int n,int m)
        {
            Console.WriteLine("List after deleteing {0} elements after {1} elements", n, m);
            if (node == null)
                return node;

            if (n == 0)
                return node;
            Node final = node;  Node right = null; int after = m;    int deleteCount = n;
            
            while(after>1)
            {
                after--;
                node=node.next;
                if(node==null)
                { Console.WriteLine("AFTER ELEMENTS(SIZE OF M) IS GREATER THAN THE LIST SIZE)"); return node; }
            }
           right = (m > 0) ? node.next:node;            //checking if m>0

            while(deleteCount >= 1)
            {
                deleteCount--;
                right=right.next;
                if(right== null)
                {
                    Console.WriteLine("Not enough elements to delete");       //4->5->6->7->8->X delete 5 ele after 2 elements  . we will return original node
                    return node;
                }
            }
            if (m == 0)
                return right;
            node.next=right;
            return final;
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
            
            Node final = a.DeleteNNodesAfterMNodes(root,1,199);
            
            a.PrintList(final);
        }
    }
}
