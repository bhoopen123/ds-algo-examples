using System;

namespace DS_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Initialyze UnionFind Class");

            //UnionFind uf = new UnionFind(10);
            //QuickUnionUF uf = new QuickUnionUF(10);
            //WeightedQuickUnion uf = new WeightedQuickUnion(10);
            PathCompressionWQU uf = new PathCompressionWQU(10);

            Console.WriteLine("\t\t"); uf.Print(); Console.WriteLine();

            uf.Union(4, 3);
            Console.Write("After Union(4,3) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(3, 8);
            Console.Write("After Union(3,8) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(6, 5);
            Console.Write("After Union(6,5) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(9, 4);
            Console.Write("After Union(9,4) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(2, 1);
            Console.Write("After Union(2,1) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(5, 0);
            Console.Write("After Union(5,0) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(7, 2);
            Console.Write("After Union(7,2) \t");
            uf.Print(); Console.WriteLine();
            //uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(6, 1);
            Console.Write("After Union(6,1) \t");
            uf.Print(); Console.WriteLine();
            uf.PrintConnectedComponents();
            Console.WriteLine();


            uf.Union(7, 3);
            Console.Write("After Union(7,3) \t");
            uf.Print(); Console.WriteLine();
            uf.PrintConnectedComponents();
            Console.WriteLine();


            Console.ReadLine();
        }
    }

    class UnionFind
    {
        protected int[] arr = null;
        protected int[] conComp = null;

        public UnionFind(int maxCount)
        {
            arr = new int[maxCount];
            conComp = new int[maxCount];

            // fill up
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
                conComp[i] = i;
            }
        }

        public virtual void Union(int num1, int num2)
        {
            int num1Index = arr[num1];
            int num2Index = arr[num2];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num1Index)
                    arr[i] = num2Index;

            }
        }

        public virtual bool IsConnected(int num1, int num2)
        {
            return (arr[num1] == arr[num2]);
        }

        public void Print()
        {
            System.Console.Write("[");

            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write(arr[i]);

                if (i < arr.Length - 1)
                {
                    System.Console.Write(",");
                }
            }

            System.Console.Write("]");
        }

        public void Print(int[] array)
        {
            System.Console.Write("[");

            for (int i = 0; i < array.Length; i++)
            {
                System.Console.Write(array[i]);

                if (i < array.Length - 1)
                {
                    System.Console.Write(",");
                }
            }

            System.Console.Write("]");
        }

        // print connected components
        public void PrintConnectedComponents()
        {
            bool[] visitList = new bool[arr.Length];
            int[] connComp = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (!visitList[i])
                {
                    connComp[i] = VisitRoot(i, connComp, visitList);
                }
                else
                {
                    connComp[i] = arr[i];
                }
            }

            Console.WriteLine("Connected Comp List");
            Print(connComp);
        }

        private int VisitRoot(int i, int[] connComp, bool[] visitList)
        {
            while (arr[i] != i)
            {
                visitList[i] = true;
                i = arr[i];
                connComp[i] = VisitRoot(i, conComp, visitList);
            }

            return i;
        }
    }


    class QuickUnionUF : UnionFind
    {
        //int[] arr = null;
        public QuickUnionUF(int count) : base(count)
        {
            //arr = new int[count];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = i;
            //}
        }

        protected virtual int root(int number)
        {
            while (arr[number] != number)
            {
                number = arr[number];
            }

            return arr[number];
        }

        public override void Union(int num1, int num2)
        {
            arr[root(num1)] = root(num2);
        }

        public override bool IsConnected(int num1, int num2)
        {
            return (root(num1) == root(num2));
        }
    }

    class WeightedQuickUnion : QuickUnionUF
    {
        private int[] sizeArr = null;
        public WeightedQuickUnion(int count) : base(count)
        {
            sizeArr = new int[count];

            for (int i = 0; i < sizeArr.Length; i++)
            {
                sizeArr[i] = 1;
            }
        }

        public override void Union(int num1, int num2)
        {
            //base.Union(num1, num2);
            int rootNum1 = root(num1);
            int rootNum2 = root(num2);

            if (rootNum1 == rootNum2) // this means that the given ids are already in connected component
                return;
            if (sizeArr[rootNum1] < sizeArr[rootNum2])
            {
                arr[rootNum1] = rootNum2;
                sizeArr[rootNum2] += sizeArr[rootNum1];
            }
            else
            {
                arr[rootNum2] = rootNum1;
                sizeArr[rootNum1] += sizeArr[rootNum2];
            }
        }
    }

    class PathCompressionWQU : WeightedQuickUnion
    {
        public PathCompressionWQU(int count) : base(count)
        {
        }

        protected override int root(int number)
        {
            while (arr[number] != number)
            {
                arr[number] = arr[arr[number]];
                number = arr[number];
            }

            return arr[number];
        }
    }
}
