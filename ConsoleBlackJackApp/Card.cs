using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJackApp
{   /// <summary>
/// let's keep it simple for now?so here is my Card....
/// </summary>
   public class Card
    {
        public string ID { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public Card() { }
        public Card(string id,string suit,int value)
        {
            ID = id;
            Suit = suit;
            Value = value;
        }
    }
}
