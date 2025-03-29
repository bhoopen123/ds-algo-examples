using System;
using System.IO;

namespace _007_Stack
{
    class Solution
    {
        class StckNode
        {
            public int Data;
            public int CurrHeight;

            public StckNode(int data, int currHeight)
            {
                this.Data = data;
                this.CurrHeight = currHeight;
            }
        }

        class Stack
        {
            StckNode[] stackNodes = new StckNode[100000];
            public int Top = -1;
            public int CurrHeight = 0;
            public void Push(int height)
            {
                if (Top < 0)
                {
                    CurrHeight = height;
                }
                else
                {
                    CurrHeight += height;
                }

                Top++;
                stackNodes[Top] = new StckNode(height, CurrHeight);
            }

            public int Pop()
            {
                if (Top < 0)
                {
                    throw new Exception("Stack is empty");
                }
                int result = stackNodes[Top].Data;
                stackNodes[Top] = null;

                CurrHeight = CurrHeight - result;
                Top--;
                return result;
            }

            public bool IsEmpty()
            {
                if (Top < 0)
                    return true;
                else
                    return false;
            }

            public StckNode TopNode()
            {
                if (Top < 0)
                {
                    return null;
                }

                return stackNodes[Top];
            }
        }

        static Stack[] stacks = new Stack[3];

        /*
         * Complete the equalStacks function below.
         */
        static int equalStacks(int[] h1, int[] h2, int[] h3)
        {
            /*
             * Write your code here.
             */

            // Filling stacks, this will also fill the Heights...
            stacks[0] = new Stack();
            stacks[1] = new Stack();
            stacks[2] = new Stack();

            FillStack(stacks[0], h1);
            FillStack(stacks[1], h2);
            FillStack(stacks[2], h3);

            while (AreNotEqual(stacks))
            {
                // find stack with Max height and remove top cylendar.
                FindAndRemoveTopCylendarFromTallestStack(stacks);
            }

            return stacks[0].CurrHeight;
        }

        private static void FindAndRemoveTopCylendarFromTallestStack(Stack[] stacks)
        {
            int tallestStackIndex = 0;

            for (int i = 1; i < stacks.Length; i++)
            {
                if (stacks[tallestStackIndex].CurrHeight < stacks[i].CurrHeight)
                {
                    tallestStackIndex = i;
                }
            }

            if (stacks[tallestStackIndex].Top > -1)
            {
                stacks[tallestStackIndex].Pop();
            }
        }

        private static bool AreNotEqual(Stack[] stacks)
        {
            for (int i = 0; i < stacks.Length - 1; i++)
            {
                int j = i + 1;

                if (stacks[i].CurrHeight != stacks[j].CurrHeight)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FillStack(Stack stack, int[] heights)
        {
            int counter = heights.Length;
            while (counter > 0)
            {
                counter--;
                stack.Push(heights[counter]);
            }
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] n1N2N3 = Console.ReadLine().Split(' ');

            int n1 = Convert.ToInt32(n1N2N3[0]);

            int n2 = Convert.ToInt32(n1N2N3[1]);

            int n3 = Convert.ToInt32(n1N2N3[2]);

            int[] h1 = Array.ConvertAll(Console.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp));

            int[] h2 = Array.ConvertAll(Console.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp));

            int[] h3 = Array.ConvertAll(Console.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp));
            int result = equalStacks(h1, h2, h3);

            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
