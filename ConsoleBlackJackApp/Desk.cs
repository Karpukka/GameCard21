using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJackApp
{
   public class Desk : Stack<Card>
    {    /// <summary>
    ///   So a Desk can simply be a stack of cards 
    /// </summary>
    /// <param name="collection"></param>
       public Desk(IEnumerable<Card> collection) : base(collection) { }
        public Desk() : base(52) { }

        //let's add an indexer just in case..
        public Card this[int index]
        {
            get
            {
                Card item;
                if (index >= 0 && index <= this.Count - 1)
                {
                    item = this.ToArray()[index];
                }
                else
                {
                 item = null;
                }
                return item;   
            }
        }
        //let's get the value of the desk
        public double Value
        {
            get
            {
                //TODO: return value from business rule
                return BlackJackRules.HandValue(this);
            }
        }
    }
   
}
