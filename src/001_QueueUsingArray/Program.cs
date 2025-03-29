using System;

namespace _001_QueueUsingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue Implementation");
            IntQueue queue = new IntQueue();
            int input = 0;
            do
            {
                Console.WriteLine("1 Enqueue");
                Console.WriteLine("2 Dequeue");
                Console.WriteLine("3 Front");
                Console.WriteLine("4 Print");
                Console.WriteLine("5 Exit");

                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine(" Enter value : ");
                        int value = int.Parse(Console.ReadLine());
                        queue.Enqueue(value);
                        break;
                    case 2:
                        int data = queue.Dequeue();
                        Console.WriteLine(data);
                        break;
                    case 3:
                        int front = queue.Front();
                        Console.WriteLine(front);
                        break;
                    case 4:
                        queue.Print();
                        break;
                    case 5:
                        // Nothing
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }

            } while (input != 5);

            Console.Read();
        }
    }

    public abstract class AbsIntQueue
    {
        public abstract void Enqueue(int data);
        public abstract int Dequeue();
        public abstract bool IsEmpty();
        public abstract int Front();
        public abstract void Print();
    }

    public class IntQueue : AbsIntQueue
    {
        int[] arr = new int[10];
        int front = -1;
        int rear = -1;

        public override int Dequeue()
        {
            if (IsEmpty())
            {
                Console.Write("Queue is empty");
                return -1;
            }
            else if (front < arr.Length)
            {
                int result = arr[front];
                front++;
                return result;
            }
            else
            {
                Console.Write("Queue is exhusted");
                return -1;
            }
        }
        public override void Enqueue(int data)
        {
            if (front == -1)
            {
                front++;
            }
            if (rear < arr.Length - 1)
            {
                rear++;
                arr[rear] = data;
            }
            else
            {
                Console.Write("Queue is exhusted");
            }
        }
        public override int Front()
        {
            if (!IsEmpty())
                return arr[front];
            else
            {
                Console.Write("Queue is empty");
                return -1;
            }
        }
        public override bool IsEmpty()
        {
            bool result = false;
            //if front = -1 and rear = -1 // this means queue is empty
            if (front == -1 && rear == -1)
                result = true;
            // front is greater than rear // this means queue is empty
            else if (front > rear)
                result = true;
            return result;
        }
        public override void Print()
        {
            if (!IsEmpty())
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.Write(arr[i] + " -> ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Queue is empty!!!");
            }
        }
    }
}
