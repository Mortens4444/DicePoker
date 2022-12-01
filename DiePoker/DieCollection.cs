using System.Collections.Generic;
using System.Linq;

namespace DiePoker
{
    public class DieCollection
    {
        public List<Die> Dies { get; private set; }

        private readonly List<List<byte>> rolls;

        public const byte MaximumNumberOfReRolls = 2;

        public DieCollection()
        {
            Dies = new List<Die>();
            rolls = new List<List<byte>>();
        }

        public void AddDie(byte sidesOfDie = Die.DefaultNumberOfSides)
        {
            var die = new Die(sidesOfDie);
            Dies.Add(die);
        }

        public List<byte> Roll()
        {
            var result = new List<byte>();
            foreach (var die in Dies)
            {
                result.Add(die.Roll());
            }
            rolls.Add(result);
            return result;
        }

        public List<byte> ReRoll(params byte[] notKeepedIndexes)
        {
            var previousRollResult = rolls.Last();
            for (byte i = 0; i < notKeepedIndexes.Length; i++)
            {
                var index = notKeepedIndexes[i];
                previousRollResult[index] = Dies[index].Roll();
            }
            return previousRollResult;
        }
    }
}
