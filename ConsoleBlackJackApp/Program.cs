using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJackApp
{
    class Program
    {
        public static void ShowStats(BlackJack bj)
        {
            Console.WriteLine("Протвник");
            foreach (Card c in bj.Dealer.Hand)
            {
                Console.WriteLine(string.Format("{0},{1}", c.ID, c.Suit));
            }
            Console.WriteLine(bj.Dealer.Hand.Value);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Игрок");
            foreach (Card c in bj.Player.Hand)
            {
                Console.WriteLine(string.Format("{0},{1}", c.ID, c.Suit));
            }
            Console.WriteLine(bj.Player.Hand.Value);
            Console.WriteLine(Environment.NewLine);
        }


        static void Main(string[] args)
        {
            string input = "";
            BlackJack bj = new BlackJack(17);
            ShowStats(bj);
            while (bj.Result==GameResult.Pending)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "h")
                {
                    bj.Hit();
                    ShowStats(bj);
                }
                else
                {
                    bj.Stand();
                    ShowStats(bj);
                }
            }
            Console.WriteLine(bj.Result);

            Console.ReadLine();

        }
    }
}
