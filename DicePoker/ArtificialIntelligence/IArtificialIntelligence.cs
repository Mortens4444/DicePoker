using System.Collections.Generic;

namespace DicePoker.ArtificialIntelligence
{
    public interface IArtificialIntelligence
    {
        PokerHandType GetBestFit(List<byte> rollResult, IEnumerable<KeyValuePair<PokerHandType, double>> probabilities);
    }
}
