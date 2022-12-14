namespace Tic_tac_toe.Models.Players.Models
{
    using System;
    using Contracts;

    public class ComputerPlayer : Player,IComputerPlayer
    {
        private const string DefaultComputerUserName = "Computer";

        private readonly Random _random;
        private int _nextRow;
        private int _nextCol;
        public ComputerPlayer(string symbol) : base(DefaultComputerUserName, symbol)
        {
            _random = new Random();
            _nextRow = 0;
            _nextCol = 0;
        }

        public void MakeTurnAutomatically(string[,] field)
        {
            if (CheckMatrixWhetherIsFilled(field))
            {
                _nextRow = _random.Next(0, field.GetLength(0));
                _nextCol = _random.Next(0, field.GetLength(1));
                bool isEmptyCell = field[_nextRow, _nextCol] == " ";
                if (isEmptyCell)
                {
                    field[_nextRow, _nextCol] = Symbol;
                }
                else
                {
                    while (true)
                    {
                        _nextRow = _random.Next(0, field.GetLength(0));
                        _nextCol = _random.Next(0, field.GetLength(1));
                        isEmptyCell = field[_nextRow, _nextCol] == " ";
                        if (isEmptyCell)
                        {
                            field[_nextRow, _nextCol] = Symbol;
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Draw");
                Console.ForegroundColor = ConsoleColor.White;
            }
           
        }

        private bool CheckMatrixWhetherIsFilled(string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row,col]==" ")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
