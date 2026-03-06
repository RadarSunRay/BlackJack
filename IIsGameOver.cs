namespace BlackJack
{
    public interface IIsGameOver
    {
        public bool GameOver { get; set; }
        public void CheckGameOver(IPlayer player, IRandom _random, IGameBoard game);
        public void DillerNumMorePlayers(IPlayer player, IRandom _random, IGameBoard game);
        public void DillerGameOver(IPlayer player, IRandom _random, IGameBoard game);
        public void DrawGameOver(IPlayer player, IRandom _random, IGameBoard game);
    }
}
