using System;

namespace _007_Stack
{
    class Program
    {
        class StckNode
        {
            public int Data;
            public int CurrMax;

            public StckNode(int data, int currMax)
            {
                this.Data = data;
                this.CurrMax = currMax;
            }
        }

        static StckNode[] stack = new StckNode[100000];
        static int top = -1;
        static void Main(string[] args)
        {
            //1 x - Push the element x into the stack.
            //2 - Delete the element present at the top of the stack.
            //3 - Print the maximum element in the stack.
            int queryCount = Convert.ToInt32(Console.ReadLine());
            while (queryCount > 0)
            {
                //Console.WriteLine("1 x - Push the element x into the stack.");
                //Console.WriteLine("2 - Delete the element present at the top of the stack.");
                //Console.WriteLine("3 - Print the maximum element in the stack.");
                ////Console.WriteLine("3 - Print the elements in the stack.");

                //Console.Write("Enter Operation Input : ");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');

                switch (Convert.ToInt32(parts[0]))
                {
                    case 1:
                        //Console.WriteLine("Enter stack element");
                        int inp = Convert.ToInt32(parts[1]);
                        Push(inp);
                        break;
                    case 2:
                        Pop();
                        break;
                    //case 3:
                    //    Print();
                    //    break;
                    case 3:
                        PrintMax();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

                queryCount--;
            }

            //Console.ReadLine();
        }
        private static void PrintMax()
        {
            if (top < 0)
            {
                throw new Exception("Stack is empty");
            }

            Console.WriteLine("Max = " + stack[top].CurrMax);
        }
        static void Push(int value)
        {
            int max = int.MinValue;
            if (top < 0)
            {
                max = value;
            }
            else
            {
                if (stack[top].CurrMax > value)
                {
                    max = stack[top].CurrMax;
                }
                else
                {
                    max = value;
                }
            }

            top++;
            stack[top] = new StckNode(value, max);
        }
        static int Pop()
        {
            if (top < 0)
            {
                throw new Exception("Stack is empty");
            }
            int result = stack[top].Data;
            top--;
            return result;
        }
        static bool IsEmpty()
        {
            if (top < 0)
                return true;
            else
                return false;
        }
        static int Top()
        {
            if (top < 0)
            {
                throw new Exception("Stack is empty");
            }

            return stack[top].Data;
        }
        static void Print()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack is empty");
            }
            Console.WriteLine("*******************************");
            int counter = top;
            while (counter >= 0)
            {
                Console.Write(stack[counter].Data + " ");
                counter--;
            }
            Console.WriteLine();
            Console.WriteLine("*******************************");
        }
    }

    class EqualStacksProblem
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
        static int EqualStacks(int[] h1, int[] h2, int[] h3)
        {
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

            int result = EqualStacks(h1, h2, h3);

            Console.WriteLine(result);
            //Console.Flush();
            //Console.Close();
        }

    }
}
