using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJackApp
{
   public class BlackJack
    {
        public Member Dealer = new Member();
        public Member Player = new Member();
        public GameResult Result { get; set; }
        public Desk MainDesk;
        public int StandLimit { get; set; }
           /// <summary>
           /// 
           /// </summary>
           /// <param name="dealerStandLimit"></param>
        public BlackJack(int dealerStandLimit)
        {
            Result = GameResult.Pending;
            StandLimit = dealerStandLimit;
            MainDesk = BlackJackRules.ShuffledDesk;
            Dealer.Hand.Clear();
            Player.Hand.Clear();

            for (int i = 0; ++i<3; )
            {
                Dealer.Hand.Push(MainDesk.Pop());
                Player.Hand.Push(MainDesk.Pop());
            }
           
        }

        public void Hit()
        {
           if(BlackJackRules.CanPlayerHit(Player.Hand)&& Result == GameResult.Pending)
            {
                Player.Hand.Push(MainDesk.Pop());
            }
        }

        public void Stand()
        {
            if (Result == GameResult.Pending)
            {
                while (BlackJackRules.CanDealerHit(Dealer.Hand,StandLimit))
                {
                    Dealer.Hand.Push(MainDesk.Pop());
                }
                Result = BlackJackRules.GetResult(Player, Dealer);
            }
        }
    }
}
