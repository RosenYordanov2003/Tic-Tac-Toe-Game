using System;

namespace Tic_tac_toe
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = new string[3,3];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col<2)
                    {
                        Console.Write($"{matrix[row, col]}|");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]}");
                    }
                }

                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
