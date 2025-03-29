using System;

namespace _003_TicTacToe
{
    class Program
    {
        private static char[][] matix = new char[3][] {
                                                        new char[] {'1','2','3' },
                                                        new char[] {'4','5','6' },
                                                        new char[] {'7','8','9' }
                                                      };
        private static char player = 'X';

        static void Main(string[] args)
        {
            Draw();
            while (true)
            {
                Input();
                Draw();
                char winner = Win();

                if (winner == 'X')
                {
                    Console.WriteLine(" X won !!");
                    break;
                }
                else if (winner == 'O')
                {
                    Console.WriteLine(" O won !!");
                    break;
                }

                TogglePlayer();
            }

            Console.Read();
        }

        static char Win()
        {
            // check if any of the row is same
            if ((matix[0][0] == matix[0][1]) && (matix[0][1] == matix[0][2]))
                return matix[0][0];
            if ((matix[1][0] == matix[1][1]) && (matix[1][1] == matix[1][2]))
                return matix[1][0];
            if ((matix[2][0] == matix[2][1]) && (matix[2][1] == matix[2][2]))
                return matix[2][0];

            // check if any of the column is same
            if ((matix[0][0] == matix[1][0]) && (matix[1][0] == matix[2][0]))
                return matix[0][0];
            if ((matix[0][1] == matix[1][1]) && (matix[1][1] == matix[2][1]))
                return matix[0][1];
            if ((matix[0][2] == matix[1][2]) && (matix[1][2] == matix[2][2]))
                return matix[0][2];

            // check if any of the Diagonal is same
            if ((matix[0][0] == matix[1][1]) && (matix[1][1] == matix[2][2]))
                return matix[0][0];
            if ((matix[0][2] == matix[1][1]) && (matix[1][1] == matix[2][0]))
                return matix[0][2];

            return '/';
        }
        static void Draw()
        {
            for (int i = 0; i < matix.Length; i++)
            {
                for (int j = 0; j < matix[i].Length; j++)
                {
                    Console.Write(matix[i][j] + " ");
                    //Console.Write("_ ");
                }
                Console.WriteLine();
            }
        }

        static void Input()
        {
            int a;
            Console.WriteLine("Press the number of the field");
            a = Convert.ToInt32(Console.ReadLine());
            matix[(a - 1) / 3][(a - 1) % 3] = player;
        }

        static void TogglePlayer()
        {
            if (player == 'X')
                player = 'O';
            else
                player = 'X';
        }
    }
}
