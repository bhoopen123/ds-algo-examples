using System;
using System.Collections.Generic;

namespace PostfixEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Postfix expression (space is delimiter)");
            string postfixExpression = Console.ReadLine();

            Console.WriteLine(EvaluatePostfix(postfixExpression));
            Console.Read();
        }

        static float EvaluatePostfix(string expression)
        {
            string[] nodes = expression.Split(' ');
            Stack<float> stack = new Stack<float>();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (IsOperand(nodes[i]))
                {
                    stack.Push(float.Parse(nodes[i]));
                }
                else
                {
                    // operator, perform evaluation/operation
                    float operand2 = stack.Pop();
                    float operand1 = stack.Pop();
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
