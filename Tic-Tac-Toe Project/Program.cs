namespace Tic_tac_toe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Core.Contracts;
    using Core.Models;
    using Models.Fields.Models;
    using Models.Players.Models;
    using Models.Validators.Models;
    using Models.Validators.Contracts;
    using Models.Fields.Contracts;
    using Utilities;
    using Models.Players.Contracts;
    using Models.Boards;
    using Models.Boards.Contracts;

    public class Program
    {
        private static Dictionary<string, int> symbols = new()
        {
            { "X", 0 },
            { "O", 0 },
        };
        static void Main()
        {
            try
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


                Console.Clear();


                IField<string[,]> field = new Field();
                IValidator<string[,]> validator = new Tic_Tac_Toe_ResultValidator();
                IBoard<IPlayer> scoreBoard = new ScoreBoard(playerOne, playerTwo);
                IEngine engine = new Engine(new Controller(playerOne, playerTwo, field, validator, scoreBoard));
                engine.Run();
            }
            catch (ArgumentNullException exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exception.Message);
                Threading();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Main();
            }
            catch (ArgumentException exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exception.Message);
                Threading();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Main();
            }
            catch (InvalidOperationException exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exception.Message);
                Threading();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Main();
            }
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

        private static void Threading()
        {
            Thread.Sleep(900*3);
        }
    }
}
