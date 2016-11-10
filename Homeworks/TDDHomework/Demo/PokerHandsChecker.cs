using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidNumberOfCardInHand = 5;
        private const int ValidIsOnePairGroupCount = 4;
        private const int ValidIsFourOfAKindGroupCount = 4;
        private const int ValidIsThreeOfAKindGroupCount = 3;
        private const int ValidIsTwoPairGroupCount = 3;
        private const int ValidNumberOfSuitsForFlush = 1;

        public bool IsValidHand(IHand hand)
        {
            int cardsLen = 0;

            if (hand == null)
            {
                throw new ArgumentNullException("Hand must not be null");
            }

            cardsLen = hand.Cards.Count;

            if (cardsLen != 5)
            {
                return false;
            }
            
            for (int i = 0; i < cardsLen; i++)
            {
                for (int j = i + 1; j < cardsLen; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face &&
                        hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            bool isStraight = true;
            if (IsFlush(hand))
            {
                var sortedHand = hand.Cards.Select(x => (int)x.Face).OrderBy(x => x).ToArray();

                bool hasAceAndTwo = hand.Cards.Select(x => x).Any(x => x.Face == CardFace.Ace) &&
                                    hand.Cards.Select(x => x).Any(x => x.Face == CardFace.Two);

                if (hasAceAndTwo)
                {
                    int aceIndex = Array.IndexOf(hand.Cards.ToArray(), (int)CardFace.Ace);
                    sortedHand[aceIndex] = 1;
                    sortedHand = sortedHand.OrderBy(x => x).ToArray();
                }

                for (int i = 0; i < sortedHand.Length - 1; i++)
                {
                    if (sortedHand[i] + 1 != sortedHand[i + 1])
                    {
                        isStraight = false;
                    }
                }
            }

            return isStraight;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            bool result = hand.Cards
                                    .GroupBy(x => x.Face)
                                    .Any(x => x.Count() == ValidIsFourOfAKindGroupCount);

            return result;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            
            bool result = IsTwoPair(hand) && IsThreeOfAKind(hand);

            return result;
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            int numberOfSuitsInTheHand = hand.Cards.GroupBy(x => x.Suit).Count();
            bool result = (numberOfSuitsInTheHand == ValidNumberOfSuitsForFlush);

            return result;
        }

        public bool IsStraight(IHand hand)
        {
            
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (hand.Cards.GroupBy(x => x.Suit).Count() == 1)
            {
                return false;
            }

            bool isStraight = true;
            var sortedHand = hand.Cards.Select(x => (int)x.Face).OrderBy(x => x).ToArray();

            bool hasAceAndTwo = hand.Cards.Select(x => x).Any(x => x.Face == CardFace.Ace) &&
                                hand.Cards.Select(x => x).Any(x => x.Face == CardFace.Two);

            if (hasAceAndTwo)
            {
                int aceIndex = Array.IndexOf(hand.Cards.ToArray(), (int)CardFace.Ace);
                sortedHand[aceIndex] = 1;
                sortedHand = sortedHand.OrderBy(x => x).ToArray();
            }

            for (int i = 0; i < sortedHand.Length - 1; i++)
            {
                if (sortedHand[i] + 1 != sortedHand[i + 1])
                {
                    isStraight = false;
                    break;
                }
            }

            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            bool result = hand.Cards
                                    .GroupBy(x => x.Face)
                                    .Any(x => x.Count() == ValidIsThreeOfAKindGroupCount);

            return result;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            
            int differentCardsFacesCount = hand.Cards.GroupBy(x => x.Face).Count();

            bool result = differentCardsFacesCount == ValidIsTwoPairGroupCount;

            return result;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }
            
            int differentCardsFacesCount = hand.Cards.GroupBy(x => x.Face).Count();

            bool result = differentCardsFacesCount == ValidIsOnePairGroupCount;

            return result;

        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            int differentCardsCount = hand.Cards.GroupBy(x => x.Face).Count();

            //TODO check all possible combinations eg: Flush, FourOfAKind
            bool result = !IsFlush(hand) 
                            && !IsFourOfAKind(hand)
                            && differentCardsCount == ValidNumberOfCardInHand;

            return result;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
