namespace Tic_tac_toe.Models.Players.Models
{
    using System;
    using Contracts;
    using Utilities;
    public class Player : IPlayer
    {
        private string _userName;

        private int _points;

        private string _symbol;

        public Player(string userName, string symbol)
        {
            UserName = userName;
            Points = 0;
            Symbol = symbol;
        }
        public string UserName
        {
            get => _userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                _userName = value;
            }
        }

        public int Points
        {
            get => _points;
            private set => _points = value;
        }

        public string Symbol
        {
            get => _symbol;
            private set
            {
                if (value != "X" && value != "O")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSymbol);
                }
                _symbol = value;
            }
        }
        public void Win()
        {
            Points++;
        }

    }
}
