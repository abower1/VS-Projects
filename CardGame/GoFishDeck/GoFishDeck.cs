using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeckUtilities
{
    public class GoFishDeck : Deck
    {
        Dictionary<string, List<Card>> playerPiles;
        /// <summary>
        /// Initializes game with new set of players
        /// </summary>
        /// <param name="numPlayers">Number of players to designate</param>
        public void setup(int numPlayers)
        {
            playerPiles = new Dictionary<string, List<Card>>();
            for(int i = 1; i <= numPlayers; i++)
            {
                playerPiles["Player" + i] = new List<Card>();
            }
        }


        public bool ask(Value guessValue, List<Card> playerHand, List<Card> opponentHand)
        {
            bool playerHasCard = false;
            foreach(Card c in playerHand)
            {
                if (c.value == guessValue)
                {
                    playerHasCard = true;
                    break;
                }
            }
            if (!playerHasCard)
            {
                throw new ImproperAskException("Guessing player does not have any cards matching a " + guessValue.ToString());
            }

            foreach(Card c in opponentHand)
            {
                if (c.value == guessValue)
                    return true;
            }

            return false;
        }

        public bool isGameOver()
        {
            return DeckIsEmpty();
        }

        public string winner()
        {
            int maxCardPile = 0;
            string winningPlayer = "";
            foreach(String player in playerPiles.Keys)
            {
                if(playerPiles[player].Count > maxCardPile)
                {
                    winningPlayer = player;
                    maxCardPile = playerPiles[player].Count;
                }
            }

            return winningPlayer;
        }

        public IEnumerable<String> getPlayers()
        {
            return playerPiles.Keys.ToList();
        }

    }

    public class ImproperAskException : Exception
    {
        public ImproperAskException()
        {

        }

        public ImproperAskException(string message)
        : base(message)
        {
        }
    }
}
