namespace BlackJack
{
    public class Deck : ICards
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Value { get; set; }
        public Suit Suit {  get; set; }
        public Deck(string name, int value, Suit suit, string symbol)
        {
            Name = name;
            Value = value;
            Suit = suit;
            Symbol = symbol;
        }
    }
}
