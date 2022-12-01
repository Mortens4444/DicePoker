using System.Collections.Generic;
using System.Linq;

namespace DiePoker.ArtificialIntelligence
{
    public class AI_V1 : ArtificialIntelligenceBase
    {
        /// <summary>
        /// Choose always the hardest one, do not examine the value rolled out
        /// </summary>
        /// <param name="rollResult">Result of last roll</param>
        /// <param name="probabilities">Not set poker hand types</param>
        /// <returns>The hardest one to roll out</returns>
        public override PokerHandType GetBestFit(List<byte> rollResult, IEnumerable<KeyValuePair<PokerHandType, double>> probabilities)
        {
            foreach (var probability in probabilities)
            {
                if (IsContains(rollResult, probability.Key))
                {
                    return probability.Key;
                }
            }
            return probabilities.First().Key;
        }
    }
}
