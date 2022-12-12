namespace Tic_tac_toe.Core.Models
{
    using System;
    using Contracts;
    using Tic_tac_toe.Models.Fields.Contracts;
    using Tic_tac_toe.Models.Players.Contracts;
    using Tic_tac_toe.Models.Players.Models;
    public class Controller : IController
    {
        private readonly IPlayer _playerOne;

        private IPlayer _playerTwo;

        private readonly IField _field;

        private const int SuccessfulExitCode = 0;
        public Controller(IPlayer playerOne, IPlayer playerTwo, IField field)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _field = field;
            _field.GenerateField();
        }
        public void Play(bool isPlayerOneTurn)
        {
            if (isPlayerOneTurn)
            {
                Console.WriteLine($"{_playerOne.UserName} is on turn!");
                Console.WriteLine("Enter row between 1-3:");
                int row = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter col between 1-3:");
                int col = int.Parse(Console.ReadLine());
                _playerOne.PlayerMakeTurn(row - 1, col - 1, _field.Matrix);
            }
            else
            {
                Console.WriteLine($"{_playerTwo.UserName} is on turn!");
                if (_playerTwo.GetType().Name != nameof(ComputerPlayer))
                {
                    Console.WriteLine("Enter row between 1-3:");
                    int row = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter col between 1-3:");
                    int col = int.Parse(Console.ReadLine());
                    _playerTwo.PlayerMakeTurn(row - 1, col - 1, _field.Matrix);
                }
                else
                {
                    ComputerPlayer computerPlayer = _playerTwo as ComputerPlayer;
                    computerPlayer.MakeTurnAutomatically(_field.Matrix);
                }
            }
        }

        public void Exit()
        {
            Environment.Exit(SuccessfulExitCode);
        }
    }
}
