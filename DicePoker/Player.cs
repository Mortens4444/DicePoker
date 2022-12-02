using System;
using System.Collections.Generic;

namespace DicePoker
{
    public class Player
    {
        public string DisplayName { get; private set; }

        public PokerHands PokerHands { get; private set; }

        public byte NumberOfReRolls { get; private set; }

        public PlayerType PlayerType { get; private set; }

        protected readonly DiceCollection dice;

        public Player(string displayName, PlayerType playerType, DiceCollection dice)
        {
            DisplayName = displayName;
            this.dice = dice;
            PlayerType = playerType;
            PokerHands = new PokerHands();
        }

        public List<byte> Roll()
        {
            NumberOfReRolls = DiceCollection.MaximumNumberOfReRolls;
            return dice.Roll();
        }

        public void Set(PokerHandResult pokerHandResult)
        {
            PokerHands.Set(pokerHandResult);
            NumberOfReRolls = 0;
        }

        public List<byte> ReRoll(params byte[] notKeptIndexes)
        {
            if (NumberOfReRolls > 0)
            {
                NumberOfReRolls--;
                return dice.ReRoll(notKeptIndexes);
            }

            throw new InvalidOperationException("Not allowed to re-roll.");
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public IList<PokerHandType> GetNotSetPokerHandTypes()
        {
            return PokerHands.GetNotSetPokerHandTypes();
        }
    }
}
