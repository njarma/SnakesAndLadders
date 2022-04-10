using Microsoft.Extensions.DependencyInjection;
using SnakesAndLadders.Classes;
using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IGameBoard, GameBoard>()
                .AddSingleton<IPlayer, Player>()
                .AddSingleton<ILadder, Ladder>()
                .AddSingleton<ISnake, Snake>()
                .AddSingleton<IConsoleIO, ConsoleIO>()
                .BuildServiceProvider();

            var gameBoard = serviceProvider.GetService<IGameBoard>();
            gameBoard.PlayGame();
        }
    }
}

