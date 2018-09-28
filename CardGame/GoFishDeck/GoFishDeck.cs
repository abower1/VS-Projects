using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckUtilities;

namespace GoFishDeck
{
    public class GoFishDeck : Deck
    {
        Dictionary<string, List<Card>> playerPiles;
        public void startGame(int numPlayers)
        {
            playerPiles = new Dictionary<string, List<Card>>();
            for(int i = 1; i <= numPlayers; i++)
            {
                playerPiles["Player" + i] = new List<Card>();
            }
        }


        public bool ask(Value guessValue, List<Card> opponentHand)
        {
            foreach(Card c in opponentHand)
            {
                if (c.value == guessValue)
                    return true;
            }

            return false;
        }

    }
}
