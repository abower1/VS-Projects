using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckUtilities
{
    public enum Suit { Spade, Heart, Diamond, Club } //Enumerated suit values for card variables
    public enum Value { Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six, Five, Four, Three, Two } //Enumerated face values
    public class Deck
    {
        internal List<Card> CardsInDeck;//List of cards waiting to be dealt
        internal List<Card> DiscardPile;//list of cards that are discarded
        /// <summary>
        /// Deck constructor
        /// Creates a new deck of cards, freshly shuffled
        /// Also sets aside place for discarded cards
        /// </summary>
        public Deck()
        {
            CardsInDeck = new List<Card>();
            foreach(Suit s in Enum.GetValues(typeof(Suit)))//iterating through all suits
            {
                foreach(Value v in Enum.GetValues(typeof(Value)))//iterating through all values
                {
                    CardsInDeck.Add(new Card(s, v));
                }
            }
            DiscardPile = new List<Card>();
            shuffle();
            
        }

        /// <summary>
        /// Adds discard pile to cards in deck and shuffles the deck
        /// </summary>
        public void shuffle()
        {
            CardsInDeck.AddRange(DiscardPile);
            HashSet<Card> temp = new HashSet<Card>(CardsInDeck);
            CardsInDeck = temp.ToList<Card>();
            CardsInDeck.Shuffle();
            foreach(Card c in CardsInDeck)
            {
                c.shuffle();
            }
        }

        /// <summary>
        /// Deals out specified number of cards,
        /// MUST discard at the end to add to discard pile.
        /// </summary>
        /// <param name="numCards">Number of cards to be dealt</param>
        /// <returns>List of cards dealt out</returns>
        public IEnumerable<Card> Deal(int numCards)
        {
            int numDealt = 0;
            List<Card> retVal = new List<Card>();
            for(int idx = 0; idx < CardsInDeck.Count && numDealt < numCards; idx++)
            {
                Card currentCard = CardsInDeck[idx];
                if (currentCard.isInDeck())
                {
                    
                    retVal.Add(currentCard);
                    currentCard.deal();
                    numDealt++;
                }
            }
            CardsInDeck = CardsInDeck.Except<Card>(retVal).ToList<Card>();
            return retVal;
            
        }
        /// <summary>
        /// adds hand of cards to discard pile
        /// </summary>
        /// <param name="hands">list of cards in hand</param>
        public void Discard(IEnumerable<Card> hands)
        {
            DiscardPile.AddRange(hands);
        }

        /// <summary>
        /// Printable list of cards still in deck
        /// </summary>
        /// <returns>String list of cards in deck</returns>
        public IEnumerable<String> printableCardsInDeck()
        {
            List<String> retVal = new List<string>();
            foreach(Card c in CardsInDeck)
            {
                retVal.Add(c.ToString());
            }
            return retVal;
        }
        /// <summary>
        /// Printable list of cards in discard
        /// </summary>
        /// <returns>String list of cards in discard pile</returns>
        public IEnumerable<String> printableDiscard()
        {
            List<String> retVal = new List<string>();
            foreach (Card c in DiscardPile)
            {
                retVal.Add(c.ToString());
            }
            return retVal;
        }

    }

    public class Card
    {
        public Suit suit { get; }
        public Value value { get; }
        private bool isDealt;
        
        /// <summary>
        /// Card object constructor - requires declaring a suit and value 
        /// </summary>
        /// <param name="_s">Suit - From Enumerated Suits</param>
        /// <param name="_v">Value - From Enumerated Vales</param>
        public Card(Suit _s, Value _v)
        {
            this.suit = _s;
            this.value = _v;
            isDealt = false;
        }
        /// <summary>
        /// Marks card as dealt
        /// </summary>
        public void deal()
        {
            isDealt = true;
        }
        /// <summary>
        /// Marks card as shuffled in deck
        /// </summary>
        public void shuffle()
        {
            isDealt = false;
        }
        /// <summary>
        /// Getter if card has been dealt
        /// </summary>
        /// <returns></returns>
        public bool isInDeck()
        {
            return !isDealt;
        }
        /// <summary>
        /// Returns string value of cards
        /// eg "Ace of Spades"
        /// </summary>
        /// <returns>String value of card</returns>
        public override string ToString()
        {
            return value.ToString() + " of " + suit.ToString() + "s";
        }



    }
    /// <summary>
    /// Extension class for Lists
    /// </summary>
    internal static class ListExtensions
    {
        private static Random rng = new Random();
        /// <summary>
        /// List shuffler for List objects
        /// </summary>
        /// <typeparam name="T">Internal Member Types within List</typeparam>
        /// <param name="list">THIS List</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }


}


