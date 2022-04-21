using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders.Classes
{
    public class Player: IPlayer
    {
        public string Name { get; private set; } = "";
        public int TokenPosition { get; private set; } = 1;
        public int DiceResult { get; private set; } = 0;
        public bool HasWin { get; private set; } = false;

        private readonly IConsoleIO _console;

        public Player(IConsoleIO console)
        {
            _console = console;
        }

        public void SetName(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _console.WriteLine("You must enter a valid name");
                return;
            }
            Name = name;
        }

        public int RollDice()
        {
            Random random = new Random();
            var value = random.Next(1, 7);
            _console.WriteLine("Dice result is: {0}", new List<object> { value });
            return value;
        }

        public void MoveTokenPosition(int diceResult, int boardLength)
        {
            if (CheckExceedLastPosition(diceResult, boardLength))
            {
                _console.WriteLine("You can't exceed the position {0}, you come back to position {1}", new List<object> { boardLength, TokenPosition });
                return;
            }
            AddDiceResult(diceResult);
            CheckWin(boardLength);
        }

        public void SetNewPosition(int position)
        {
            if (position > 0)
            {
                TokenPosition = position;
                _console.WriteLine("You have been redirected to the position: {0}", new List<object> { TokenPosition });
            }
        }

        public Player Get()
        {
            return this;
        }

        private bool CheckExceedLastPosition(int diceResult, int boardLength)
        {
            var newPosition = TokenPosition + diceResult;
            return (boardLength - newPosition) < 0 ? true : false;
        }

        private void CheckWin(int boardLength)
        {
            if (TokenPosition == boardLength)
            {
                HasWin = true;
                _console.WriteLine("Congratulations {0}, you have won the game!", new List<object> { Name });
            }
        }

        private void AddDiceResult(int diceResult)
        {
            TokenPosition += diceResult;
            _console.WriteLine("Your new position is: {0}", new List<object> { TokenPosition });
        }
    }
}