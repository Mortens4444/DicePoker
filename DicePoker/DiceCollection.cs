using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
    public class DiceCollection : List<Die>
    {
        private readonly List<List<byte>> rolls;

        public const byte MaximumNumberOfReRolls = 2;

        public DiceCollection()
        {
            rolls = new List<List<byte>>();
        }

        public void AddDice(byte sidesOfDie = Die.DefaultNumberOfSides)
        {
            Add(new Die(sidesOfDie));
        }

        public List<byte> Roll()
        {
            var result = this.Select(die => die.Roll()).ToList();
            rolls.Add(result);
            return result;
        }

        public List<byte> ReRoll(params byte[] notKeptIndexes)
        {
            var previousRollResult = rolls.Last();
            for (byte i = 0; i < notKeptIndexes.Length; i++)
            {
                var index = notKeptIndexes[i];
                previousRollResult[index] = this[index].Roll();
            }
            return previousRollResult;
        }
    }
}
