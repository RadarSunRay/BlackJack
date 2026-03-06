namespace BlackJack
{
    public class MyRandom : IRandom
    {
        private Random random;
        public MyRandom()
        {
            random = new Random();
        }
        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }
        public int Next()
        {
            return (int)(random.Next());
        }
    }
}
