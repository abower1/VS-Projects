using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckUtilities;
using System.Collections.Generic;
using System.Linq;

namespace DeckTester
{
    [TestClass]
    public class DeckTester
    {
        [TestMethod]
        public void TestDeal()
        {
            Deck d = new Deck();
            List<Card> hand = d.draw(5).ToList();
            List<String> cardsInDeck = d.printableCardsInDeck().ToList();

            foreach(Card c in hand)
            {
                Assert.IsFalse(cardsInDeck.Contains(c.ToString()));
            }
        }

        [TestMethod]
        public void TestDiscard()
        {
            Deck d = new Deck();
            List<Card> hand = d.draw(5).ToList();
            d.Discard(hand);
            List<String> discardPile = d.printableDiscard().ToList();
            foreach (Card c in hand)
            {
                Assert.IsTrue(discardPile.Contains(c.ToString()));
            }
        }
    }
}
