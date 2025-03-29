using System;
using System.Collections.Generic;

namespace _005_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            //SinglyLinkedList llist = new SinglyLinkedList();

            //int llistCount = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < llistCount; i++)
            //{
            //    int llistItem = Convert.ToInt32(Console.ReadLine());
            //    SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
            //    llist.head = llist_head;
            //}

            //printLinkedList(llist.head);

            //insertNodeAtPosition(llist.head, 6, 2);
            //insertNodeAtPosition(llist.head, 36, 0);
            //insertNodeAtPosition(llist.head, 363, 10);

            Console.WriteLine("********Print***********");
            printLinkedList(llist.head);

            //llist.head = reverseByRecursion(llist.head);

            //Console.WriteLine("********Print***********");
            //printLinkedList(llist.head);

            int position = Convert.ToInt32(Console.ReadLine());
            int result = getNode(llist.head, position);
            Console.WriteLine(result);

            Console.ReadLine();
        }

        static int getNode(SinglyLinkedListNode head, int positionFromTail)
        {
            int count = 0;
            SinglyLinkedListNode node = head;
            while (node != null)
            {
                node = node.next;
                count++;
            }

            int iterateTill = count - positionFromTail - 1;
            node = head;
            for (int i = 0; i < iterateTill; i++)
            {
                node = node.next;
            }

            return node.data;
        }

        private static void printLinkedList(SinglyLinkedListNode head)
        {
            if (head != null)
            {
                Console.WriteLine(head.data);
                SinglyLinkedListNode node = head.next;
                while (node != null)
                {
                    Console.WriteLine(node.data);
                    node = node.next;
                }
            }
        }

        private static void printLinkedListByRecursion(SinglyLinkedListNode head)
        {
            if (head != null)
            {
                Console.WriteLine(head.data);
                printLinkedListByRecursion(head.next);
            }
            else
            {
                return;
            }
        }

        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            SinglyLinkedListNode tempNode = new SinglyLinkedListNode(data);

            if (llist == null)
            {
                llist = tempNode;
            }
            else
            {
                SinglyLinkedListNode temp2 = llist;
                llist = tempNode;
                tempNode.next = temp2;
            }

            return llist;
        }

        static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            SinglyLinkedListNode temp = new SinglyLinkedListNode(data);

            if (head != null)
            {
                SinglyLinkedListNode node = head;
                while (node.next != null)
                {
                    node = node.next;
                }

                node.next = temp;
            }
            else
            {
                head = temp;
            }

            return head;
        }

        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                SinglyLinkedListNode temp = head;
                SinglyLinkedListNode preNode = null;

                for (int i = 0; i < position; i++)
                {
                    if (temp.next != null)
                    {
                        preNode = temp;
                        temp = temp.next;
                    }
                }

                preNode.next = node;
                node.next = temp;
            }

            return head;
        }

        static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            if (head == null)
            {
                //head = head;
            }
            else
            {
                if (position == 0)
                {
                    head = head.next;
                }
                else
                {
                    SinglyLinkedListNode temp = head;
                    SinglyLinkedListNode preNode = null;

                    for (int i = 0; i < position; i++)
                    {
                        if (temp.next != null)
                        {
                            preNode = temp;
                            temp = temp.next;
                        }
                    }

                    preNode.next = temp.next;
                }
            }

            return head;
        }

        static void reversePrint(SinglyLinkedListNode head)
        {
            Stack<int> stackData = new Stack<int>();

            // traverse the LinkedList and insert the data in stack
            SinglyLinkedListNode node = head;
            while (node != null)
            {
                stackData.Push(node.data);
                node = node.next;
            }

            if (stackData.Count > 0)
            {
                while (stackData.Count > 0)
                {
                    Console.WriteLine(stackData.Pop());
                }
            }
        }

        static void reversePrintByRecursion(SinglyLinkedListNode head)
        {
            if (head != null)
            {
                reversePrintByRecursion(head.next);
                Console.WriteLine(head.data);
            }
            else
            {
                return;
            }
        }

        static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode current, next, prev;
            prev = null;
            current = head;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;

            return head;
        }

        static SinglyLinkedListNode reverseByRecursion(SinglyLinkedListNode node)
        {
            if (node.next == null)
            {
                return node;
            }

            SinglyLinkedListNode lastElement = reverseByRecursion(node.next);

            SinglyLinkedListNode temp = node.next;
            temp.next = node;
            node.next = null;

            return lastElement;
        }
    }

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }
}