namespace BlackJack
{
    public class IsGameOver : IIsGameOver
    {
        public bool GameOver { get; set; } = false;
        public void CheckGameOver(IPlayer player, IRandom _random, IGameBoard game)
        {
            if (GameOver == true)
            {
                player.Answer = String.Empty;
                while (!player.Answer.Equals("Нет", StringComparison.OrdinalIgnoreCase))
                {

                    Console.WriteLine("Начать заново?");
                    player.Answer = Console.ReadLine();
                    switch (player.Answer)
                    {
                        case string s when s.Equals("Да", StringComparison.OrdinalIgnoreCase):
                            GameOver = false;
                            Console.Clear();
                            game.StartGame(player, _random, this);
                            break;
                        case string s when s.Equals("Нет", StringComparison.OrdinalIgnoreCase):
                            Console.WriteLine("Спасибо за игру!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                            break;
                    }

                }
            }
        }
        public void DillerNumMorePlayers(IPlayer player, IRandom _random, IGameBoard game)
        {
            if (player.DillerNum > player.NumPlayer && player.DillerNum <= 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{player.Name} lost!\n{player.Name}: {player.Balance} (-{player.Bet})");
                Console.ResetColor();
                player.Balance -= player.Bet;
                GameOver = true;
                CheckGameOver(player, _random, game);
                Console.ResetColor();
            }
        }
        public void DillerGameOver(IPlayer player, IRandom _random, IGameBoard game)
        {
            if (player.DillerNum > 21 || player.DillerNum < player.NumPlayer)
            {
                player.Balance += player.Bet;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Диллер проиграл!\n{player.Name}: {player.Balance} (+{player.Bet})");
                Console.ResetColor();
                GameOver = true;
                CheckGameOver(player, _random, game);
            }
        }
        public void DrawGameOver(IPlayer player, IRandom _random, IGameBoard game)
        {
            if (player.DillerNum == player.NumPlayer)
            {
                Console.WriteLine("Ничья!");
                GameOver = true;
                CheckGameOver(player, _random, game);
            }
        }
    }
}
