using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _002_2DArray
{
    class _002Program
    {
        // Complete the diagonalDifference function below.
        static int diagonalDifference(int[][] arr)
        {
            int matrixSize = arr.GetLength(0);
            int diagonalDifference = 0;
            int diagonalOne = 0;
            int diagonalTwo = 0;

            int j = matrixSize - 1;
            for (int i = 0; i < matrixSize; i++)
            {
                diagonalOne += arr[i][i];
                diagonalTwo += arr[i][j];

                j--;
            }

            diagonalDifference = diagonalOne - diagonalTwo;

            if (diagonalDifference < 0)
            { diagonalDifference = diagonalDifference * (-1); }

            return diagonalDifference;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = diagonalDifference(arr);
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
    class _003PlusMinus
    {
        // Complete the plusMinus function below.
        static void plusMinus(int[] arr)
        {
            int positiveNumberCount = 0;
            int negativeNumberCount = 0;
            int zeroNumberCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    negativeNumberCount++;
                }
                else if (arr[i] > 0)
                {
                    positiveNumberCount++;
                }
                else
                {
                    zeroNumberCount++;
                }
            }

            Console.WriteLine((float)positiveNumberCount / (float)arr.Length);
            Console.WriteLine((float)negativeNumberCount / (float)arr.Length);
            Console.WriteLine((float)zeroNumberCount / (float)arr.Length);
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            plusMinus(arr);
        }
    }
    class _004MiniMaxSum
    {
        //Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers. 
        //Then print the respective minimum and maximum values as a single line of two space-separated long integers.
        //For example, arr=[1,3,5,7,9]. Our minimum sum is 1+3+5+7=16 and our maximum sum is 3+5+7+9=24. 
        //We would print 16 24

        // Complete the miniMaxSum function below
        static void miniMaxSum(int[] arr)
        {
            Int32 max = arr[0];
            Int32 min = arr[0];

            UInt64 total = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                total += (UInt64)arr[i];
                if (max < arr[i])
                {
                    max = arr[i];
                }
                else if (min > arr[i])
                {
                    min = arr[i];
                }
            }

            // (total - max) will give minSum
            // (total - min) will give maxSum
            Console.Write((total - (UInt64)max) + " " + (total - (UInt64)min));

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            miniMaxSum(arr);
        }
    }
    class _005BirthdayCakeCandles
    {
        //For example, if your niece is turning 4 years old, and the cake will have candles of height 4 ,4 ,1 ,3. 
        //she will be able to blow out 2 candles successfully, since the tallest candles are of height 4 and there are 2 such candles.
        //Complete the birthdayCakeCandles function below.
        static int birthdayCakeCandles(int[] ar)
        {
            int max = ar[0];
            int maxCount = 1;

            for (int i = 1; i < ar.Length; i++)
            {
                if (max == ar[i])
                {
                    maxCount++;
                }
                else if (max < ar[i])
                {
                    max = ar[i];
                    maxCount = 1;
                }
            }

            return maxCount;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arCount = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = birthdayCakeCandles(ar);

            Console.WriteLine(result);
            Console.Read();
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _006TimeConversion
    {

        /*
         * Complete the timeConversion function below.
         */

        //Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.
        //Note: Midnight is 12:00:00AM on a 12-hour clock, and 00:00:00 on a 24-hour clock.
        //Noon is 12:00:00PM on a 12-hour clock, and 12:00:00 on a 24-hour clock.
        static string timeConversion(string s)
        {
            string convertedTime = string.Empty;

            // hh:mm:ss<AM/PM>
            string[] splittedTime = s.Split(':');
            string[] convertedSplittedTime = new string[3];

            Byte hh = Convert.ToByte(splittedTime[0]); // hh

            if (splittedTime[2].Trim().ToUpper().EndsWith("PM") && ((int)hh < 12))
            {
                hh = (Byte)((int)hh + 12);
                convertedSplittedTime[0] = hh.ToString();
            }
            else if (splittedTime[2].Trim().ToUpper().EndsWith("AM") && ((int)hh == 12))
            {
                hh = (Byte)(0);
                convertedSplittedTime[0] = "00";
            }
            else
            {
                convertedSplittedTime[0] = splittedTime[0];
            }

            convertedSplittedTime[1] = splittedTime[1];
            convertedSplittedTime[2] = splittedTime[2].Substring(0, 2);

            convertedTime = string.Format("{0}:{1}:{2}", convertedSplittedTime[0], convertedSplittedTime[1], convertedSplittedTime[2]);

            return convertedTime;
        }

        static void Main(string[] args)
        {
            //TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();
            string result = timeConversion(s);
            Console.WriteLine(result);

            //tw.Flush();
            //tw.Close();
        }
    }
    class _007SockMerchant
    {
        //John works at a clothing store.He has a large pile of socks that he must pair by color for sale. 
        //Given an array of integers representing the color of each sock, determine how many pairs of socks with matching colors there are.
        //For example, there are n=7 socks with colors ar=[1,2,1,2,1,3,2]. There is one pair of color 1 and one of color 2. 
        //There are three odd socks left, one of each color. The number of pairs is 2.

        //Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar)
        {
            int pairCount = 0;
            Dictionary<int, int> socksColorAndCount = new Dictionary<int, int>();

            for (int i = 0; i < ar.Length; i++)
            {
                if (socksColorAndCount.Keys.Contains(ar[i]))
                {
                    socksColorAndCount[ar[i]] += 1;
                }
                else
                {
                    socksColorAndCount.Add(ar[i], 1);
                }
            }

            //lets do one iteration for finding pair
            foreach (var value in socksColorAndCount.Values)
            {
                pairCount += (value / 2);
            }

            return pairCount;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = sockMerchant(n, ar);

            Console.WriteLine(result);
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _008CountingValleys
    {
        // Complete the countingValleys function below.
        static int countingValleys(int n, string s)
        {
            int valleyCount = 0;
            bool isInValley = false;
            int currentState = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int currentStep = 0;
                if (s[i].ToString().ToUpper() == "U") { currentStep = 1; }
                else if (s[i].ToString().ToUpper() == "D") { currentStep = -1; }

                //
                currentState += currentStep;

                if (!isInValley && currentState < 0)
                {
                    isInValley = true;
                }

                if (isInValley && currentState == 0)
                {
                    valleyCount++; isInValley = false;
                }
            }

            return valleyCount;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            int result = countingValleys(n, s);
            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _009GetMoneySpent
    {
        //Monica wants to buy a keyboard and a USB drive from her favorite electronics store.
        //The store has several models of each. Monica wants to spend as much as possible for the 2 items, given her budget.
        //Given the price lists for the store's keyboards and USB drives, and Monica's budget, find and print the amount of money Monica will spend.
        //If she doesn't have enough money to both a keyboard and a USB drive, print -1 instead. She will buy only the two required items.

        //Complete the getMoneySpent function below.
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int maxExpense = -1;
            for (int keyBoardIndex = 0; keyBoardIndex < keyboards.Length; keyBoardIndex++)
            {
                for (int driveIndex = 0; driveIndex < drives.Length; driveIndex++)
                {
                    int expense = drives[driveIndex] + keyboards[keyBoardIndex];
                    if (expense <= b && expense > maxExpense)
                    { maxExpense = expense; }
                }
            }

            return maxExpense;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] bnm = Console.ReadLine().Split(' ');
            int b = Convert.ToInt32(bnm[0]);
            int n = Convert.ToInt32(bnm[1]);
            int m = Convert.ToInt32(bnm[2]);

            int[] keyboards = Array.ConvertAll(Console.ReadLine().Split(' '), keyboardsTemp => Convert.ToInt32(keyboardsTemp));

            int[] drives = Array.ConvertAll(Console.ReadLine().Split(' '), drivesTemp => Convert.ToInt32(drivesTemp));

            //The maximum amount of money she can spend on a keyboard and USB drive, or -1 if she can't purchase both items

            int moneySpent = getMoneySpent(keyboards, drives, b);
            Console.WriteLine(moneySpent);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _010CatAndMouse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">x: an integer, Cat A's position</param>
        /// <param name="y">x: an integer, Cat B's position</param>
        /// <param name="z">z: an integer, Mouse C's position</param>
        /// <returns></returns>
        static string catAndMouse(int x, int y, int z)
        {
            int catAdistance = Math.Abs(x - z);
            int catBdistance = Math.Abs(y - z);

            if (catAdistance > catBdistance)
                return "Cat B";
            else if (catAdistance < catBdistance)
                return "Cat A";
            else
                return "Mouse C";
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] xyz = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(xyz[0]);
                int y = Convert.ToInt32(xyz[1]);
                int z = Convert.ToInt32(xyz[2]);

                string result = catAndMouse(x, y, z);
                Console.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _011FormingMagicSquare_NotWorking
    {
        static Dictionary<int, List<int>> magicSquarePossibilities = new Dictionary<int, List<int>>();
        static List<int> center = new List<int>();
        static List<int> corners = new List<int>();
        static List<int> edges = new List<int>();
        static Dictionary<int, int[]> indexAndRange = new Dictionary<int, int[]>();

        // Complete the formingMagicSquare function below.
        static int formingMagicSquare(int[][] s)
        {
            indexAndRange.Add(0, new int[] { 0, 1, 2 });
            indexAndRange.Add(1, new int[] { 0, 1, 2 });
            indexAndRange.Add(2, new int[] { 0, 1, 2 });
            indexAndRange.Add(3, new int[] { 3, 4, 5 });
            indexAndRange.Add(4, new int[] { 3, 4, 5 });
            indexAndRange.Add(5, new int[] { 3, 4, 5 });
            indexAndRange.Add(6, new int[] { 6, 7, 8 });
            indexAndRange.Add(7, new int[] { 6, 7, 8 });
            indexAndRange.Add(8, new int[] { 6, 7, 8 });

            center.Add(5);
            corners.Add(2);
            corners.Add(4);
            corners.Add(6);
            corners.Add(8);
            edges.Add(1);
            edges.Add(3);
            edges.Add(7);
            edges.Add(9);

            magicSquarePossibilities.Add(0, corners);
            magicSquarePossibilities.Add(1, edges);
            magicSquarePossibilities.Add(2, corners);
            magicSquarePossibilities.Add(3, edges);
            magicSquarePossibilities.Add(4, center);
            magicSquarePossibilities.Add(5, edges);
            magicSquarePossibilities.Add(6, corners);
            magicSquarePossibilities.Add(7, edges);
            magicSquarePossibilities.Add(8, corners);

            Dictionary<int, SquareElement> elementDetail = new Dictionary<int, SquareElement>();

            int index = 0;

            for (int i = 0; i < s.GetLength(0); i++)
            {
                for (int j = 0; j < s[i].GetLength(0); j++)
                {
                    SquareElement element = new SquareElement();
                    element.element = s[i][j];
                    element.isValidForMagicSquare = isValidElement(index, s[i][j]);
                    elementDetail.Add(index, element);

                    index++;
                }
            }
            int cost = 0;

            for (int i = 0; i < elementDetail.Count(); i++)
            {
                if (!elementDetail[i].isValidForMagicSquare)
                {
                    cost += FixMagicSquareRow(indexAndRange[i], elementDetail);
                }
            }


            return cost;
        }

        private static int FixMagicSquareRow(int[] rowIndexes, Dictionary<int, SquareElement> elementDetail)
        {
            int cost = 0;

            foreach (var index in rowIndexes)
            {
                if (!elementDetail[index].isValidForMagicSquare)
                {
                    if (magicSquarePossibilities[index].Count() == 1)
                    {
                        cost += Math.Abs(elementDetail[index].element - magicSquarePossibilities[index][0]);
                        elementDetail[index].element = magicSquarePossibilities[index][0];
                        magicSquarePossibilities[index].Remove(elementDetail[index].element);
                        elementDetail[index].isValidForMagicSquare = true;
                    }
                    else
                    {
                        //throw new Exception("No Logic to handle this case...");
                        int rowTotal = 0;
                        bool closestElementFound = false;
                        int closestElement = 0;

                        // need to place best suitable element 
                        foreach (var possibleElement in magicSquarePossibilities[index])
                        {
                            int rowTotalTemp = 0;
                            int element = 0;
                            //elementDetail[index].element = possibleElement;

                            // need to find the element which is closest to 15 or equals to 15.
                            foreach (var index2 in rowIndexes)
                            {
                                if (index2 == index)
                                {
                                    element = possibleElement;
                                }
                                else
                                {
                                    element = elementDetail[index2].element;
                                }

                                rowTotalTemp += element;
                            }

                            if (rowTotalTemp == 15)
                            {
                                cost += Math.Abs(elementDetail[index].element - possibleElement);
                                magicSquarePossibilities[index].Remove(possibleElement);
                                elementDetail[index].element = possibleElement;
                                elementDetail[index].isValidForMagicSquare = true;
                                closestElementFound = false;
                                break;
                            }
                            else if (rowTotalTemp > rowTotal)
                            {
                                rowTotal = rowTotalTemp;
                                closestElementFound = true;
                                closestElement = possibleElement;
                            }
                        }

                        if (closestElementFound)
                        {
                            cost += Math.Abs(elementDetail[index].element - closestElement);
                            magicSquarePossibilities[index].Remove(closestElement);
                            elementDetail[index].element = closestElement;
                            elementDetail[index].isValidForMagicSquare = true;
                        }
                    }
                }
            }

            return cost;
        }

        private static bool isValidElement(int index, int element)
        {
            bool isValid = false;
            isValid = magicSquarePossibilities[index].Contains(element);

            if (isValid)
            {
                magicSquarePossibilities[index].Remove(element);
            }

            return isValid;
        }

        class SquareElement
        {
            public int element;
            public bool isValidForMagicSquare;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] s = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
            }

            int result = formingMagicSquare(s);
            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _011FormingMagicSquare
    {
        private static int formingMagicSquare(int[][] s)
        {
            #region MultiDimArray Vs ArrayOfArray
            //int[] singleArray = new int[] { 1, 2, 3 };
            //int[][] array2D = new int[3][];
            //array2D[0] = new int[3] { 1, 2, 3 };
            //array2D[1] = new int[3] { 4, 5, 6 };
            //array2D[2] = new int[3] { 7, 8, 9 };

            //int[][] array2D_1 = new int[3][] {  new int[] { 1, 2, 3 },
            //                                    new int[] { 4, 5, 6 },
            //                                    new int[] { 7, 8, 9 }
            //                                 };

            //int[][][] array3D = new int[3][][];
            //array3D[0][0] = new int[3] { 1, 1, 1 };
            //array3D[0][1] = new int[3] { 2, 2, 2 };
            //array3D[0][2] = new int[3] { 3, 3, 3 };
            //array3D[1][0] = new int[3] { 4, 4, 4 };
            //array3D[1][1] = new int[3] { 5, 5, 5 };
            //array3D[1][2] = new int[3] { 6, 6, 6 };
            //array3D[2][0] = new int[3] { 7, 7, 7 };
            //array3D[2][1] = new int[3] { 8, 8, 8 };
            //array3D[2][2] = new int[3] { 9, 9, 9 };

            //int[][][] array3D_1 = new int[3][][] {  new int[][] {   new int[] { 1, 1, 1 },
            //                                                        new int[] { 2, 2, 2 },
            //                                                        new int[] { 3, 3, 3 }
            //                                                    },
            //                                        new int[][] {   new int[] { 4, 4, 4 },
            //                                                        new int[] { 5, 5, 5 },
            //                                                        new int[] { 6, 6, 6 }
            //                                                    },
            //                                        new int[][] {   new int[] { 7, 7, 7 },
            //                                                        new int[] { 8, 8, 8 },
            //                                                        new int[] { 9, 9, 9 }
            //                                                    }
            //                                    };
            #endregion

            //int[,,] possiblePermutationsMultiDimArray = new int[,,] { { { 8, 1, 6}, { 3, 5, 7}, { 4, 9, 2} },
            //                                                          { { 6, 1, 8}, { 7, 5, 3}, { 2, 9, 4} },
            //                                                          { { 4, 9, 2}, { 3, 5, 7}, { 8, 1, 6} },
            //                                                          { { 2, 9, 4}, { 7, 5, 3}, { 6, 1, 8} },
            //                                                          { { 8, 3, 4}, { 1, 5, 9}, { 6, 7, 2} },
            //                                                          { { 4, 3, 8}, { 9, 5, 1}, { 2, 7, 6} },
            //                                                          { { 6, 7, 2}, { 1, 5, 9}, { 8, 3, 4} },
            //                                                          { { 2, 7, 6}, { 9, 5, 1}, { 4, 3, 8} }
            //                                                        };


            int[][][] possiblePermutationsArrayOfArray = new int[8][][] {
                                                                new int[][] {
                                                                                new int[]{ 8, 1, 6},
                                                                                new int[]{ 3, 5, 7},
                                                                                new int[]{ 4, 9, 2}
                                                                            },
                                                                new int[][] {
                                                                                new int[] { 6, 1, 8},
                                                                                new int[]{ 7, 5, 3},
                                                                                new int[]{ 2, 9, 4}
                                                                            },
                                                                new int[][] {
                                                                                new int[]{ 4, 9, 2},
                                                                                new int[]{ 3, 5, 7},
                                                                                new int[]{ 8, 1, 6}
                                                                            },
                                                                new int[][] {
                                                                                new int[]{ 2, 9, 4},
                                                                                new int[]{ 7, 5, 3},
                                                                                new int[]{ 6, 1, 8}
                                                                            },
                                                                new int[][] {
                                                                                new int[]{ 8, 3, 4},
                                                                                new int[]{ 1, 5, 9},
                                                                                new int[]{ 6, 7, 2}
                                                                            },
                                                                new int[][] {
                                                                                new int[]{ 4, 3, 8},
                                                                                new int[]{ 9, 5, 1},
                                                                                new int[]{ 2, 7, 6}
                                                                            },
                                                                new int[][] {
                                                                                new int[]{ 6, 7, 2},
                                                                                new int[]{ 1, 5, 9},
                                                                                new int[]{ 8, 3, 4}
                                                                            },
                                                                new int[][] {
                                                                                new int[]{ 2, 7, 6},
                                                                                new int[]{ 9, 5, 1},
                                                                                new int[]{ 4, 3, 8}
                                                                            }
                                                            };


            int minCost = int.MaxValue;
            for (int permutation = 0; permutation < 8; permutation++)
            {
                int permutationCost = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        //permutationCost += Math.Abs(s[i][j] - possiblePermutationsMultiDimArray[permutation, i, j]);
                        permutationCost += Math.Abs(s[i][j] - possiblePermutationsArrayOfArray[permutation][i][j]);
                    }
                }
                minCost = Math.Min(minCost, permutationCost);
            }

            return minCost;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int[][] s = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
            }

            int result = formingMagicSquare(s);
            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _012PickingNumbers
    {
        /*
        * Complete the 'pickingNumbers' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts INTEGER_ARRAY a as parameter.
        */
        public static int pickingNumbers(List<int> a)
        {
            List<int> mainList = new List<int>();

            for (int i = 0; i < a.Count(); i++)
            {
                List<int> positiveDiffElements = new List<int>();
                List<int> NegativeDiffElements = new List<int>();
                positiveDiffElements.Add(a[i]);
                NegativeDiffElements.Add(a[i]);

                int diff = 0;

                for (int j = 0; j < a.Count(); j++)
                {
                    if (i != j)
                    {
                        diff = a[i] - a[j];
                        if (Math.Abs(diff) <= 1)
                        {
                            if (diff == 0)
                            {
                                positiveDiffElements.Add(a[j]);
                                NegativeDiffElements.Add(a[j]);
                            }
                            else if (diff == 1)
                            {
                                positiveDiffElements.Add(a[j]);
                            }
                            else if (diff == -1)
                            {
                                NegativeDiffElements.Add(a[j]);
                            }
                        }
                    }
                }

                if ((positiveDiffElements.Count() > NegativeDiffElements.Count()) && (positiveDiffElements.Count() > mainList.Count()))
                {
                    mainList = positiveDiffElements;
                }
                else if ((NegativeDiffElements.Count() >= positiveDiffElements.Count()) && (NegativeDiffElements.Count() > mainList.Count()))
                {
                    mainList = NegativeDiffElements;
                }
            }

            return mainList.Count();
        }
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            int result = pickingNumbers(a);
            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _013Staircase
    {
        // Complete the staircase function below.
        static void staircase(int n)
        {
            for (int i = (n - 1); i >= 0; i--)
            {
                int spaceCount = i;
                int stairCount = (n - i);

                while (spaceCount > 0)
                {
                    Console.Write(" ");
                    spaceCount--;
                }

                while (stairCount > 0)
                {
                    Console.Write("#");
                    stairCount--;
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            staircase(n);

            Console.Read();
        }
    }
    class _014RecursiveDigitSum
    {
        // Complete the superDigit function below.
        static int superDigit(string n, int k)
        {
            int index = 1;
            string temp = n;
            while(index < k)
            {
                n = n + temp;
                index++;
            }

            return superDigit(n);
            
        }

        private static int superDigit(string n)
        {
            int sDigit = 0;
            char[] digits = n.ToCharArray();

            foreach (char digit in digits)
            {
                sDigit += Convert.ToInt32(digit.ToString());
            }

            if (sDigit.ToString().Length > 1)
            {
                sDigit = superDigit(sDigit.ToString());
            }

            return Convert.ToInt32(sDigit);
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            string[] nk = Console.ReadLine().Split(' ');
            string n = nk[0];
            int k = Convert.ToInt32(nk[1]);
            int result = superDigit(n, k);

            Console.WriteLine(result);
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    class _014RecursiveDigitSum_2
    {
        // Complete the superDigit function below.
        static int superDigit(string n, int k)
        {
            int returnValue = superDigit(n);

            if (k > 1)
            {
                returnValue = returnValue * k;
                returnValue = superDigit(returnValue.ToString());
            }

            return returnValue;
        }

        private static int superDigit(string n)
        {
            int sDigit = 0;
            char[] digits = n.ToCharArray();

            foreach (char digit in digits)
            {
                sDigit += Convert.ToInt32(digit.ToString());
            }

            if (sDigit.ToString().Length > 1)
            {
                sDigit = superDigit(sDigit.ToString());
            }

            return Convert.ToInt32(sDigit);
        }
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            string[] nk = Console.ReadLine().Split(' ');
            string n = nk[0];
            int k = Convert.ToInt32(nk[1]);
            int result = superDigit(n, k);

            Console.WriteLine(result);
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}