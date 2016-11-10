using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class PokerHandsCheckerTests
    {
        [Test]
        public void IsValidHand_WhenHandHaveFiveDifferentCards_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsValidHand(hand);

            Assert.True(result);
        }

        [Test]
        public void IsValidHand_WhenHandHaveTwoEqualCards_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsValidHand(hand);

            Assert.False(result);
        }

        [Test]
        public void IsValidHand_WhenHandHasNullCards_ShouldThrowArgumentNullException()
        {
            PokerHandsChecker hc = new PokerHandsChecker();
            
            Assert.Throws<ArgumentNullException>(() => hc.IsValidHand(null));
        }

        [Test]
        public void IsFlush_WhenHandHaveFiveDifferentCardsOfTheSameSuit_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsFlush(hand);

            Assert.True(result);
        }

        [Test]
        public void IsFourOfAKind_WhenHandConsistsOfCardsWithFourEqualFaces_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsFourOfAKind(hand);

            Assert.True(result);
        }

        [Test]
        public void IsHighCard_WhenThereIsNoCombination_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsHighCard(hand);

            Assert.True(result);
        }

        [Test]
        public void IsOnePair_WhenTheHandHasOnePair_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsOnePair(hand);

            Assert.True(result);
        }

        [Test]
        public void IsOnePair_WhenTheHandIsNotOnePair_ShouldReturnFalse()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsOnePair(hand);

            Assert.False(result);
        }

        [Test]
        public void IsTwoPair_WhenTheHandHasTwoPair_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsTwoPair(hand);

            Assert.True(result);
        }

        [Test]
        public void IsTwoPair_WhenTheHandIsNotTwoPair_ShouldReturnFalse()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsTwoPair(hand);

            Assert.False(result);
        }

        [Test]
        public void IsThreeOfAKind_WhenHandConsistsOfCardsWithTHreeEqualFaces_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsThreeOfAKind(hand);

            Assert.True(result);
        }

        [Test]
        public void IsFullHouse_WhenTheHandIsFullHouse_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsFullHouse(hand);

            Assert.True(result);
        }

        [Test]
        public void IsStraight_WhenTheHandIsStraight_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsStraight(hand);

            Assert.True(result);
        }

        [Test]
        public void IsStraightFlush_WhenTheHandIsStraightFlush_ShouldReturnTrue()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            PokerHandsChecker hc = new PokerHandsChecker();
            bool result = false;

            result = hc.IsStraightFlush(hand);

            Assert.True(result);
        }
    }
}
