
using System;

namespace _008_Stack_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack1 = new _008_Stack_LinkedList.Stack();
            stack1.Push(3);
            stack1.Push(5);
            stack1.Push(2);
            stack1.Push(6);
            stack1.Push(9);
            stack1.Print();
            stack1.Pop();
            stack1.Pop();
            stack1.Print();
            stack1.Top();
            stack1.Print();

            Console.Read();
        }
    }

    class Stack
    {
        public StackNode Head;

        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            else
                return false;
        }

        public void Push(int data)
        {
            StackNode node = new StackNode(data);
            node.Next = Head;
            Head = node;
            System.Console.WriteLine("Push - " + data);
        }

        public void Print()
        {
            if (Head == null)
                System.Console.WriteLine("Stack is empty");
            else
            {
                System.Console.WriteLine("*******************");

                StackNode node = Head;
                while (node != null)
                {
                    System.Console.Write(node.Data + " ");
                    node = node.Next;
                }
                Console.WriteLine();
                System.Console.WriteLine("*******************");
            }
        }

        public int Pop()
        {
            if (Head == null)
            {
                throw new System.Exception("Stack is empty");
            }
            else
            {
                StackNode head = Head;
                Head = Head.Next;
                System.Console.WriteLine("Pop - " + head.Data);
                return head.Data;
            }
        }

        public int Top()
        {
            if (Head == null)
            {
                throw new System.Exception("Stack is empty");
            }
            else
            {
                System.Console.WriteLine("Top - " + Head.Data);
                return Head.Data;
            }
        }
    }

    class StackNode
    {
        public int Data;
        public StackNode Next;

        public StackNode(int data)
        {
            Data = data;
        }
    }
}
