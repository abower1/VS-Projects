using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckUtilities;

namespace DeckDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            for(int counter = 0; counter <= 100; counter++)
            {
                List<Card> hand = d.draw(5).ToList();
                Console.WriteLine("Hand: " + (counter + 1));
                foreach (Card c in hand)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine();
                d.Discard(hand);
                
            }

            Console.Read();

        }
    }
}
