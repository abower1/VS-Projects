using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckUtilities;

namespace GoFishGame
{
    class Program
    {
        private const string PAUSE = "*PRESS ANY KEY TO CONTINUE*";

        static void Main(string[] args)
        {
            GoFishDeck gd = new GoFishDeck();
            gd.setup(2);
            List<Card> p1Hand = new List<Card>(gd.draw(7));
            List<Card> p2Hand = new List<Card>(gd.draw(7));
            List<String> players = new List<string>(gd.getPlayers());
            Console.WriteLine("Welcome to go fish!\nThis is only a two player game, so.. Deal with it?");
            pause();
            Console.WriteLine("To play, you're going to be Player1 or Player2.\nWait your turn, it's rather rude;");
            Console.WriteLine("Ready Player1? It's your turn to start.\nSo fuck off player2!");
            pause();
            int turnCount = 1;
            while (!gd.isGameOver())
            {
                if(turnCount % 2 == 1)
                {
                    playerTurn(gd, players[0], p1Hand);
                }
                else
                {
                    playerTurn(gd, players[1], p2Hand);
                }
            }

        }

        private static void playerTurn(GoFishDeck deck, String player, List<Card> hand)
        {
            try
            {
                Console.WriteLine("Alright " + player + ", your hand is:");
                foreach(Card c in hand)
                {
                    Console.WriteLine(c.ToString());
                }

                Console.Write("Enter the value you would like to fish for: ");
            }

            catch (ImproperAskException e)
            {

            }
            finally
            {

            }
        }

        private static void pause()
        {
            Console.WriteLine(PAUSE);
            Console.Read();
            Console.Clear();
        }
    }
}
