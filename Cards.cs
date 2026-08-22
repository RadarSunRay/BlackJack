using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Cards
    {
        private static readonly (string Name, int Value)[]
            Ranks =
        {
            ("2", 2), ("3", 3), ("4", 4), ("5", 5), ("6", 6), ("7", 7), ("8", 8), ("9", 9), ("10", 10),
            ("J", 10), ("Q", 10), ("K", 10), ("A", 11)
        };

        public Deck[] CardsName { get; set; } =
            Enum.GetValues<Suit>()
            .SelectMany(suit => Ranks.Select(rank => new Deck(rank.Name, rank.Value, suit, GetSuitSymbol(suit))))
            .ToArray();

        private static string GetSuitSymbol(Suit suit) =>
            suit switch
            {
                Suit.Hearts => "♥",
                Suit.Diamonds => "♦",
                Suit.Spades => "♠",
                Suit.Clubs => "♣"
            };
    }
}
