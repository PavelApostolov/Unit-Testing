using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestFixture]
    public class PokerTests
    {
        [TestCase(CardFace.Six,CardSuit.Hearts)]
        [TestCase(CardFace.Ace, CardSuit.Spades)]
        [TestCase(CardFace.Queen, CardSuit.Diamonds)]
        [TestCase(CardFace.Ten, CardSuit.Hearts)]
        public void CardToString_WhenToStringIsCalled_ShouldPrintCorrectResult(CardFace cf, CardSuit cs)
        {
            Card card = new Card(cf, cs);
            string expectedResult = cf + " of " + cs;
            string actualResult = String.Empty;

            actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void HandToString_ShouldPrintAllCardsInformationInTheHand()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            string expectedResult = String.Join(", ",hand.Cards);
            string actualresult = String.Empty;

            actualresult = hand.ToString();

            Assert.AreEqual(expectedResult, actualresult);
        }
    }
}
