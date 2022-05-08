using System.Text.Json.Serialization;
using static PhpRunnerService.Converters.JsonCustomConverters;

namespace quiz.DTOPhpRunner
{
    public class Ask_result
    {
        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("ask_id")]
        public int AskId { get; set; }

        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("result_id")]
        public int ResultId { get; set; }

        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("game_id")]
        public int GameId { get; set; }
    }
}
