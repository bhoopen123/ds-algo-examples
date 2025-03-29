using System;
using System.Collections.Generic;
using System.IO;

namespace _010_Stack_TwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@"C:\jsharmbh\Study\Coursera\DS_Examples\010_Stack_TwoStacks\Input\TestCase1.txt", true);

            List<int> results = new List<int>();
            int g = Convert.ToInt32(Console.ReadLine());

            for (int gItr = 0; gItr < g; gItr++)
            {
                string[] nmx = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(nmx[0]);
                int m = Convert.ToInt32(nmx[1]);
                int x = Convert.ToInt32(nmx[2]);
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
                int result = twoStacks(x, a, b);

                results.Add(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
            Console.WriteLine();
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.Read();
        }

        //static int twoStacks(int x, int[] a, int[] b)
        //{
        //    int ai = 0;
        //    int bi = 0;
        //    int count = 0;
        //    int sum = 0;
        //    // move bi to the position where if only take elements from B, last element it can take
        //    while (bi < b.Length && sum + b[bi] <= x)
        //    {
        //        sum += b[bi];
        //        bi++;
        //    }
        //    bi--; // loop exits only when bi reaches end or sum > x; in both case bi should decrease
        //    count = bi + 1;
        //    while (ai < a.Length && bi < b.Length)
        //    {
        //        sum += a[ai];
        //        if (sum > x)
        //        {
        //            while (bi >= 0)
        //            {
        //                sum -= b[bi];
        //                bi--;
        //                if (sum <= x) break;
        //            }
        //            // if even no elements taken from B, but still sum greater than x, then a[ai] should not be chosen
        //            // and loop terminates
        //            if (sum > x && bi < 0)
        //            {
        //                ai--;
        //                break;
        //            }
        //        }
        //        count = Math.Max(ai + bi + 2, count);
        //        ai++;
        //    }

        //    return count;
        //}

        static int twoStacks(int x, int[] a, int[] b)
        {
            int ai = -1;
            int bi = -1;
            int count = 0;
            int sum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (sum + a[i] <= x)
                {
                    sum += a[i];
                    ai++;
                }
                else
                {
                    break;
                }
            }

            sum = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (sum + b[i] <= x)
                {
                    sum += b[i];
                    bi++;
                }
                else
                {
                    break;
                }
            }

            // here Sum is holding the summation of b array
            count = ai > bi ? ai + 1 : bi + 1;
            int j = 0;
            for (j = 0; j <= ai;)
            {
                while (sum + a[j] > x && bi > -1)
                {
                    sum -= b[bi];
                    bi--;
                }

                while (j <= ai && sum + a[j] <= x )
                {
                    sum += a[j];
                    j++;
                }

                if (j + bi + 1 > count)
                    count = j + bi + 1;
                //if (j >= ai)
                //    break;
            }

            return count;
        }

        //static int twoStacks(int x, int[] a, int[] b)
        //{
        //    List<int> aMax = new List<int>();
        //    List<int> bMax = new List<int>();
        //    int maxCount = 0;
        //    int sum = 0;
        //    foreach (var aItem in a)
        //    {
        //        sum += aItem;

        //        if (sum <= x)
        //            aMax.Add(aItem);
        //        else
        //            break;
        //    }
        //    sum = 0;
        //    foreach (var bItem in b)
        //    {
        //        sum += bItem;

        //        if (sum <= x)
        //            bMax.Add(bItem);
        //        else
        //            break;
        //    }

        //    if (maxCount < aMax.Count)
        //        maxCount = aMax.Count;
        //    if (maxCount < bMax.Count)
        //        maxCount = bMax.Count;

        //    int aCounter = 1;
        //    int bCounter = bMax.Count;
        //    int tempCount = 0;
        //    sum = 0;
        //    while (aCounter <= aMax.Count)
        //    {
        //        for (int i = 0; i < aCounter; i++)
        //        {
        //            sum += aMax[i];
        //            if (sum <= x)
        //            {
        //                tempCount++;
        //            }
        //        }

        //        for (int j = 0; j < bCounter; j++)
        //        {
        //            sum += bMax[j];
        //            if (sum <= x)
        //            {
        //                tempCount++;
        //            }
        //            else
        //            {
        //                bCounter = j;
        //                break;
        //            }
        //        }

        //        if (tempCount > maxCount)
        //            maxCount = tempCount;

        //        aCounter++;
        //        tempCount = 0;
        //        sum = 0;
        //    }

        //    return maxCount;
        //}

        //static int twoStacks(int x, int[] a, int[] b)
        //{
        //    int indexA = 0;
        //    int indexB = 0;

        //    int score = 0;
        //    int tempScore = 0;

        //    while (score < x)
        //    {
        //        tempScore = score;

        //        if (indexA > (a.Length - 1) && indexB > (b.Length - 1)) // edge case
        //            break;

        //        if (indexA < a.Length && indexB < b.Length && a[indexA] < b[indexB])
        //        {
        //            score += a[indexA];
        //            indexA++;
        //        }
        //        else if (indexA < a.Length && indexB < b.Length && a[indexA] >= b[indexB])
        //        {
        //            score += b[indexB];
        //            indexB++;
        //        }
        //        else if (indexA < a.Length && indexB > (b.Length - 1))
        //        {
        //            score += a[indexA];
        //            indexA++;
        //        }
        //        else if (indexB < b.Length && indexA > (a.Length - 1))
        //        {
        //            score += b[indexB];
        //            indexB++;
        //        }
        //    }

        //    return tempScore;
        //}
    }
}
