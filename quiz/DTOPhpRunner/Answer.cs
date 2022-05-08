using System.Text.Json.Serialization;
using static PhpRunnerService.Converters.JsonCustomConverters;

namespace quiz.DTOPhpRunner
{
    public class Answer
    {
        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }

        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("game_id")]
        public int GameId { get; set; }
    }
}
