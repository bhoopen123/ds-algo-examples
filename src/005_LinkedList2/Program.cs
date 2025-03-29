using System;
using System.Collections.Generic;

namespace _005_LinkedList2
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new _005_LinkedList2.SinglyLinkedList();
            SinglyLinkedList list1 = new _005_LinkedList2.SinglyLinkedList();
            SinglyLinkedList list2 = new _005_LinkedList2.SinglyLinkedList();

            //Console.WriteLine("Enter count : ");
            //int count = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < count; i++)
            //{
            //    list.Insert(Convert.ToInt32(Console.ReadLine()));
            //}

            //Console.WriteLine("Print List ");
            //list.Print(list.Head);

            //Console.WriteLine();
            //Console.WriteLine("Print Reverse ");
            //list.PrintReverse(list.Head);

            //Console.WriteLine();
            //Console.WriteLine("GetNode ");
            //Console.WriteLine(list.GetNode(list.Head, 3));


            //Console.WriteLine("Enter count for list1 : ");
            //int count1 = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < count1; i++)
            //{
            //    list1.Insert(Convert.ToInt32(Console.ReadLine()));
            //}

            //Console.WriteLine();
            //Console.WriteLine("Enter count for list2 : ");
            //int count2 = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < count2; i++)
            //{
            //    list2.Insert(Convert.ToInt32(Console.ReadLine()));
            //}

            //Console.WriteLine("Merging lists ");

            //SinglyLinkedListNode mergedListHead = MergeLists(list1.Head, list2.Head);
            //Print(mergedListHead);


            //int tests = Convert.ToInt32(Console.ReadLine());

            //for (int testsItr = 0; testsItr < tests; testsItr++)
            //{
            //    SinglyLinkedList llist1 = new SinglyLinkedList();

            //    int llist1Count = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < llist1Count; i++)
            //    {
            //        int llist1Item = Convert.ToInt32(Console.ReadLine());
            //        llist1.Insert(llist1Item);
            //    }

            //    SinglyLinkedList llist2 = new SinglyLinkedList();

            //    int llist2Count = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < llist2Count; i++)
            //    {
            //        int llist2Item = Convert.ToInt32(Console.ReadLine());
            //        llist2.Insert(llist2Item);
            //    }

            //    SinglyLinkedListNode llist3 = MergeLists(llist1.Head, llist2.Head);

            //    Print(llist3);
            //    Console.WriteLine();
            //}


            SinglyLinkedList llistWithDups = new SinglyLinkedList();

            int llist1Count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llist1Count; i++)
            {
                int llist1Item = Convert.ToInt32(Console.ReadLine());
                llistWithDups.Insert(llist1Item);
            }

            //SinglyLinkedListNode newHead = RemoveDuplicates(llistWithDups.Head);
            Print(llistWithDups.Head);
            Console.WriteLine();

            Console.WriteLine(HasCycleUsingHashtable(llistWithDups.Head));

            Console.ReadLine();
        }

        /// <summary>
        /// This is Brute Force technique
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        static int FindMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode traverseNode = head1;
            SinglyLinkedListNode checkNode = head2;

            while (checkNode != null)
            {
                while (traverseNode != null)
                {
                    if (checkNode == traverseNode)
                    { return checkNode.data; }
                    traverseNode = traverseNode.next;
                }

                traverseNode = head1;
                checkNode = checkNode.next;
            }

            return 0;
        }

        static int FindMergeNodeUsingMemoryTradeOff(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            Dictionary<SinglyLinkedListNode, bool> storedAddresses = new Dictionary<_005_LinkedList2.SinglyLinkedListNode, bool>();
            SinglyLinkedListNode node1 = head1;

            while (node1 != null)
            {
                storedAddresses.Add(node1, true);
                node1 = node1.next;
            }

            SinglyLinkedListNode node2 = head2;
            while (node2 != null)
            {
                if (storedAddresses.ContainsKey(node2))
                    return node2.data;
                node2 = node2.next;
            }

            return 0;
        }

        /// <summary>
        ///  Use the method when it is sure that lists are merged
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        static int FindMergeNodeUsingHeadSwap(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode current1 = head1;
            SinglyLinkedListNode current2 = head2;

            while (current1 != current2)
            {
                if (current1 == null)
                    current1 = head2;
                else
                    current1 = current1.next;

                if (current2 == null)
                    current2 = head1;
                else
                    current2 = current2.next;
            }

            return current2.data;

        }

        static bool HasCycleUsingHashtable(SinglyLinkedListNode head)
        {
            Dictionary<SinglyLinkedListNode, bool> visitorMap = new Dictionary<SinglyLinkedListNode, bool>();

            SinglyLinkedListNode node = head;
            while (node != null)
            {
                if (visitorMap.ContainsKey(node))
                {
                    return true;
                }
                else
                {
                    visitorMap.Add(node, true);
                }

                node = node.next;
            }

            return false;
        }

        static bool HasCycle(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode slow = head;
            SinglyLinkedListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        static SinglyLinkedListNode RemoveDuplicates(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode curr = head;
            SinglyLinkedListNode pre = null;

            while (curr.next != null)
            {
                pre = curr;
                curr = curr.next;

                if (pre.data == curr.data)
                {
                    pre.next = curr.next;
                    curr = pre;
                }
            }

            return head;
        }

        static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;
            if (head1.data < head2.data)
            {
                // merging will happen in head1
                return StartMergingInto(head1, head2);
            }
            else
            {
                // merging will happen in head2
                return StartMergingInto(head2, head1);
            }
        }

        static SinglyLinkedListNode StartMergingInto(SinglyLinkedListNode intoNode, SinglyLinkedListNode fromNode)
        {
            SinglyLinkedListNode head = intoNode;
            SinglyLinkedListNode pre = intoNode;

            while (intoNode != null)
            {
                if (intoNode.data < fromNode.data)
                {
                    pre = intoNode;
                    intoNode = intoNode.next;
                }
                else
                {
                    SinglyLinkedListNode fromNext = fromNode.next;
                    InsertNodeAfter(pre, fromNode);
                    fromNode = fromNext;
                    pre = pre.next;
                    if (fromNode == null)
                    {
                        break;
                    }
                }
            }

            if (fromNode != null)
            {
                pre.next = fromNode;
            }

            return head;
        }

        static void InsertNodeAfter(SinglyLinkedListNode toNode, SinglyLinkedListNode fromNode)
        {
            SinglyLinkedListNode temp = toNode.next;
            toNode.next = fromNode;
            fromNode.next = temp;
        }

        static void Print(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode node = head;
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }
    }


    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int data)
        {
            this.data = data;
        }
    }
    class SinglyLinkedList
    {
        public SinglyLinkedListNode Head = null;
        private SinglyLinkedListNode _tail = null;

        public SinglyLinkedList()
        {
            Head = null;
            _tail = null;
        }

        public void Insert(int data)
        {
            SinglyLinkedListNode node = new _005_LinkedList2.SinglyLinkedListNode(data);
            if (Head == null)
            {
                Head = node;
                _tail = node;
            }
            else
            {
                _tail.next = node;
                _tail = node;
            }
        }



        public void PrintReverse(SinglyLinkedListNode node)
        {
            if (node == null)
            {
                return;
            }

            PrintReverse(node.next);
            Console.Write(node.data + "->");
        }

        public int GetNode(SinglyLinkedListNode head, int positionFromTail)
        {
            SinglyLinkedListNode node = head;
            SinglyLinkedListNode resultNode = head;
            int counter = 0;
            while (node != null)
            {
                if (counter > positionFromTail)
                {
                    resultNode = resultNode.next;
                }
                counter++;
                node = node.next;
            }

            return resultNode.data;
        }

        public bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode node1 = head1;
            SinglyLinkedListNode node2 = head2;

            while (node1 != null)
            {
                if (node2 == null || node1.data != node2.data)
                {
                    return false;
                }
                node1 = node1.next;
                node2 = node2.next;
            }
            if (node2 != null)
            {
                return false;
            }

            return true;
        }


    }
}