using System;
using System.Collections.Generic;

namespace _009_Stack_BalancedBracket
{
    class Program
    {
        static Stack balanceBracket = null;

        static Dictionary<char, char> bracketMapping = new Dictionary<char, char>();

        static void Main(string[] args)
        {
            bracketMapping.Add(')', '(');
            bracketMapping.Add('}', '{');
            bracketMapping.Add(']', '[');

            balanceBracket = new _009_Stack_BalancedBracket.Stack();
            Console.WriteLine(isBalanced("{[()]}")); 

            balanceBracket = new _009_Stack_BalancedBracket.Stack();
            Console.WriteLine(isBalanced("{[(])}"));

            balanceBracket = new _009_Stack_BalancedBracket.Stack();
            Console.WriteLine(isBalanced("{{[[(())]]}}"));
        }

        // Complete the isBalanced function below.
        static string isBalanced(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    balanceBracket.Push(s[i]);
                }
                else if (balanceBracket.IsEmpty() || balanceBracket.Top() != bracketMapping[s[i]])
                {
                    return "NO";
                }
                else
                {
                    balanceBracket.Pop();
                }
            }

            if (balanceBracket.IsEmpty())
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
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

        public void Push(char bracket)
        {
            StackNode node = new StackNode(bracket);
            node.Next = Head;
            Head = node;
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
                    System.Console.Write(node.Bracket + " ");
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
                return head.Bracket;
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
                return Head.Bracket;
            }
        }
    }

    class StackNode
    {
        public char Bracket;
        public StackNode Next;

        public StackNode(char bracket)
        {
            Bracket = bracket;
        }
    }
}
