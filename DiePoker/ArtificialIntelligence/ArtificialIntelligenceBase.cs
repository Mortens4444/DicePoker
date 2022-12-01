using System;
using System.Collections.Generic;

namespace DiePoker.ArtificialIntelligence
{
    public abstract class ArtificialIntelligenceBase : IArtificialIntelligence
    {
        public abstract PokerHandType GetBestFit(List<byte> rollResult, IEnumerable<KeyValuePair<PokerHandType, double>> probabilities);

        public bool IsContains(List<byte> rollResult, PokerHandType pokerHandType)
        {
            return GetResult(rollResult, pokerHandType) > 0;
        }

        public byte GetResult(List<byte> rollResult, PokerHandType pokerHandType)
        {
            switch (pokerHandType)
            {
                case PokerHandType.HighCard:
                    return rollResult.GetHighCard();
                case PokerHandType.OnePair:
                    return (byte)(rollResult.GetOnePair() * 2);
                case PokerHandType.TwoPair:
                    var twoPair = rollResult.GetTwoPair();
                    return (byte)(twoPair.Item1 * 2 + twoPair.Item2 * 2);
                case PokerHandType.ThreeOfAKind:
                    return (byte)(rollResult.GetThreeOfAKind() * 3);
                case PokerHandType.FourOfAKind:
                    return (byte)(rollResult.GetFourOfAKind() * 4);
                case PokerHandType.FiveOfAKind:
                    return (byte)(rollResult.GetFiveOfAKind() * 5);
                case PokerHandType.FullHouse:
                    var fullHouse = rollResult.GetFullHouse();
                    return (byte)(fullHouse.Item1 * 3 + fullHouse.Item2 * 2);
                case PokerHandType.Flush:
                    byte sum = 0;
                    var flush = rollResult.GetFlush();
                    for (byte i = flush.Item2; i < flush.Item1; i++)
                    {
                        sum += i;
                    }
                    return sum;
                case PokerHandType.StraightFlush:
                    byte sum2 = 0;
                    var straightFlush = rollResult.GetStraightFlush();
                    for (byte i = straightFlush.Item2; i < straightFlush.Item1; i++)
                    {
                        sum2 += i;
                    }
                    return sum2;
                case PokerHandType._1:
                    return rollResult.GetOnes();
                case PokerHandType._2:
                    return rollResult.GetTwos();
                case PokerHandType._3:
                    return rollResult.GetThrees();
                case PokerHandType._4:
                    return rollResult.GetFours();
                case PokerHandType._5:
                    return rollResult.GetFives();
                case PokerHandType._6:
                    return rollResult.GetSixes();
                default:
                    throw new NotImplementedException();
            }
        }

        public byte GetMaxResult(List<byte> rollResult, PokerHandType pokerHandType)
        {
            switch (pokerHandType)
            {
                case PokerHandType.HighCard:
                    return 6;
                case PokerHandType.OnePair:
                    return 12;
                case PokerHandType.TwoPair:
                    return 24;
                case PokerHandType.ThreeOfAKind:
                    return 18;
                case PokerHandType.FourOfAKind:
                    return 24;
                case PokerHandType.FiveOfAKind:
                    return 30;
                case PokerHandType.FullHouse:
                    return 28;
                case PokerHandType.Flush:
                    return 15;
                case PokerHandType.StraightFlush:
                    return 20;
                case PokerHandType._1:
                    return 5;
                case PokerHandType._2:
                    return 10;
                case PokerHandType._3:
                    return 15;
                case PokerHandType._4:
                    return 20;
                case PokerHandType._5:
                    return 25;
                case PokerHandType._6:
                    return 30;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
