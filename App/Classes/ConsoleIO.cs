using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Classes
{
    public class ConsoleIO: IConsoleIO
    {
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);

        public void WriteLine(string message, List<object> args)
        {
            args.ToList().ForEach(arg => Console.WriteLine(message, arg));
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
