using System.Collections.Generic;
using System.Linq;

namespace DicePoker.ArtificialIntelligence
{
    public class AI_V2 : ArtificialIntelligenceBase
    {
        /// <summary>
        /// Choose the best point value
        /// </summary>
        /// <param name="rollResult">Result of last roll</param>
        /// <param name="probabilities">Not set poker hand types</param>
        /// <returns>Choose the best point value roll</returns>
        public override PokerHandType GetBestFit(List<byte> rollResult, IEnumerable<KeyValuePair<PokerHandType, double>> probabilities)
        {
            PokerHandType result = probabilities.First().Key;
            var resultProbability = 0.0;
            foreach (var probability in probabilities)
            {
                var maxPoints = GetMaxResult(rollResult, probability.Key);
                var points = GetResult(rollResult, probability.Key);
                if (points > 0)
                {
                    var currentProbability = (double)points / maxPoints;
                    if (currentProbability > resultProbability)
                    {
                        resultProbability = currentProbability;
                        result = probability.Key;
                    }
                }
            }
            return result;
        }
    }
}
