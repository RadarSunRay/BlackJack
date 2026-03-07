using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class CardWorms : Cards
    {
        public CardWorms(string name, int value, ConsoleColor suit, string symbol) : base(name, value, suit, symbol)
        {
        }
    }
}
