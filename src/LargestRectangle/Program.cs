using System;

namespace LargestRectangle
{
    internal class Program
    {
        private static long largestRectangle(int[] h)
        {
            long maxArea = 0;
            int bi = 0; // Backward length
            int fi = 0; // Forward length

            for (int i = 0; i < h.Length; i++)
            {
                bi = i;
                fi = i;
                while (bi > 0 && h[bi - 1] >= h[i])
                {
                    bi--;
                }
                while (fi < h.Length - 1 && h[fi + 1] >= h[i])
                {
                    fi++;
                }

                long area = h[i] * (bi * (-1) + fi + 1);

                if (area > maxArea)
                    maxArea = area;
            }

            return maxArea;
        }

        private static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());
            int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp));
            long result = largestRectangle(h);

            Console.WriteLine(result);
            Console.Read();
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
