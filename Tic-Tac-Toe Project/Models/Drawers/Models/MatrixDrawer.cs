namespace Tic_tac_toe.Models.Drawers.Models
{
    using System;
    using Contracts;
    public class MatrixDrawer : IDrawer<string[,]>
    {
        private ConsoleColor _color;

        public MatrixDrawer(ConsoleColor color)
        {
            _color = color;
        }
        public void Draw(string[,]field)
        {
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
        public void DrawAt(string[,]field, int leftX, int topY)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.SetCursorPosition(leftX, topY + row);
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
