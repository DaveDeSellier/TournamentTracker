using Newtonsoft.Json;
using NSwag.Annotations;

namespace TournamentTracker.API.Models
{
    //Use for Hateoas
    public abstract class Resource : Link
    {
        [OpenApiIgnore]
        [JsonIgnore]
        public Link Self { get; set; } = default!;
    }
}
