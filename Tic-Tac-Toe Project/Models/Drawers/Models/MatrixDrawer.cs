namespace Tic_tac_toe.Models.Drawers.Models
{
    using System;
    using Contracts;
    public class MatrixDrawer : IDrawer
    {
        private ConsoleColor _color;
        public MatrixDrawer(ConsoleColor color)
        {
            _color = color;
        }
        public void Draw(object obj)
        {
            string[,] field = (string[,])obj;
            Console.ForegroundColor = _color;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (col < field.GetLength(1) - 1)
                    {
                        Console.Write($"{field[row, col]}|");
                    }
                    else
                    {
                        Console.Write($"{field[row, col]}");
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawAt(object obj, int leftX, int topY)
        {
            string[,] field = (string[,])obj;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (col < field.GetLength(1) - 1)
                    {
                        Console.Write($"{field[row, col]}|");
                    }
                    else
                    {
                        Console.SetCursorPosition(leftX, topY + row);
                        Console.Write($"{field[row, col]}");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
