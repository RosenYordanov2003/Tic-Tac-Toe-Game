namespace Tic_tac_toe.Core.Models
{
    using System;
    using System.Threading;
    using Contracts;
    using Factories;
    using Tic_tac_toe.Models.Drawers.Contracts;
    using Tic_tac_toe.Models.Drawers.Models;

    public class Engine : IEngine
    {
        private readonly IController _controller;

        public Engine(IController controller)
        {
            _controller = controller;
        }

        public void Run()
        {
            Console.WriteLine("Please select option:\n(1 Play round\n(2 Show PlayerInfo\n(3 Exit");
            string command = Console.ReadLine();

            while (true)
            {
                try
                {
                    if (command == "1")
                    {
                        IDrawer<string[,]> matrixDrawer = CreateMatrixDrawer();
                        Console.Clear();
                        _controller.PlayRound(matrixDrawer);

                        Thread.Sleep(400 * 5);
                        Console.Clear();
                        Console.WriteLine("If you want to play again select play round option:\n(1 Play round\n(2 Show PlayerInfo\n(3 Exit");
                    }
                    else if (command == "2")
                    {
                        Console.WriteLine("Enter player name");
                        string playerName = Console.ReadLine();
                        Console.WriteLine(_controller.PlayerInfo(playerName));
                        Thread.Sleep(100 * 19);
                        Console.Clear();
                        Run();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(25, 10);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Thank you for using our application, have a nice day :)");
                        Console.ForegroundColor = ConsoleColor.White;
                        _controller.Exit();
                    }
                }
                catch (InvalidOperationException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(exception.Message);
                    Thread.Sleep(100 * 17);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Run();
                }
                command = Console.ReadLine();
            }
        }

        private static IDrawer<string[,]> CreateMatrixDrawer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game starting!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter color for the field:");
            string colorType = Console.ReadLine();
            IFactory<ConsoleColor> factory = new ColorFactory();
            IDrawer<string[,]> matrixDrawer = new MatrixDrawer(factory.GenerateType(colorType));
            return matrixDrawer;
        }
    }
}
