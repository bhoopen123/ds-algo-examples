using System;
using System.Linq;
using System.Collections.Generic;


namespace _004_DsArrays
{
    class TwoD_ArrayDS
    {
        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            int maxHourGlassSum = int.MinValue;
            int row = 0, col = 0;

            while (row < arr.Length - 2 && col < arr[0].Length - 2)
            {
                // total of hour square
                int temp = arr[row][col] + arr[row][col + 1] + arr[row][col + 2]
                                + arr[row + 1][col + 1]
                            + arr[row + 2][col] + arr[row + 2][col + 1] + arr[row + 2][col + 2];

                if (temp > maxHourGlassSum)
                    maxHourGlassSum = temp;

                // do increment of i and j
                if (col < arr[0].Length - 3)
                {
                    col++;
                }
                else { col = 0; row++; }

            }

            return maxHourGlassSum;

        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);
            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class SparseArrays
    {
        // Complete the matchingStrings function below.
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            int[] queriesResult = new int[queries.Length];
            //bool[] stringFound = new bool[strings.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                string query = queries[i];

                for (int j = 0; j < strings.Length; j++)
                {
                    if (query == strings[j])
                    {
                        queriesResult[i] += 1;
                    }
                }
            }

            return queriesResult;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int stringsCount = Convert.ToInt32(Console.ReadLine());

            string[] strings = new string[stringsCount];

            for (int i = 0; i < stringsCount; i++)
            {
                string stringsItem = Console.ReadLine();
                strings[i] = stringsItem;
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine());

            string[] queries = new string[queriesCount];

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries[i] = queriesItem;
            }

            int[] res = matchingStrings(strings, queries);

            Console.WriteLine(string.Join("\n", res));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class LeftRotation
    {
        static void Main(string[] args)
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            int[] tempArray = new int[d];

            for (int i = 0; i < d; i++)
            {
                tempArray[i] = a[i];
            }

            // shift rest of the array
            for (int i = 0; i < a.Length - d; i++)
            {
                int temp = a[i + d];
                a[i + d] = a[i];
                a[i] = temp;
            }

            int tempIndex = 0;
            for (int i = a.Length - d; i < a.Length; i++)
            {
                a[i] = tempArray[tempIndex];
                tempIndex++;
            }

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            ////------------------------------------Left rotation
            //int[] rotatedArray = new int[a.Length];
            //for (int i = 0; i < n; i++)
            //{
            //    rotatedArray[(i + (n - d)) % n] = a[i];
            //}

            //Console.WriteLine();

            // need to look into following code
            //        static int[] leftRotation(int[] a, int d) {
            //            for (int i = 0, j = a.length - 1; i < j; i++, j--)
            //                swap(a, i, j);

            //            d %= a.length;

            //            if (d > 0)
            //            {
            //                d = a.length - d;

            //                for (int i = 0, j = d - 1; i < j; i++, j--)
            //                    swap(a, i, j);

            //                for (int i = d, j = a.length - 1; i < j; i++, j--)
            //                    swap(a, i, j);
            //            }

            //            return a;
            //        }

            //private static void swap(int[] arr, int i, int j)
            //    {
            //        int tmp = arr[i];
            //        arr[i] = arr[j];
            //        arr[j] = tmp;
            //    }

            Console.Read();
        }

        private static void swap(int[] a, int i, int rotatedIndex)
        {
            int temp = a[rotatedIndex];
            a[rotatedIndex] = a[i];
            a[i] = temp;
        }
    }
    class DynamicArray
    {
        // Complete the dynamicArray function below.
        static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            List<int> lastAnswers = new List<int>();

            List<int>[] seqList = new List<int>[n];
            int lastAns = 0;

            foreach (List<int> query in queries)
            {

                int seq = 0;

                seq = (query[1] ^ lastAns) % n;
                if (seqList[seq] == null)
                {
                    seqList[seq] = new List<int>();
                }

                if (query[0] == 1)
                {
                    seqList[seq].Add(query[2]);
                }
                else if (query[0] == 2)
                {
                    //Find the value of element  y % size in seq in  (where seq is the size of ) and assign it to lastAnswers.
                    lastAns = seqList[seq][query[2] % seqList[seq].Count];
                    lastAnswers.Add(lastAns);
                }
            }

            return lastAnswers;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nq = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = dynamicArray(n, queries);

            Console.WriteLine(String.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class ArrayManipulation
    {
        // Complete the arrayManipulation function below.
        static long arrayManipulation(int n, int[][] queries)
        {
            long[] arr = new long[n];
            long max = long.MinValue;

            for (int i = 0; i < queries.Length; i++)
            {
                int[] query = queries[i];

                for (int j = (query[0] - 1); j < query[1]; j++)
                {
                    arr[j] += query[2];

                    if (max < arr[j])
                    { max = arr[j]; }
                }
            }

            return max;

        }

        /// <summary>
        /// This is using Difference Array logic
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        static long arrayManipulation1(int n, int[][] queries)
        {
            long[] arr = new long[n];
            long max = long.MinValue;
            long[] diffArr = new long[n + 1];

            for (int i = 0; i < queries.Length; i++)
            {
                int[] query = queries[i];
                int startIndex = query[0] - 1;
                int endIndex = query[1] - 1;

                diffArr[startIndex] += query[2];
                diffArr[endIndex + 1] -= query[2];
            }

            // updating arr
            arr[0] = diffArr[0];
            if (arr[0] > max)
            {
                max = arr[0];
            }
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = diffArr[i] + arr[i - 1];

                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            long result = arrayManipulation1(n, queries);

            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}