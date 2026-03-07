namespace BlackJack
{
    public interface ICards
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Value { get; set; }
        public ConsoleColor Suit {  get; set; }
    }
}
