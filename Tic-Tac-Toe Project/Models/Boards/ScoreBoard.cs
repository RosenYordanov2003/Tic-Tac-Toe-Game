using Tic_tac_toe.Models.Fields.Contracts;

namespace Tic_tac_toe.Models.Boards
{
    using System;
    using Utilities;
    using Contracts;
    using Tic_tac_toe.Models.Players.Contracts;

    public class ScoreBoard : IBoard<IPlayer>

    {
        private IPlayer _playerOne;

        private IPlayer _playerTwo;

        public ScoreBoard(IPlayer playerOne, IPlayer playerTwo)
        {
            Matrix = new string[3, 1];
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public IPlayer PlayerOne
        {
            get => _playerOne;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(PlayerOne), ExceptionMessages.InvalidPlayerForTheBoard);
                }

                _playerOne = value;
            }
        }

        public IPlayer PlayerTwo
        {
            get => _playerTwo;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(PlayerTwo), ExceptionMessages.InvalidPlayerForTheBoard);
                }

                _playerTwo = value;
            }
        }


        public string[,] Matrix { get; private set; }


        public void GenerateField()
        {
            Matrix[0, 0] = " Scoreboard";
            Matrix[1, 0] = $"|Player one: {PlayerOne.UserName} : {PlayerOne.Points} wins";
            Matrix[2, 0] = $"|Player two: {PlayerTwo.UserName} : {PlayerTwo.Points} wins";
        }
    }
}
