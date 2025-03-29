using System;
using System.Text;
using System.Collections.Generic;

namespace InfixToPostfix
{
    class Program
    {
        static Dictionary<char, int> operatorPrecedence = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            operatorPrecedence.Add('/', 1);
            operatorPrecedence.Add('*', 2);
            operatorPrecedence.Add('+', 3);
            operatorPrecedence.Add('-', 4);

            Console.WriteLine("Enter Infix expression : ");
            string infixExp = Console.ReadLine();
            string postfixExp = InfixToPostfixWithPara(infixExp);

            Console.WriteLine("Postfix expression : ");
            Console.WriteLine(postfixExp);

            Console.ReadKey();
        }

        static string InfixToPostfixWithPara(string exp)
        {
            StringBuilder result = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; i++)
            {
                if (IsOperand(exp[i]))
                {
                    result.Append(exp[i]);
                }
                else if (IsOpeningParantheses(exp[i]))
                {
                    stack.Push(exp[i]);
                }
                else if (IsClosingParantheses(exp[i]))
                {
                    while (stack.Count > 0 && !IsOpeningParantheses(stack.Peek()))
                    {
                        result.Append(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && HasHigherPrecedence(stack.Peek(), exp[i]))
                    {
                        result.Append(stack.Pop());
                    }
                    stack.Push(exp[i]);
                }
            }

            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }

            return result.ToString();
        }

        private static bool IsClosingParantheses(char character)
        {
            if (character == ')' || character == '}' || character == ']')
                return true;
            else
                return false;
        }

        private static bool IsOpeningParantheses(char character)
        {
            if (character == '(' || character == '{' || character == '[')
                return true;
            else
                return false;
        }

        static string InfixToPostfix(string exp)
        {
            //string result = string.Empty;
            StringBuilder result = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; i++)
            {
                if (IsOperand(exp[i]))
                {
                    result.Append(exp[i]);
                }
                else
                {
                    while (stack.Count > 0 && HasHigherPrecedence(stack.Peek(), exp[i]))
                    {
                        result.Append(stack.Pop());
                    }

                    stack.Push(exp[i]);
                }
            }

            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }

            return result.ToString();
        }

        private static bool HasHigherPrecedence(char c1, char c2)
        {
            try
            {
                if (operatorPrecedence[c1] < operatorPrecedence[c2])
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool IsOperand(char character)
        {
            if (character == '+' || character == '-' || character == '/' || character == '*'
                || IsOpeningParantheses(character) || IsClosingParantheses(character))
                return false;
            else
                return true;
        }
    }
}
