using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Flatten a Sorted multilevel linked list
//https://www.youtube.com/watch?v=ykelywHJWLg
//https://www.youtube.com/watch?v=PazsaUFz9io&list=PLt4nG7RVVk1gDMcCZkpjOxZS4XMro29DU&index=28
namespace _28FlattenASortedMultilevelLinkedlist
{
    class Node
    {
        public Node rightNext;
        public Node childDownNext;
        public int data;
    }

    class Linked
    {
        public Node FlattenMultiLevelLinkeList(Node node)
        {
            /*  Using Iteration
            if(node==null || node.rightNext==null)
                return null;
            while(node.rightNext.rightNext!=null)
                node = node.rightNext;
            
            Node linkedlist1 = node.rightNext;
            node.rightNext = null;
            Node linkedlist2 = node;
            Node sortedNode=Merge2SortedLists(linkedlist1 ,linkedlist2);  */

            /*
             //My own way of Recursion
           if(node==null || node.rightNext==null)
               return null;
           if(node.rightNext.rightNext != null)
           {
               node.rightNext = FlattenMultiLevelLinkeList(node.rightNext);
           }
           Node linkedlist1 = node.rightNext;
          // node.rightNext = null;
           Node linkedlist2 = node;
           Node sortedNode = Merge2SortedLists(linkedlist1, linkedlist2);
           return sortedNode;
           */

            //best approach
            if (node == null || node.rightNext == null)
                return node;
            return Merge2SortedLists(node, FlattenMultiLevelLinkeList(node.rightNext));
        }
        public Node Merge2SortedLists(Node linkedlist1,Node linkedlist2)
        {
            Node sortedNodeTemp=new Node();
            Node sortedNodeFinal = sortedNodeTemp;

            while(linkedlist1!=null && linkedlist2!=null)
            {
                if(linkedlist1.data<=linkedlist2.data)
                {
                    sortedNodeTemp.childDownNext= linkedlist1;
                    linkedlist1 = linkedlist1.childDownNext;
                }
                else
                {
                    sortedNodeTemp.childDownNext= linkedlist2;
                    linkedlist2 = linkedlist2.childDownNext;
                }
                sortedNodeTemp = sortedNodeTemp.childDownNext;
            }
            sortedNodeTemp.childDownNext = (linkedlist1 != null) ? linkedlist1 : linkedlist2;
            sortedNodeFinal.childDownNext.rightNext = null;
            return sortedNodeFinal.childDownNext;
        }
        public Node Insert(int data,Node node)
        {
            if(node == null)    
                return GetNewNode(data);
            Node actualNode = node;
            while(node.childDownNext!=null)
            {
                node = node.childDownNext;
            }
            node.childDownNext = GetNewNode(data);

            return actualNode;
        }
        
        public Node GetNewNode(int data) 
        {
            Node node = new Node()
            {
                data = data,
                childDownNext = null,
                rightNext = null
            };
            return node;
        }
        public void Print(Node node)
        {
            if (node == null)
                Console.WriteLine("nothing to print in the list. It is empty");

            Node actualNode = node;
            while(actualNode != null)
            {
                while (node != null)
                {
                    Console.WriteLine(node.data);
                    node = node.childDownNext;
                }
                actualNode = actualNode.rightNext;
                node = actualNode;
            }
        }
        
    }

    public class LinkedListFlatten
    {
        public static void Main(string[] args)
        {
            Node root=null;
            Linked l = new Linked();

            root = l.Insert(3,root);
            //root = l.Insert(20, root);
            //root = l.Insert(22, root);
            //root = l.Insert(25, root);
            //root = l.Insert(65, root);
            //root = l.Insert(70, root);

            root.rightNext=l.Insert(2,root.rightNext);
            root.rightNext=l.Insert(10,root.rightNext);

            root.rightNext.rightNext = l.Insert(1, root.rightNext.rightNext);
            root.rightNext.rightNext = l.Insert(7, root.rightNext.rightNext);
            root.rightNext.rightNext = l.Insert(11, root.rightNext.rightNext);
            root.rightNext.rightNext = l.Insert(12, root.rightNext.rightNext);

            root.rightNext.rightNext.rightNext = l.Insert(4, root.rightNext.rightNext.rightNext);
            root.rightNext.rightNext.rightNext = l.Insert(9, root.rightNext.rightNext.rightNext);

            root.rightNext.rightNext.rightNext.rightNext = l.Insert(5, root.rightNext.rightNext.rightNext.rightNext);
            root.rightNext.rightNext.rightNext.rightNext = l.Insert(6, root.rightNext.rightNext.rightNext.rightNext);
            root.rightNext.rightNext.rightNext.rightNext = l.Insert(8, root.rightNext.rightNext.rightNext.rightNext);

            l.Print(root);
            Console.WriteLine("node after flattening");
            Node flattenedNode= l.FlattenMultiLevelLinkeList(root);
            l.Print(flattenedNode);
        }
    }
}
