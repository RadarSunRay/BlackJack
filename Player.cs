using System;

namespace BlackJack
{
    public class Player : IPlayer
    {
        public List<Cards> CardsName { get; set; } =
        [
            new Cards("J", 5),
            new Cards("Q", 5),
            new Cards("K", 5),
            new Cards("A", 5),
            new Cards("10", 10),
            new Cards("9", 9),
            new Cards("8", 8),
            new Cards("7", 7),
            new Cards("6", 6),
            new Cards("5", 5),
            new Cards("4", 4),
            new Cards("3", 3),
            new Cards("2", 2),
        ];
        public int Balance { get; set; } = 1000;
        public string? Name { get; set; }
        public string? Answer { get; set; }
        public int Bet { get; set; }
        public int NumPlayer { get; set; }
        public int DillerNum { get; set; }
        public void GetPlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите имя игрока:");
            Name = Console.ReadLine();
            Console.ResetColor();
        }
        public void PlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name}:\nБаланс: {Balance}");
            Console.ResetColor();
        }
        public void BetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите ставку:");
            Bet = int.Parse(Console.ReadLine());
            Console.ResetColor();
        }
        public void UpdatePlayerInfo(IRandom _random)
        {
            int valueCard = _random.Next(2, 2);
            var selectedCard = CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            NumPlayer = resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name}:\nБаланс: {Balance} (-{Bet})");
            foreach (var card in selectedCard)
            {
                Console.WriteLine($"Ваши карты: {card.Name} ({card.Value})");
            }
            Console.WriteLine($"Общее число: {resultValue}");
            Console.ResetColor();
        }
        public void CheckAnswer(IRandom _random)
        {
            int valueCard = _random.Next(1, 1);
            var selectedCard = CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            NumPlayer += resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name}:");
            foreach (var card in selectedCard)
            {
                Console.WriteLine($"Ваши карты: {card.Name} ({card.Value})");
            }
            Console.WriteLine($"Общее число: {NumPlayer}");
            Console.ResetColor();
        }
        public void DillerInfo(IRandom _random)
        {
            int valueCard = _random.Next(2, 2);
            var selectedCard = CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            DillerNum = resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var card in selectedCard)
            {
                Console.WriteLine($"Карты Диллера: {card.Name} ({card.Value})");
            }
            Console.WriteLine($"Общее число: {DillerNum}");
            Console.ResetColor();
        }
        public void UpdateDillerInfo(IRandom _random)
        {
            int valueCard = _random.Next(1, 1);
            var selectedCard = CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            DillerNum += resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var card in selectedCard)
            {
                Console.WriteLine($"Карты Диллера: {card.Name} ({card.Value})");
            }
            Console.WriteLine($"Общее число: {DillerNum}");
            Console.ResetColor();
        }
        public void PlayerAnswer(IIsGameOver isGameOver, IRandom _random, IGameBoard game)
        {
            Answer = String.Empty;
            while (!Answer.Equals("Stand", StringComparison.OrdinalIgnoreCase) && !isGameOver.GameOver == true)
            {
                Console.WriteLine("Хотите взять еще карту? (Hit/Stand)");
                Answer = Console.ReadLine();
                switch (Answer)
                {
                    case string s when s.Equals("Hit", StringComparison.OrdinalIgnoreCase):
                        CheckAnswer(_random);
                        if (NumPlayer > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"{Name} lost!");
                            Console.ResetColor();
                            Balance -= Bet;
                            isGameOver.GameOver = true;
                            isGameOver.CheckGameOver(this, _random, game);
                        }
                        break;
                    case string s when s.Equals("Stand", StringComparison.OrdinalIgnoreCase):
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Число: {NumPlayer}");
                        Console.ResetColor();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }
        }
        public void CheckBalance()
        {
            if (Balance <= 0)
            {
                Console.WriteLine("У вас закончились деньги. Игра окончена.");
                Environment.Exit(0);
            }
        }
    }
}
