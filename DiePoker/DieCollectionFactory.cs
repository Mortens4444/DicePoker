namespace DiePoker
{
    public static class DieCollectionFactory
    {
        public static DieCollection CreateDiePoker()
        {
            var result = new DieCollection();
            for (byte i = 0; i < 5; i++)
            {
                result.AddDie();
            }
            return result;
        }
    }
}
