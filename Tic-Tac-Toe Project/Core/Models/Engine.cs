namespace Tic_tac_toe.Core.Models
{
    using System;
    using System.Threading;
    using Contracts;

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
                        Console.Clear();
                        _controller.PlayRound();
                        Thread.Sleep(400 * 5);
                        Console.Clear();
                        Console.WriteLine("If you want to play again select play round option:\n(1 Play round\n(2 Show PlayerInfo\n(3 Exit");
                    }
                    else if (command == "2")
                    {
                        Console.WriteLine("Enter player name");
                        string playerName = Console.ReadLine();
                        Console.WriteLine(_controller.PlayerInfo(playerName));
                    }
                    else
                    {
                        _controller.Exit();
                    }
                }
                catch (InvalidOperationException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(exception.Message);
                    Thread.Sleep(100*16);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Run();
                }
               
                command = Console.ReadLine();
            }
        }
    }
}
