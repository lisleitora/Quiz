using System.Text.Json.Serialization;
using static PhpRunnerService.Converters.JsonCustomConverters;

namespace quiz.DTOPhpRunner
{
    public class Game
    {
     
        [JsonConverter(typeof(IntConverter))]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonConverter(typeof(FileConverter))]
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }
}
