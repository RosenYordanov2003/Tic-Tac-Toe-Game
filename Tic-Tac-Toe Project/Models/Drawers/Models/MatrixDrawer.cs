
using System;
using Tic_tac_toe.Models.Drawers.Contracts;

namespace Tic_tac_toe.Models.Drawers.Models
{
    public class MatrixDrawer : IDraw
    {
        public void Draw(object obj)
        {
            char[,] matrix = (char[,])obj;
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
            }
        }
    }
}
