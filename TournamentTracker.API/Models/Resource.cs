using Newtonsoft.Json;

namespace TournamentTracker.API.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order = -2)] //Set the property to the top of the JSON
        public string Href { get; set; } = null!;
    }
}
