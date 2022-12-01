using System;
using System.Collections.Generic;

namespace DiePoker
{
    public class Player
    {
        public string DisplayName { get; private set; }

        public PokerHands PokerHands { get; private set; }

        public byte NumberOfReRolls { get; private set; }

        public PlayerType PlayerType { get; private set; }

        protected readonly DieCollection dies;

        public Player(string displayName, PlayerType playerType, DieCollection dies)
        {
            DisplayName = displayName;
            this.dies = dies;
            PlayerType = playerType;
            PokerHands = new PokerHands();
        }

        public List<byte> Roll()
        {
            NumberOfReRolls = DieCollection.MaximumNumberOfReRolls;
            return dies.Roll();
        }

        public void Set(PokerHandResult pokerHandResult)
        {
            PokerHands.Set(pokerHandResult);
            NumberOfReRolls = 0;
        }

        public List<byte> ReRoll(params byte[] notKeepedIndexes)
        {
            if (NumberOfReRolls > 0)
            {
                NumberOfReRolls--;
                return dies.ReRoll(notKeepedIndexes);
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
