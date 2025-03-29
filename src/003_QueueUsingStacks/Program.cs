using System;
using System.Collections.Generic;

namespace _003_QueueUsingStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            int queryCount = int.Parse(Console.ReadLine());
            QueueUsingStacksManager manager = new QueueUsingStacksManager();

            while (queryCount > 0)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');

                switch (int.Parse(parts[0]))
                {
                    case 1:
                        // Enqueue operation
                        manager.Enqueue(int.Parse(parts[1]));
                        break;
                    case 2:
                        // Dequeue operation
                        manager.Dequeue();
                        break;
                    case 3:
                        // print operation
                        manager.Print();
                        break;

                    default:
                        break;
                }

                queryCount--;
            }
        }
    }

    class QueueUsingStacksManager
    {
        Stack<int> rearStack = null;
        Stack<int> frontStack = null;

        public QueueUsingStacksManager()
        {
            rearStack = new Stack<int>();
            frontStack = new Stack<int>();
        }

        public void Enqueue(int number)
        {
            // Always insert it to Rear stack
            rearStack.Push(number);
        }

        public int Dequeue()
        {
            if (frontStack.Count == 0)
            {
                PutDataIntoFrontStack();
            }

            if (frontStack.Count > 0)
            {
                return frontStack.Pop();
            }

            return 0;
        }

        private void PutDataIntoFrontStack()
        {
            while (rearStack.Count > 0)
            {
                frontStack.Push(rearStack.Pop());
            }
        }

        public void Print()
        {
            if (frontStack.Count == 0)
            {
                PutDataIntoFrontStack();
            }

            if (frontStack.Count > 0)
            {
                Console.WriteLine(frontStack.Peek());
            }
        }
    }
}
