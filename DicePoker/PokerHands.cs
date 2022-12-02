using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
    public class PokerHands
    {
		public ushort Points { get; private set; }

        public byte HighCard { get; set; }

        public byte OnePair { get; set; }

        public Tuple<byte, byte> TwoPair { get; set; }

        public byte ThreeOfAKind { get; set; }

        public byte FourOfAKind { get; set; }

        public byte FiveOfAKind { get; set; }

        public Tuple<byte, byte> FullHouse { get; set; }

        public Tuple<byte, byte> Flush { get; set; }

        public Tuple<byte, byte> StraightFlush { get; set; }

        public byte Ones { get; set; }

        public byte Twos { get; set; }

        public byte Threes { get; set; }

        public byte Fours { get; set; }

        public byte Fives { get; set; }

        public byte Sixes { get; set; }

        public readonly List<PokerHandType> SetPokerHands = new List<PokerHandType>();

        public PokerHands()
        {
            TwoPair = new Tuple<byte, byte>(0, 0);
            FullHouse = new Tuple<byte, byte>(0, 0);
            Flush = new Tuple<byte, byte>(0, 0);
            StraightFlush = new Tuple<byte, byte>(0, 0);
        }

        public List<PokerHandType> GetNotSetPokerHandTypes()
        {
            var values = Enum.GetValues(typeof(PokerHandType)).Cast<PokerHandType>();
            return values.Where(pht => !SetPokerHands.Contains(pht)).ToList();
        }

        public void Set(PokerHandResult pokerHandResult)
        {
            SetPokerHands.Add(pokerHandResult.PokerHandType);

            switch (pokerHandResult.PokerHandType)
            {
                case PokerHandType.HighCard:
                    HighCard = pokerHandResult.Values.GetHighCard();
                    break;
                case PokerHandType.OnePair:
                    OnePair = pokerHandResult.Values.GetOnePair();
                    break;
                case PokerHandType.TwoPair:
                    TwoPair = pokerHandResult.Values.GetTwoPair();
                    break;
                case PokerHandType.ThreeOfAKind:
                    ThreeOfAKind = pokerHandResult.Values.GetThreeOfAKind();
                    break;
                case PokerHandType.FourOfAKind:
                    FourOfAKind = pokerHandResult.Values.GetFourOfAKind();
                    break;
                case PokerHandType.FiveOfAKind:
                    FiveOfAKind = pokerHandResult.Values.GetFiveOfAKind();
                    break;
                case PokerHandType.FullHouse:
                    FullHouse = pokerHandResult.Values.GetFullHouse();
                    break;
                case PokerHandType.Flush:
                    Flush = pokerHandResult.Values.GetFlush();
                    break;
                case PokerHandType.StraightFlush:
                    StraightFlush = pokerHandResult.Values.GetStraightFlush();
                    break;
                case PokerHandType._1:
                    Ones = pokerHandResult.Values.GetOnes();
                    break;
                case PokerHandType._2:
                    Twos = pokerHandResult.Values.GetTwos();
                    break;
                case PokerHandType._3:
                    Threes = pokerHandResult.Values.GetThrees();
                    break;
                case PokerHandType._4:
                    Fours = pokerHandResult.Values.GetFours();
                    break;
                case PokerHandType._5:
                    Fives = pokerHandResult.Values.GetFives();
                    break;
                case PokerHandType._6:
                    Sixes = pokerHandResult.Values.GetSixes();
                    break;
            }

            Points = Summarize();
        }
		
		private ushort Summarize()
		{
			var sum = 0;
			
			sum += HighCard;
			sum += OnePair * 2;
			sum += TwoPair.Item1 * 2 + TwoPair.Item2 * 2;
			sum += ThreeOfAKind * 3;			
			sum += FourOfAKind * 4;
			sum += FiveOfAKind * 5;			
			sum += FullHouse.Item1 * 3 + FullHouse.Item2 * 2;
            sum += Ones;
            sum += Twos;
            sum += Threes;
            sum += Fours;
            sum += Fives;
            sum += Sixes;

            for (byte i = Flush.Item2; i < Flush.Item1; i++)
			{
				sum += i;
			}
			for (byte i = StraightFlush.Item2; i < StraightFlush.Item1; i++)
			{
				sum += i;
			}
			
			return (ushort)sum;
		}
    }
}
