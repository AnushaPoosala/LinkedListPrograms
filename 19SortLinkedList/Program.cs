using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=8ocB7a_c-Cc
//https://www.youtube.com/watch?v=iAvB3fxAvI4&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=20
//MergeSortLinkedList
namespace _19SortLinkedList
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {
        public Node MergeSort(Node node)
        {
            if (node == null || node.next == null)
                return node;

            Node middle= MiddleNode(node);

            Node right = middle.next;
            middle.next = null;
            Node left = node;

            left=MergeSort(left);
            right=MergeSort(right);

            return MergeTwoLinkedLists(left, right);
            
        }
        public Node MergeTwoLinkedLists(Node list1, Node list2)
        {
            Node temp = new Node();
            Node final = temp;
            while(list1 != null && list2!=null)
            {
                if (list1.data < list2.data)
                { temp.next = list1;
                    list1 = list1.next;
                }
                else
                { temp.next = list2; list2 = list2.next; }
                temp = temp.next;
            }
            if (list1 != null)
                temp.next= list1;
            if(list2 != null)
                temp.next= list2;

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

            //root = a.Insert(12, root);
            //root = a.Insert(99, root);
            //root = a.Insert(37, root);
            //root = a.Insert(8, root);
            //root = a.Insert(18, root);
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

            Node sorted = a.MergeSort(root);
            a.PrintList(sorted);
        }
    }
}
//arrays Merge sort for reference
/*
 *   using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rough
{
    internal class Program
    {
        public void MergeSort(int[] arr,int start,int end)
        {
           if(start<end)
            {
                int mid = (start + end) / 2;
                MergeSort(arr, start, mid);
                MergeSort(arr,mid+1,end);
                Sorting2Arrays(arr, start, mid, end);
            }
        }
        public void Sorting2Arrays(int[] arr,int start,int mid,int end)
        {
            int leftStart=start;int leftEnd = mid;    int rightStart = mid + 1; int rightend = end;
            int[] temp=new int[end-start+1];    int tempstart = 0;
            while(leftEnd>= leftStart && rightend>= rightStart)
            {
                if (arr[leftStart] <= arr[rightStart])
                    temp[tempstart++] = arr[leftStart++];
                else
                    temp[tempstart++] = arr[rightStart++];
            }
            while(leftEnd>= leftStart)
                temp[tempstart++] = arr[leftStart++];
            while(rightend >= rightStart)
                temp[tempstart++] = arr[rightStart++];

            for(int i = 0; i < tempstart; i++)
            {
                arr[start + i] = temp[i];
            }
        }
        static void Main(string[] args)
        {
            int[] arr = {7, 1, 9, 8, 5,88,6 };
            Program p = new Program();
            p.MergeSort(arr,0,arr.Length-1);

            foreach(var ele in arr)
                Console.WriteLine(ele);
        }
    }
}

 */
