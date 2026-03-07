namespace BlackJack
{
    public class Player : IPlayer
    {
        public List<Cards> CardsName { get; set; } =
        [
            new CardWorms("J", 5, ConsoleColor.Red, "♥"),
            new CardWorms("Q", 5, ConsoleColor.Red, "♥"),
            new CardWorms ("K", 5, ConsoleColor.Red, "♥"),
            new CardWorms ("A", 5, ConsoleColor.Red, "♥"),
            new CardWorms("10", 10, ConsoleColor.Red, "♥"),
            new CardWorms ("9", 9, ConsoleColor.Red, "♥"),
            new CardWorms ("8", 8, ConsoleColor.Red, "♥"),
            new CardWorms ("7", 7, ConsoleColor.Red, "♥"),
            new CardWorms ("6", 6, ConsoleColor.Red, "♥"),
            new CardWorms ("5", 5, ConsoleColor.Red, "♥"),
            new CardWorms ("4", 4, ConsoleColor.Red, "♥"),
            new CardWorms ("3", 3, ConsoleColor.Red, "♥"),
            new CardWorms ("2", 2, ConsoleColor.Red, "♥"),
            new CardClubs("J", 5, ConsoleColor.DarkCyan, "♣"),
            new CardClubs("Q", 5, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("K", 5, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("A", 5, ConsoleColor.DarkCyan, "♣"),
            new CardClubs("10", 10, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("9", 9, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("8", 8, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("7", 7, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("6", 6, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("5", 5, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("4", 4, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("3", 3, ConsoleColor.DarkCyan, "♣"),
            new CardClubs ("2", 2, ConsoleColor.DarkCyan, "♣"),
            new CardDiamond("J", 5, ConsoleColor.DarkRed, "♦"),
            new CardDiamond("Q", 5, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("K", 5, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("A", 5, ConsoleColor.DarkRed, "♦"),
            new CardDiamond("10", 10, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("9", 9, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("8", 8, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("7", 7, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("6", 6, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("5", 5, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("4", 4, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("3", 3, ConsoleColor.DarkRed, "♦"),
            new CardDiamond ("2", 2, ConsoleColor.DarkRed, "♦"),
            new CardPeaks("J", 5, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks("Q", 5, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("K", 5, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("A", 5, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks("10", 10, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("9", 9, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("8", 8, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("7", 7, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("6", 6, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("5", 5, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("4", 4, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("3", 3, ConsoleColor.DarkBlue, "♠"),
            new CardPeaks ("2", 2, ConsoleColor.DarkBlue, "♠"),
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
            int valueCard = _random.Next(2, 2);
            var selectedCard = CardsName
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
                Console.ForegroundColor = card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Общее число: {NumPlayer}");
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
            Console.WriteLine("Ваши карты:");
            foreach (var card in selectedCard)
            {

                Console.ForegroundColor = card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.WriteLine("Карты Диллера:");
            foreach (var card in selectedCard)
            {
                Console.ForegroundColor = card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.WriteLine("Карты Диллера:");
            foreach (var card in selectedCard)
            {
                Console.ForegroundColor = card.Suit;
                Console.Write($"{card.Name} {card.Symbol} ({card.Value})\t");
                Console.ResetColor();
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
