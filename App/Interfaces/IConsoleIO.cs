namespace SnakesAndLadders.Interfaces
{
    public interface IConsoleIO
    {
        public void Write(string message);

        public void WriteLine(string message);

        public void WriteLine(string message, List<object> args);

        public string? ReadLine();
    }

}
