namespace BlackJack
{
    public class GameBoard : IGameBoard
    {
        public void StartGame(IPlayer player, IRandom _random, IIsGameOver isGameOver)
        {
            player.PlayerInfo();
            player.CheckBalance();
            player.BetInfo();
            player.UpdatePlayerInfo(_random);
            player.PlayerAnswer(isGameOver, _random, this);
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            player.DillerInfo(_random);
            while (player.DillerNum <= 17)
            {
                Thread.Sleep(2000);
                player.UpdateDillerInfo(_random);
            }
            isGameOver.DillerNumMorePlayers(player, _random, this);
            isGameOver.DillerGameOver(player, _random, this);
            isGameOver.DrawGameOver(player, _random, this);
        }
    }
}
