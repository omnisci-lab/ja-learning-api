using Japanese.Domain.Common;
using Newtonsoft.Json;

namespace Japanese.Models;

public class KanjiModel : EntityBase
{
    [JsonProperty("kanji")]
    public string? Kanji { get; set; }

    [JsonProperty("on_readings")]
    public List<string>? OnReadings { get; set; }

    [JsonProperty("kun_readings")]
    public List<string>? KunReadings { get; set; }

    [JsonProperty("name_readings")]
    public List<string>? NameReadings { get; set; }
}