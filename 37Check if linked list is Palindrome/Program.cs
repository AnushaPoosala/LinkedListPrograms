using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=lRY_G-u_8jk
//https://www.youtube.com/watch?v=KMU8VeAvLko&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=38
// Check if linked list is Palindrome
namespace _37Check_if_linked_list_is_Palindrome
{
    class Node
    {
        public Node next;
        public int data;
    }

    class Linked
    {            //12 99 37 5 37 99 12
        public bool CheckIfLLIsPalindrome(Node head)
        {
            //best approach
            if (head == null || head.next == null)
            {
                return false;
            }
            Node firstPartOfNode = head;
            Node slow, fast;
            slow = fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            Node newHead = ReverseLinkedList(slow.next);
            Node secondHalf = newHead;
            while (secondHalf != null)
            {
                if (secondHalf.data != firstPartOfNode.data)
                    return false;
                secondHalf = secondHalf.next;
                firstPartOfNode = firstPartOfNode.next;
            }
            ReverseLinkedList(newHead);    //It is optional but best practice to keep head as it is
            PrintList(head);
            return true;

            /*
            if (head == null || head.next == null)
            {
                return false;
            }
            Node firstPartOfNode = head;
            Stack<int> stack = new Stack<int>();
            Node slow, fast;
            slow = fast = head;
            stack.Push(slow.data);
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                stack.Push(slow.data);
            }
            if (fast.next == null)
                stack.Pop();
            Node secondHalf = slow.next;
            while(secondHalf!=null)
            {
                if(stack.Pop()!= secondHalf.data)
                {
                    return false;
                }
                secondHalf = secondHalf.next;
            }
            return true;
            */
        }
        public Node ReverseLinkedList(Node head)
        {
            //Recursion
            if (head == null || head.next == null) { return head; }
            Node newNode= ReverseLinkedList(head.next);
            Node curr = head.next;
            curr.next= head;
            head.next = null; //head is like prev in below iteration approach
            return newNode;

            /* Iteration
            if(head== null || head.next == null) { return head; }
            Node prev=head;
            Node curr = head.next;
            while (curr!=null)
            {
                Node next = curr.next;

                curr.next = prev;
                //prev.next = null;

                prev = curr;
                curr = next;
            }
            head.next = null;
            return prev;*/
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

            System.Console.Write(node.data + " ");
            PrintList(node.next);
        }
    }

    public class LinkedListApp
    {

        public static void Main(string[] args)
        {

            Node head = null;
            Linked a = new Linked();

            head = a.Insert(12, head);
            head = a.Insert(99, head);
            head = a.Insert(37, head);
           // head = a.Insert(5, head);
            head = a.Insert(397, head);
            head = a.Insert(99, head);
            head = a.Insert(12, head);
            a.PrintList(head); Console.WriteLine();
            Console.WriteLine(a.CheckIfLLIsPalindrome(head));
            //a.PrintList(head);
        }
    }
}

