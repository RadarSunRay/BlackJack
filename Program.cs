// See https://aka.ms/new-console-template for more information
using BlackJack;

Console.WriteLine("Hello, World!");
IGameBoard gameBoard = new GameBoard();
IPlayer player = new Player();
IIsGameOver isGameOver = new IsGameOver();
IRandom random = new MyRandom();
GameLogger logger = new(gameBoard, player, isGameOver, random);
logger.Log();