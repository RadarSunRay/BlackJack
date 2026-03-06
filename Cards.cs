namespace BlackJack
{
    public class Cards : ICards
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Cards(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
