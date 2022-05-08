using System.Text.Json.Serialization;
using static PhpRunnerService.Converters.JsonCustomConverters;

namespace quiz.DTOPhpRunner
{
    public class Result
    {
        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("definitions")]
        public string Definitions { get; set; }

        [JsonConverter(typeof(FileConverter))]
        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("game_id")]
        public int GameId { get; set; }
    }
}
