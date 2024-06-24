using System.Text.Json.Serialization;

namespace TurtleRoute
{
    [method: JsonConstructor]
    public class Quality(int totalScore)
    {
        [JsonPropertyName("totalScore")]
        public int TotalScore { get; } = totalScore;
    }
}