namespace BlackJack
{
    public class Player : IPlayer
    {
        public Cards card { get; set; } = new Cards();
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
            Console.WriteLine($"{Name}:\nБаланс: {Balance}$");
            Console.ResetColor();
        }
        public void BetInfo()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите ставку (число):");
                string input = Console.ReadLine();
                Console.ResetColor();
                if (int.TryParse(input, out int result))
                {
                    if (result > Balance)
                    {
                        Console.WriteLine("Недостаточно средств!");
                    }
                    else if (result <= 0)
                    {
                        Console.WriteLine("Ставка должна быть больше нуля!");
                    }
                    else
                    {
                        Bet = result;
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Нужно ввести целое число цифрами.");
                }
            }
        }
        public void UpdatePlayerInfo(IRandom _random)
        {
            int valueCard = 2;
            var selectedCard = card.CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            NumPlayer = resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name}:\nБаланс: {Balance}$ (-{Bet}$)");
            Console.WriteLine("Ваши карты:");
            foreach (var card in selectedCard)
            {
                Console.ForegroundColor = (ConsoleColor)card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Общее число: {NumPlayer}");
            Console.ResetColor();
        }
        public void CheckAnswer(IRandom _random)
        {
            int valueCard = 1;
            var selectedCard = card.CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            NumPlayer += resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Name}:");
            Console.WriteLine("Ваши карты:");
            foreach (var card in selectedCard)
            {
                Console.ForegroundColor = (ConsoleColor)card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Общее число: {NumPlayer}");
            Console.ResetColor();
        }
        public void DillerInfo(IRandom _random)
        {
            int valueCard = 2;
            var selectedCard = card.CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            DillerNum = resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Карты Диллера:");
            foreach (var card in selectedCard)
            {
                Console.ForegroundColor = (ConsoleColor)card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Общее число: {DillerNum}");
            Console.ResetColor();
        }
        public void UpdateDillerInfo(IRandom _random)
        {
            int valueCard = 1;
            var selectedCard = card.CardsName
                .OrderBy(x => _random.Next())
                .Take(valueCard)
                .ToList();
            var resultValue = selectedCard.Sum(x => x.Value);
            DillerNum += resultValue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Карты Диллера:");
            foreach (var card in selectedCard)
            {
                Console.ForegroundColor = (ConsoleColor)card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                            Console.WriteLine($"{Name} lost!\n{Name}: {Balance}$ (-{Bet})$");
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
