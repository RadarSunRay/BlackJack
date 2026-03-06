namespace BlackJack
{
    public interface IPlayer
    {
        public List<Cards> CardsName { get; set; }
        string Name { get; set; }
        int Balance { get; set; }
        string Answer { get; set; }
        public void GetPlayerInfo();
        public void PlayerInfo();
        public void BetInfo();
        public void UpdatePlayerInfo(IRandom _random);
        public void CheckBalance();
        public void CheckAnswer(IRandom _random);
        public void DillerInfo(IRandom _random);
        public void UpdateDillerInfo(IRandom _random);
        public void PlayerAnswer(IIsGameOver isGameOver, IRandom _random, IGameBoard game);
        int Bet { get; set; }
        int NumPlayer { get; set; }
        int DillerNum { get; set; }
    }
}
