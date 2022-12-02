namespace DicePoker
{
    public static class DiceCollectionFactory
    {
        public static DiceCollection CreateDicePoker()
        {
            var result = new DiceCollection();
            for (byte i = 0; i < 5; i++)
            {
                result.AddDice();
            }
            return result;
        }
    }
}
