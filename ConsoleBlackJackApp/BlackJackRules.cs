using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJackApp
{
    //Game states
    public enum GameResult { Win = 1, Lose = -1, Draw = 0, Pending = 2 }
    public static class BlackJackRules
    {
        static int value;
        //card values
        public static string[] ids = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Туз", "Валет", "Король", "Дама" };
        //card suits
        public static string[] suits = { "- червей", "- бубен", "- пик", "-крестей" };
          /// <summary>
          /// returns a new desk
          /// </summary>
        public static Desk NewDesk
        {
            get
            {
                Desk d = new Desk();
                
                foreach (string suit in suits)
                {
                    foreach (string id in ids)
                    {
                        if (id == "2")
                            value = 2;
                       else if (id == "3")
                            value = 3;
                        else if (id == "4")
                            value = 4;
                        else if (id == "5")
                            value = 5;
                        else if (id == "6")
                            value = 6;
                        else if (id == "7")
                            value = 7;
                        else if (id == "8")
                            value = 8;
                        else if (id == "9")
                            value = 9;
                        else if (id == "10")
                            value = 10;
                        else if (id == "Валет")
                            value = 2;
                        else if (id == "Дама")
                            value = 3;
                        else if (id == "Король")
                            value = 4;
                        else if (id == "Туз")
                            value = 11;
                        d.Push(new Card(id, suit, value));
                    }
                }
                return d;
            }
        }
            /// <summary>
            /// returns a shuffled desk
            /// </summary>
        public static Desk ShuffledDesk
        {
            get
            {
                return new Desk(NewDesk.OrderBy(card => System.Guid.NewGuid()).ToArray());

            }
        }
         /// <summary>
         /// Calculate the value of a Hand)))
         /// A Hand is just a few cards so we can represent as Desk<Card> again
         /// Compare two totals for aces and return the one closes to"less than or equal to 21"
         /// </summary>
         /// <param name="desk"></param>
         /// <returns></returns>
        public static double HandValue(Desk desk)
        {

            //Ace =1
            int val1 = desk.Sum(c => c.Value);
            //Ace=11
            double aces = desk.Count(c => c.Suit == "A");  //enums
            double val2 = aces > 0 ? val1 + (10 * aces) : val1;
            return new double[] { val1, val2 }
            .Select(handVal => new
            {
                handVal,
                weight = Math.Abs(handVal - 21) + (handVal > 21 ? 100 :
            0)
            })
            .OrderBy(n => n.weight)
            .First().handVal;
        }
        /// <summary>
        /// Check if dealer  can hit given current value of hand
        /// </summary>
        /// <param name="desk"></param>
        /// <param name="standLimit"></param>
        /// <returns></returns>

        public static bool CanDealerHit(Desk desk, int standLimit)
        {
            return desk.Value < standLimit;
        }
          /// <summary>
          /// 
          /// </summary>
          /// <param name="desk"></param>
          /// <returns></returns>
        public static bool CanPlayerHit(Desk desk)
        {
            return desk.Value < 21;
        }
          /// <summary>
          /// Chek result
          /// </summary>
          /// <param name="player"></param>
          /// <param name="dealer"></param>
          /// <returns></returns>
        public static GameResult GetResult(Member player, Member dealer)
        {
            GameResult res = GameResult.Win;
            double playerValue = HandValue(player.Hand);
            double dealerValue = HandValue(dealer.Hand);
            if (playerValue <= 21)
            {
                
                if (playerValue != dealerValue)
                {
                    double closesValue = new double[] { playerValue, dealerValue }
                    .Select(handVal => new
                    {
                        handVal,
                        weight = Math.Abs(handVal - 21) + (handVal > 21
                        ? 100 : 0)
                    })
                    .OrderBy(n => n.weight)
                    .First().handVal;

                    res = playerValue == closesValue ? GameResult.Win : GameResult.Lose;
                }
                else
                {
                    res = GameResult.Draw;
                }
            }
            else
            {
                res = GameResult.Lose;
            }
            return res;
        }
        
    }
}