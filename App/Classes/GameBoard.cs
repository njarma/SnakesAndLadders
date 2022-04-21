using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Classes
{
    public class GameBoard: IGameBoard
    {
        public int Length { get; private set; }
        
        private readonly IPlayer _player;
        private readonly ISnake _snake;
        private readonly ILadder _ladder;
        private readonly IConsoleIO _console;

        public GameBoard(IPlayer player, ISnake snake, ILadder ladder, IConsoleIO console)
        {
            _player = player;
            _snake = snake;
            _ladder = ladder;
            _console = console;
            this.SetLength(100);
        }

        public void SetLength(int Length)
        {
            this.Length = Length;
        }

        public void PlayGame()
        {
            SetPlayerInformation();

            while (!_player.Get().HasWin)
            {
                _console.WriteLine("Please press enter to roll your dice");
                Convert.ToString(_console.ReadLine());

                PlayerMovements();
                var TokenPosition = _player.Get().TokenPosition;
                FindLadder(TokenPosition);
                FindSnake(TokenPosition);
            }
        }

        private void SetPlayerInformation()
        {
            _console.WriteLine("Enter your nick name:");
            var name = Convert.ToString(Console.ReadLine());
            _player.SetName(name);
        }
        
        private void PlayerMovements()
        {
            var diceResult = _player.RollDice();
            _player.MoveTokenPosition(diceResult, Length);
        }

        private void FindLadder(int tokenPosition)
        {
            var ladderPosition = _ladder.FindTargetPosition(tokenPosition);
            _player.SetNewPosition(ladderPosition);
        }

        private void FindSnake(int tokenPosition)
        {
            var snakePostion = _snake.FindTargetPosition(tokenPosition);
            _player.SetNewPosition(snakePostion);
        }
    }
}