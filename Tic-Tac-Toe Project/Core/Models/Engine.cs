using System.Threading;

namespace Tic_tac_toe.Core.Models
{
    using System;
    using Tic_tac_toe.Models.Fields.Contracts;
    using Contracts;
    using Tic_tac_toe.Models.Players.Contracts;

    public class Engine : IEngine
    {
        private readonly IPlayer _playerOne;

        private IPlayer _playerTwo;

        private readonly IField _field;

        private readonly IController _controller;
        public Engine(IField field, IController controller, IPlayer playerOne, IPlayer playerTwo)
        {
            _controller = controller;
            _field = field;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }
        public void Run()
        {
            bool isPlayerOneTurn = true;
            while (true)
            {
                _controller.Play(isPlayerOneTurn);
                _field.Drawer.Draw(_field.Matrix);
                if (_field.Validator.Validate(_field.Matrix))
                {
                    Console.WriteLine("Final field state:");
                    _field.Drawer.Draw(_field.Matrix);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Round over!");
                    string winner = isPlayerOneTurn ? _playerOne.UserName : _playerTwo.UserName;
                    Console.WriteLine($"The winner for this round is: {winner}");

                    IncreasePoints(isPlayerOneTurn);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Do you want to play more?");
                    string answer = Console.ReadLine();
                    if (answer == "Yes")
                    {
                        isPlayerOneTurn = RestartFieldAndTurns(isPlayerOneTurn);
                        _controller.Play(isPlayerOneTurn);
                    }
                    else
                    {
                        _controller.Exit();
                    }

                }
                if (IsDraw(_field.Matrix))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Draw");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //  Thread.Sleep(776);
                // Console.Clear();
                isPlayerOneTurn = !isPlayerOneTurn;
            }
        }

        private bool RestartFieldAndTurns(bool isPlayerOneTurn)
        {
            _field.GenerateField();
            return true;
        }


        private bool IsDraw(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != " ")
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
