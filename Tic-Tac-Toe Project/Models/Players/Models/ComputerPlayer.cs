namespace Tic_tac_toe.Models.Players.Models
{
    using System;
    using Contracts;

    public class ComputerPlayer : Player, IComputerPlayer
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

        public void MakeTurn(string[,] field)
        {
            _nextRow = _random.Next(0, field.GetLength(0));
            _nextCol = _random.Next(0, field.GetLength(1));
            bool isEmptyCell = field[_nextRow, _nextRow] == default;
            if (isEmptyCell)
            {
                field[_nextRow, _nextCol] = Symbol;
            }
            else
            {
                while (!isEmptyCell)
                {
                    _nextRow = _random.Next(0, field.GetLength(0));
                    _nextCol = _random.Next(0, field.GetLength(1));
                    isEmptyCell = field[_nextRow, _nextRow] == default;
                    if (isEmptyCell)
                    {
                        field[_nextRow, _nextCol] = Symbol;
                    }
                }
            }
        }
    }
}
