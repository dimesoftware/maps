using System.Text.Json.Serialization;

namespace TurtleRoute
{
    public class Quality
    {
        [JsonConstructor]
        public Quality(
            int totalScore
        )
        {
            TotalScore = totalScore;
        }

        [JsonPropertyName("totalScore")]
        public int TotalScore { get; }
    }


}