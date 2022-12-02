using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
    public static class ByteEnumerableExtension
    {
        public static byte GetHighCard(this IEnumerable<byte> values)
        {
            return values.Max();
        }

        public static byte GetOnePair(this IEnumerable<byte> values)
        {
			return GetReturnValue(values, g => g.Count() > 1);
        }
		
        public static Tuple<byte, byte> GetTwoPair(this IEnumerable<byte> values)
        {
            byte? item1 = null, item2 = null;
            var groups = GetGroups(values);
            foreach (IGrouping<byte, byte> group in groups)
            {
                if (group.Count() > 1)
                {
                    if (item1 == null)
                    {
                        item1 = group.Key;
                    }
                    else
                    {
                        item2 = group.Key;
                    }
                }
            }
            if (item2 == null)
            {
                item2 = 0;
                if (item1 == null)
                {
                    item1 = 0;
                }
            }
            return new Tuple<byte, byte>(item1.Value, item2.Value);
        }

        public static byte GetThreeOfAKind(this IEnumerable<byte> values)
        {
			return GetReturnValue(values, g => g.Count() > 2);
        }

        public static byte GetFourOfAKind(this IEnumerable<byte> values)
        {
            return GetReturnValue(values, g => g.Count() > 3);
        }

        public static byte GetFiveOfAKind(this IEnumerable<byte> values)
        {
            var first = values.First();
            if (values.All(v => v == first))
            {
                return first;
            }
            return 0;
        }

        public static Tuple<byte, byte> GetFullHouse(this IEnumerable<byte> values)
        {
			var groups = GetGroups(values).ToList();
			if (groups.Count == 2)
			{
				var threeTimes = groups.FirstOrDefault(group => group.Count() == 3);
				if (threeTimes != null)
				{
					var twoTimes = groups.FirstOrDefault(group => group.Count() == 2);
					return new Tuple<byte, byte>(threeTimes.Key, twoTimes.Key);
				}
			}
            return new Tuple<byte, byte>(0, 0);
        }

        public static Tuple<byte, byte> GetFlush(this IEnumerable<byte> values)
        {
			var groups = GetGroups(values).Where(g => g.Count() == 1);
			if (groups.Count() > 2)
			{
				byte start, end = 0;
				var first = groups.First().Key;
				start = first;
				for (byte i = 1; i < groups.Count(); i++)
				{
                    var value = groups.ElementAt(i).Key;
                    if (value != first - 1)
					{
						start = value;
					}
					else
					{
						first--;
						end = value;
					}
				}
				if (start - end == 2)
				{					
					return new Tuple<byte, byte>(start, end);
				}
			}
            return new Tuple<byte, byte>(0, 0);
		}

        public static Tuple<byte, byte> GetStraightFlush(this IEnumerable<byte> values)
        {
			var groups = GetGroups(values);
			if (groups.All(g => g.Count() == 1))
			{
				var first = groups.First().Key;
				for (byte i = 1; i < groups.Count(); i++)
				{
					if (groups.ElementAt(i).Key != first - 1)
					{
						break;
					}
					else
					{
						first--;
					}
				}
				return new Tuple<byte, byte>(groups.First().Key, groups.Last().Key);
			}
            return new Tuple<byte, byte>(0, 0);
        }

        public static byte GetOnes(this IEnumerable<byte> values)
        {
            return GetSumOfNumber(values, 1);
        }

        public static byte GetTwos(this IEnumerable<byte> values)
        {
            return GetSumOfNumber(values, 2);
        }

        public static byte GetThrees(this IEnumerable<byte> values)
        {
            return GetSumOfNumber(values, 3);
        }

        public static byte GetFours(this IEnumerable<byte> values)
        {
            return GetSumOfNumber(values, 4);
        }

        public static byte GetFives(this IEnumerable<byte> values)
        {
            return GetSumOfNumber(values, 5);
        }

        public static byte GetSixes(this IEnumerable<byte> values)
        {
            return GetSumOfNumber(values, 6);
        }

        public static byte GetSumOfNumber(this IEnumerable<byte> values, byte number)
        {
            return (byte)(values.Where(x => x == number).Count() * number);
        }

        private static byte GetReturnValue(IEnumerable<byte> values, Func<IGrouping<byte, byte>, Boolean> condition)
		{
            var groups = GetGroups(values);
            var group = groups.FirstOrDefault(condition);
			if (group != null)
            {
				return group.Key;
            }
            return 0;
		}

        private static IEnumerable<IGrouping<byte, byte>> GetGroups(IEnumerable<byte> values)
        {
            return values.GroupBy(value => value).OrderByDescending(value => value.Key);
        }
    }
}
