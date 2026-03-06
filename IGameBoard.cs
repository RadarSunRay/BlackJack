namespace BlackJack
{
    public interface IGameBoard
    {
        void StartGame(IPlayer player, IRandom _random, IIsGameOver isGameOver);
    }
}
