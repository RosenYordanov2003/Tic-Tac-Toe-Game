using Tic_tac_toe.Models.Boards;
using Tic_tac_toe.Models.Boards.Contracts;

namespace Tic_tac_toe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Contracts;
    using Tic_tac_toe.Core.Models;
    using Tic_tac_toe.Models.Drawers.Models;
    using Tic_tac_toe.Models.Fields.Models;
    using Tic_tac_toe.Models.Players.Models;
    using Tic_tac_toe.Models.Validators.Models;
    using Models.Drawers.Contracts;
    using Models.Validators.Contracts;
    using Models.Fields.Contracts;
    using Utilities;
    using Models.Players.Contracts;
    using Factories;
    public class Program
    {
        private static Dictionary<string, int> symbols = new()
        {
            { "X", 0 },
            { "O", 0 },
        };
        static void Main(string[] args)
        {

            Console.WriteLine("Enter player one name: ");
            string playerOneUserName = Console.ReadLine();
            Console.WriteLine("Player one choose your sign. The possible ones are X and O");
            string playerOneSign = Console.ReadLine();
            IPlayer playerOne = new Player(playerOneUserName, playerOneSign);
            symbols[playerOneSign]++;

            Console.WriteLine("Are you going to play with your friend ?");

            string answer = Console.ReadLine();

            IPlayer playerTwo = CreatePlayerTwo(answer);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game starting!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter color for the field:");
            string colorType = Console.ReadLine();
            Console.Clear();

            IFactory<ConsoleColor> factory = new ColorFactory();
            IField field = new Field();
            IDrawer matrixDrawer = new MatrixDrawer(factory.GenerateType(colorType));
            IValidator validator = new Tic_Tac_Toe_ResultValidator();
            IBoard<IPlayer> scoreBoard = new ScoreBoard(playerOne, playerTwo);
            IEngine engine = new Engine(new Controller(playerOne, playerTwo, field, matrixDrawer, validator, scoreBoard));
            engine.Run();
        }


        private static IPlayer CreatePlayerTwo(string answer)
        {
            IPlayer player;
            if (answer == "Yes")
            {
                Console.WriteLine("Enter player two name:");
                string playerTwoUserName = Console.ReadLine();
                Console.WriteLine("Player two enter your sign:");
                string sign = Console.ReadLine();
                if (symbols.ContainsKey(sign))
                {
                    if (symbols[sign] != 0)
                    {
                        throw new InvalidOperationException(string.Format(ExceptionMessages.SignIsNtAvailable, sign));
                    }
                    player = new Player(playerTwoUserName, sign);
                    symbols[sign]++;
                }
                else
                {
                    //Exception sould be thrown from the property validation.;
                    player = new Player(playerTwoUserName, sign);
                }
            }
            else
            {
                KeyValuePair<string, int> kvp = symbols.FirstOrDefault(k => k.Value == 0);
                string sing = kvp.Key;
                player = new ComputerPlayer(sing);
            }
            return player;
        }
    }
}
