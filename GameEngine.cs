namespace BlackJack
{
    public class GameLogger
    {
        private readonly IGameBoard _gameBoard;
        private readonly IPlayer _player;
        private readonly IIsGameOver _isGameOver;
        private readonly IRandom _random;
        public GameLogger(IGameBoard gameBoard, IPlayer player, IIsGameOver isGameOver, IRandom random)
        {
            _gameBoard = gameBoard;
            _player = player;
            _isGameOver = isGameOver;
            _random = random;
        }
        public void Log()
        {
            _player.GetPlayerInfo();
            Console.Clear();
            while (!_isGameOver.GameOver)
            {
                _gameBoard.StartGame(new Player { Name = _player.Name, Balance = _player.Balance }, _random, _isGameOver);
            }
        }
    }
}
