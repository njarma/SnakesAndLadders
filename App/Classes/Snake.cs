using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Classes
{
    public class Snake: ISnake
    {
        private readonly Dictionary<int, int> _snakes = new();

        private readonly IConsoleIO _console;

        public Snake(IConsoleIO console)
        {
            _console = console;
            Set();
        }

        public int FindTargetPosition(int key)
        {
            var targetPosition = _snakes.FirstOrDefault(snake => snake.Key == key).Value;
            if (targetPosition > 0)
            {
                _console.WriteLine("You found a snake at position: {0}", new List<object> { key });
            }
            return targetPosition;
        }

        private void Set()
        {
            _snakes.Add(16, 6);
            _snakes.Add(46, 25);
            _snakes.Add(49, 11);
            _snakes.Add(62, 19);
            _snakes.Add(64, 60);
            _snakes.Add(74, 53);
            _snakes.Add(89, 68);
            _snakes.Add(92, 88);
            _snakes.Add(95, 75);
            _snakes.Add(99, 80);
        }
    }
}