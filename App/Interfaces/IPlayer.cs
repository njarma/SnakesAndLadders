using SnakesAndLadders.Classes;

namespace SnakesAndLadders.Interfaces
{
    public interface IPlayer
    {
        public void SetName(string? name);

        public int RollDice();

        public void MoveTokenPosition(int position, int boardLength);

        public void SetNewPosition(int position);

        public Player GetPlayer();
    }
}