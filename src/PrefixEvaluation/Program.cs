using System;
using System.Collections.Generic;

namespace PrefixEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Prefix expression (space is delimiter)");
            string prefixExpression = Console.ReadLine();

            Console.WriteLine(EvaluatePrefix(prefixExpression));
            Console.Read();
        }

        private static float EvaluatePrefix(string prefixExpression)
        {
            string[] nodes = prefixExpression.Split(' ');
            Stack<float> stack = new Stack<float>();

            for (int i = (nodes.Length - 1); i > -1; i--)
            {
                if (IsOperand(nodes[i]))
                {
                    stack.Push(float.Parse(nodes[i]));
                }
                else
                {
                    // operator, perform evaluation/operation
                    float operand1 = stack.Pop();
                    float operand2 = stack.Pop();
                    float result = Perform(operand1, operand2, nodes[i]);
                    stack.Push(result);
                }
            }

            return stack.Peek();
        }

        private static float Perform(float operand1, float operand2, string myOperator)
        {
            switch (myOperator)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                default:
                    return 0;
            }
        }

        private static bool IsOperand(string node)
        {
            if (node == "+" || node == "-" || node == "*" || node == "/")
                return false;
            else
                return true;
        }
    }
}
