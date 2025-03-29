
using System;

namespace _006_DoublyLinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList dList = new DoublyLinkedList();

            DoublyLinkedListManager doublyLinkedListManger = new _006_DoublyLinkList.DoublyLinkedListManager();
            
            dList.Head = doublyLinkedListManger.InsertAtHead(10);
            dList.Head = doublyLinkedListManger.InsertAtHead(4);
            dList.Head = doublyLinkedListManger.InsertAtHead(3);
            dList.Head = doublyLinkedListManger.InsertAtHead(1);
            //dList.Head = doublyLinkedListManger.InsertAtHead(10);

            doublyLinkedListManger.Print(dList.Head);
            Console.WriteLine();

            dList.Head = doublyLinkedListManger.SortedInsert(dList.Head, 5);
            doublyLinkedListManger.Print(dList.Head);
            Console.WriteLine();

            dList.Head = doublyLinkedListManger.SortedInsert(dList.Head, 2);
            doublyLinkedListManger.Print(dList.Head);
            Console.WriteLine();

            dList.Head = doublyLinkedListManger.SortedInsert(dList.Head, 11);
            doublyLinkedListManger.Print(dList.Head);
            Console.WriteLine();

            dList.Head = doublyLinkedListManger.SortedInsert(dList.Head, 1);
            doublyLinkedListManger.Print(dList.Head);
            Console.WriteLine();

            //doublyLinkedListManger.ReversePrint(dList.Head);
            //Console.WriteLine();

            //dList.Head = doublyLinkedListManger.Reverse(dList.Head);
            //doublyLinkedListManger.Print(dList.Head);

            Console.Read();
        }
    }

    public class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedListNode Head;
    }

    public class DoublyLinkedListManager
    {
        private DoublyLinkedListNode head;

        public DoublyLinkedListNode InsertAtHead(int data)
        {
            if (head == null)
                head = GetDoublyLinkedListNode(data);
            else
            {
                DoublyLinkedListNode node = GetDoublyLinkedListNode(data);
                head.prev = node;
                node.next = head;
                head = node;
            }

            return head;
        }

        private DoublyLinkedListNode GetDoublyLinkedListNode(int data)
        {
            DoublyLinkedListNode node = new _006_DoublyLinkList.DoublyLinkedListNode();
            node.data = data;
            node.next = null;
            node.prev = null;

            return node;
        }

        public void ReversePrint(DoublyLinkedListNode head)
        {
            if (head == null)
                return;

            DoublyLinkedListNode node = head;

            while (node.next != null)
            {
                //Console.Write(node.Data + "-> ");
                node = node.next;
            }
            // Now node becomes the last node of the list
            while (node != null)
            {
                Console.Write(node.data + "-> ");
                node = node.prev;
            }
        }

        public void Print(DoublyLinkedListNode head)
        {
            DoublyLinkedListNode node = head;

            while (node != null)
            {
                Console.Write(node.data + "-> ");

                node = node.next;
            }
        }

        public DoublyLinkedListNode Reverse(DoublyLinkedListNode head)
        {
            DoublyLinkedListNode current = head;
            DoublyLinkedListNode next = null;
            DoublyLinkedListNode pre = null;

            while (current != null)
            {
                next = current.next;
                current.next = pre;
                current.prev = next;
                pre = current;
                current = next;
            }

            return pre;
        }

        public DoublyLinkedListNode SortedInsert(DoublyLinkedListNode head, int data)
        {
            DoublyLinkedListNode node = GetDoublyLinkedListNode(data);
            if (head == null)
                return node;

            DoublyLinkedListNode current = head;
            DoublyLinkedListNode pre = null;

            while (current != null)
            {
                if (node.data < current.data)
                {
                    if (pre == null)
                    {
                        head = node;
                    }
                    else
                    {
                        pre.next = node;
                        node.prev = pre;
                    }
                    node.next = current;
                    current.prev = node;

                    return head;
                }
                else
                {
                    pre = current;
                    current = current.next;
                }
            }
            pre.next = node;
            node.prev = pre;

            return head;
        }
    }
}