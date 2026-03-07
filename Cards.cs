namespace BlackJack
{
    public class Cards : ICards
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Value { get; set; }
        public ConsoleColor Suit {  get; set; }
        public Cards(string name, int value, ConsoleColor suit, string symbol)
        {
            Name = name;
            Value = value;
            Suit = suit;
            Symbol = symbol;
        }
    }
}
