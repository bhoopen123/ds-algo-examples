using System;
using System.Collections.Generic;
using System.Text;

namespace _011_BitManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "1010110111001101101000";
            string B = "1000011011000000111100110";

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            keyValuePairs.Add(1, 1);
            keyValuePairs.Add(2, 1);
            keyValuePairs.Add(3, 1);
            keyValuePairs.Add(4, 1);

            foreach (var key in keyValuePairs.Keys)
            {
                // need to check, why this code doesn't work
                int frequency = keyValuePairs[2];
                //keyValuePairs[2] = frequency++;

                // and why this code works
                keyValuePairs[2] = frequency+1;

            }


            addBinary(A, B);

            //string johnson = "johnson";

            //Console.WriteLine("johnson".ToUpper().Contains("JOHNSON"));


            //int n = 4;

            //Console.WriteLine($" value of (1 << n) is : {1 << n}");

            //Console.ReadLine();
        }


        public static string addBinary(string A, string B)
        {

            int length = 0;

            // declare an array
            if (A.Length > B.Length)
            {
                length = A.Length + 1;
            }
            else
            {
                length = B.Length + 1;
            }

            byte[] ans = new byte[length];
            byte[] arrA = new byte[length];
            byte[] arrB = new byte[length];

            int index = arrA.Length - 1;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                arrA[index] = byte.Parse(A[i].ToString());
                index--;
            }

            index = arrB.Length - 1;
            for (int i = B.Length - 1; i >= 0; i--)
            {
                arrB[index] = byte.Parse(B[i].ToString());
                index--;
            }

            Console.WriteLine("Arr A");
            Print(arrA);
            Console.WriteLine();
            Console.WriteLine("Arr B");
            Print(arrB);
            Console.WriteLine();

            int carry = 0;

            // perform 
            for (int i = ans.Length - 1; i >= 0; i--)
            {
                int sum = carry + arrA[i] + arrB[i];
                ans[i] = Convert.ToByte(sum % 2);
                carry = sum / 2;
            }

            //
            StringBuilder sb = new StringBuilder();

            if (ans[0] == 1)
            {
                sb.Append(ans[0]);
            }

            for (int i = 1; i < ans.Length; i++)
            {
                sb.Append(ans[i]);
            }

            return sb.ToString();
        }

        static void Print(byte[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
        }
    }
}
