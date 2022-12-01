using DiePoker.ArtificialIntelligence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiePoker
{
    public class ComputerPlayer : Player
    {
        ArtificialIntelligenceBase artificialIntelligence;

        public ComputerPlayer(string name, DieCollection die)
            : base(name, PlayerType.Computer, die)
        {
            artificialIntelligence = new AI_V2();
        }

        public double CalculateProbability(PokerHandType type, List<Die> dies)
        {
            var rollProbability = 1 / dies.First().NumberOfSides;
            var probability = rollProbability * dies.Count * 3;
            switch (type)
            {
                case PokerHandType.HighCard:
                    return probability;
                case PokerHandType.OnePair:
                    return Math.Pow(probability, 2);
                case PokerHandType.ThreeOfAKind:
                case PokerHandType.Flush:
                    return Math.Pow(probability, 3);
                case PokerHandType.TwoPair:
                case PokerHandType.FourOfAKind:
                    return Math.Pow(probability, 4);
                case PokerHandType.FiveOfAKind:
                case PokerHandType.FullHouse:
                case PokerHandType.StraightFlush:
                    return Math.Pow(probability, 5);
                case PokerHandType._1:
                case PokerHandType._2:
                case PokerHandType._3:
                case PokerHandType._4:
                case PokerHandType._5:
                case PokerHandType._6:
                    return Math.Pow(probability, 5);
            }
            return 0;
        }

        public IOrderedEnumerable<KeyValuePair<PokerHandType, double>> GetOrderedNotSetPokerHandTypes()
        {
            var notSetPokerHandTypes = GetNotSetPokerHandTypes();
            return notSetPokerHandTypes.Select(notSetPokerHandType =>
            {
                var probability = CalculateProbability(notSetPokerHandType, dies.Dies);
                return new KeyValuePair<PokerHandType, double>(notSetPokerHandType, probability);
            }).OrderByDescending(pokerHandType => pokerHandType.Value);
        }

        public PokerHandResult UseArtificialIntelligence()
        {
            var firstRoll = Roll();
            var notKeededIndexes = ExamineRolls(firstRoll);

            var secondRoll = ReRoll(notKeededIndexes);
            notKeededIndexes = ExamineRolls(firstRoll, secondRoll);

            var thirdRoll = ReRoll(notKeededIndexes);
            notKeededIndexes = ExamineRolls(firstRoll, secondRoll, thirdRoll);
            
            var pokerHandType = GetBestFit(thirdRoll);

            var pokerHandResult = new PokerHandResult
            {
                PokerHandType = pokerHandType,
                Values = thirdRoll
            };
            PokerHands.Set(pokerHandResult);
            return pokerHandResult;
        }

        private PokerHandType GetBestFit(List<byte> rollResult)
        {
            var fits = new List<PokerHandResult>();
            var probabilities = GetOrderedNotSetPokerHandTypes().Reverse();
            return artificialIntelligence.GetBestFit(rollResult, probabilities);
        }

        private byte[] ExamineRolls(params List<byte>[] rolls)
        {
            var actualRoll = rolls.Last();
            var pokerHandToTry = GetBestFit(actualRoll);
            return GetReRollIndexes(actualRoll, pokerHandToTry);
        }

        private byte[] GetReRollIndexes(List<byte> actualRoll, PokerHandType pokerHandToTry)
        {
            var result = new List<byte>();
            var keptNumbers = new List<byte>();

            switch (pokerHandToTry)
            {
                case PokerHandType.HighCard:
                    keptNumbers.Add(actualRoll.GetHighCard());
                    break;
                case PokerHandType.OnePair:
                    keptNumbers.Add(actualRoll.GetOnePair());
                    break;
                case PokerHandType.TwoPair:
                    var twoPair = actualRoll.GetTwoPair();
                    keptNumbers.Add(twoPair.Item1);
                    if (!keptNumbers.Contains(twoPair.Item2))
                    {
                        keptNumbers.Add(twoPair.Item2);
                    }
                    break;
                case PokerHandType.ThreeOfAKind:
                    keptNumbers.Add(actualRoll.GetThreeOfAKind());
                    break;
                case PokerHandType.FourOfAKind:
                    keptNumbers.Add(actualRoll.GetFourOfAKind());
                    break;
                case PokerHandType.FiveOfAKind:
                    keptNumbers.Add(actualRoll.GetFiveOfAKind());
                    break;
                case PokerHandType.FullHouse:
                    var fullHouse = actualRoll.GetFullHouse();
                    keptNumbers.Add(fullHouse.Item1);
                    keptNumbers.Add(fullHouse.Item2);
                    break;
                case PokerHandType.Flush:
                    var flush = actualRoll.GetFlush();
                    for (byte i = flush.Item1; i < flush.Item2; i++)
                    {
                        keptNumbers.Add(i);
                    }
                    break;
                case PokerHandType.StraightFlush:
                    var straightFlush = actualRoll.GetStraightFlush();
                    for (byte i = straightFlush.Item1; i < straightFlush.Item2; i++)
                    {
                        keptNumbers.Add(i);
                    }
                    break;
                case PokerHandType._1:
                    keptNumbers.Add(1);
                    break;
                case PokerHandType._2:
                    keptNumbers.Add(2);
                    break;
                case PokerHandType._3:
                    keptNumbers.Add(3);
                    break;
                case PokerHandType._4:
                    keptNumbers.Add(4);
                    break;
                case PokerHandType._5:
                    keptNumbers.Add(5);
                    break;
                case PokerHandType._6:
                    keptNumbers.Add(6);
                    break;
            }
            for (byte i = 0; i < actualRoll.Count; i++)
            {
                if (!keptNumbers.Contains(actualRoll[i]))
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }
    }
}
