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
    using Models.Fields.Contracts;
    using Utilities;
    using Models.Players.Contracts;
    using Factories;
    public class Program
    {
        static Dictionary<string, int> symbols = new Dictionary<string, int>()
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
            IField field = new Field(new MatrixDrawer(factory.GenerateType(colorType)), new Tic_Tac_Toe_ResultValidator());
            IEngine engine = new Engine(field, new Controller(playerOne, playerTwo, field), playerOne, playerTwo);
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
                    //Exception from the property validation should be thrown;
                    player = new Player(playerTwoUserName, sign);
                }
            }
            else
            {
                Console.WriteLine("Player two enter your sign:");
                KeyValuePair<string, int> kvp = symbols.FirstOrDefault(k => k.Value == 0);
                string sing = kvp.Key;
                player = new ComputerPlayer(sing);
            }
            return player;
        }
    }
}
