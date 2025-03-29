using System;

namespace _002_CircularQueueUsingArray
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

                try
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine(" Enter value : ");
                            int value = int.Parse(Console.ReadLine());
                            queue.Enqueue(value);
                            break;
                        case 2:
                            int data = queue.Dequeue();
                            Console.WriteLine("Dequeue" + data);
                            break;
                        case 3:
                            int front = queue.Front();
                            Console.WriteLine("Front" + front);
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
            int result = 0;
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            else if (front == rear)
            {
                result = arr[front];
                front = -1;
                rear = -1;
            }
            else
            {
                result = arr[front];
                front = (front + 1) % arr.Length;
            }

            return result;
        }
        public override void Enqueue(int data)
        {

            if (IsEmpty())
            {
                front = (front + 1) % arr.Length;
            }
            else if (IsFull())
            {
                throw new Exception("Queue is full");
            }

            rear = (rear + 1) % arr.Length;
            arr[rear] = data;
        }
        public override int Front()
        {
            if (!IsEmpty())
                return arr[front];
            else
            {
                throw new Exception("Queue is empty");
            }
        }
        public override bool IsEmpty()
        {
            bool result = false;
            //if front = -1 and rear = -1 // this means queue is empty
            if (front == -1 && rear == -1)
                result = true;
            // Next index of rear is front // this means that queue is empty
            //else if ((rear + 1) % arr.Length == front)
            //    result = true;

            // previous index of front is rear // this means that queue is empty
            //else if ((front + arr.Length - 1) % arr.Length > rear)
            //    result = true;

            return result;
        }

        public bool IsFull()
        {
            bool result = false;
            // Next index of rear is front then queue is full
            if ((rear + 1) % arr.Length == front)
                result = true;

            return result;
        }
        public override void Print()
        {
            if (!IsEmpty())
            {
                int i = front;

                while (i != rear)
                {
                    Console.Write(arr[i] + " -> ");
                    i = (i + 1) % arr.Length;
                };

                Console.Write(arr[rear] + " -! ");

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Queue is empty!!!");
            }
        }
    }
}
