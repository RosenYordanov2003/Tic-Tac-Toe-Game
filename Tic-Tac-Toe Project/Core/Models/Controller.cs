namespace Tic_tac_toe.Core.Models
{
    using System;
    using System.Threading;
    using Contracts;
    using Tic_tac_toe.Models.Fields.Contracts;
    using Tic_tac_toe.Models.Players.Contracts;
    using Tic_tac_toe.Models.Players.Models;
    using Tic_tac_toe.Models.Drawers.Contracts;
    using Tic_tac_toe.Models.Validators.Contracts;
    using Tic_tac_toe.Models.Boards.Contracts;
    using Utilities;
    public class Controller : IController
    {
        private readonly IPlayer _playerOne;

        private IPlayer _playerTwo;

        private readonly IField<string[,]> _field;


        private readonly IValidator<string[,]> _validator;

        private readonly IBoard<IPlayer> _scoreBoard;

        private const int SuccessfulExitCode = 0;
        public Controller(IPlayer playerOne, IPlayer playerTwo, IField<string[,]> field, IValidator<string[,]> validator, IBoard<IPlayer> scoreBoard)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _field = field;
            _validator = validator;
            _scoreBoard = scoreBoard;
        }

        public void PlayRound(IDrawer<string[,]> drawer)
        {
            _field.GenerateField();
            bool isPlayerOneTurn = true;
            while (true)
            {
                _scoreBoard.GenerateField();
                drawer.DrawAt(_scoreBoard.Matrix,35,0);
                Console.SetCursorPosition(0, 0);
                string playerNameOnTurn = isPlayerOneTurn ? _playerOne.UserName : _playerTwo.UserName;
                Console.WriteLine($"{playerNameOnTurn} is on turn!");
                drawer.Draw(_field.Matrix);

                if (isPlayerOneTurn)
                {
                    Console.WriteLine("Enter row between (1-3):");
                    int row = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter col between (1-3):");
                    int col = int.Parse(Console.ReadLine());

                    _playerOne.PlayerMakeTurn(row - 1, col - 1, _field.Matrix);
                }
                else
                {
                    if (_playerTwo.GetType().Name != nameof(ComputerPlayer))
                    {
                        Console.WriteLine("Enter row between (1-3):");
                        int row = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter col between (1-3):");
                        int col = int.Parse(Console.ReadLine());

                        _playerTwo.PlayerMakeTurn(row - 1, col - 1, _field.Matrix);
                    }
                    else
                    {
                        ComputerPlayer computerPlayer = _playerTwo as ComputerPlayer;
                        Thread.Sleep(150 * 5);
                        computerPlayer.MakeTurnAutomatically(_field.Matrix);
                    }
                }
                if (_validator.Validate(_field.Matrix))
                {
                    PrintWinnerResult(isPlayerOneTurn,drawer);
                    IncreasePoints(isPlayerOneTurn);
                    break;
                }
                if (CheckForDrawResult(_field.Matrix))
                {
                    PrintDrawResult();
                    break;
                }

                Thread.Sleep(100 * 5);
                isPlayerOneTurn = !isPlayerOneTurn;
                Console.Clear();
            }
        }

        public void Exit()
        {
            Environment.Exit(SuccessfulExitCode);
        }

        public string PlayerInfo(string playerName)
        {
            if (_playerOne.UserName == playerName)
            {
                return _playerOne.ToString();
            }
            if (_playerTwo.UserName == playerName)
            {
                return _playerTwo.ToString();
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.NoExistingPlayer, playerName));
        }


        private void PrintWinnerResult(bool isPlayerOneTurn, IDrawer<string[,]> drawer)
        {
            Console.Clear();
            Console.WriteLine("Final field state:\n");
            drawer.Draw(_field.Matrix);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Thread.Sleep(500 * 2);
            Console.WriteLine();
            Console.WriteLine("ROUND OVER!");
            string winner = isPlayerOneTurn ? _playerOne.UserName : _playerTwo.UserName;
            Thread.Sleep(1000*2);
            Console.WriteLine($"The winner for this round is: {winner}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintDrawResult()
        {
            if (CheckForDrawResult(_field.Matrix))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Draw");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        private bool CheckForDrawResult(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == " ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void IncreasePoints(bool isPlayerOneTurn)
        {
            if (isPlayerOneTurn)
            {
                _playerOne.Win();
            }
            else
            {
                _playerTwo.Win();
            }
        }
    }
}
