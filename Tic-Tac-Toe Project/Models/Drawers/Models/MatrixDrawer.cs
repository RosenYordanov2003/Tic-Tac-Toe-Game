namespace Tic_tac_toe.Models.Drawers.Models
{
    using System;
    using Contracts;
    public class MatrixDrawer : IDraw
    {
        private ConsoleColor _color;
        public MatrixDrawer(ConsoleColor color)
        {
            _color = color;
        }
        public void Draw(object obj)
        {
            string[,] matrix = (string[,])obj;
            Console.ForegroundColor = _color;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col < matrix.GetLength(1))
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
