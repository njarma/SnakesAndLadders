using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Classes
{
    public class Ladder: ILadder
    {
        private readonly Dictionary<int, int> _ladders = new();

        private readonly IConsoleIO _console;

        public Ladder(IConsoleIO console)
        {
            _console = console;
            SetLadderList();
        }

        public Dictionary<int, int> GetLadderList()
        {
            return _ladders;
        }

        public int FindTargetPosition(int key)
        {
            var targetPosition = _ladders.FirstOrDefault(snake => snake.Key == key).Value;
            if (targetPosition > 0)
            {
                _console.WriteLine("You found a ladder at position: {0}", new List<object> { key });
            }
            return targetPosition;
        }

        private void SetLadderList()
        {
            _ladders.Add(2, 38);
            _ladders.Add(7, 14);
            _ladders.Add(8, 31);
            _ladders.Add(15, 26);
            _ladders.Add(21, 42);
            _ladders.Add(28, 84);
            _ladders.Add(36, 44);
            _ladders.Add(51, 67);
            _ladders.Add(71, 91);
            _ladders.Add(78, 98);
            _ladders.Add(87, 94);
        }
    }
}