// See https://aka.ms/new-console-template for more information
using BlackJack;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
Console.WriteLine("Hello, World!");
IGameBoard gameBoard = new GameBoard();
IPlayer player = new Player();
IIsGameOver isGameOver = new IsGameOver();
IRandom random = new MyRandom();
GameLogger logger = new(gameBoard, player, isGameOver, random);
logger.Log();