using System;

namespace DiePoker
{
    public class Die
    {
        public const byte DefaultNumberOfSides = 6;

        public byte Actual { get; private set; }

        public byte NumberOfSides { get; private set; }

        private static readonly Random random;

        static Die()
        {
            random = new Random(Environment.TickCount);
        }

        public Die(byte numberOfSides = DefaultNumberOfSides)
        {
            Actual = 1;
            NumberOfSides = numberOfSides;
        }

        public byte Roll()
        {
            Actual = (byte)(random.Next(NumberOfSides) + 1);
            return Actual;
        }
    }
}
