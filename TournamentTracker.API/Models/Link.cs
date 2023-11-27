using Newtonsoft.Json;

namespace TournamentTracker.API.Models
{
    public class Link
    {
        [JsonProperty(Order = -2)] //Put at the top of the response
        public string? Href { get; set; }

        public static Link To(string routeName, object? routeValues = null) => new Link
        {
            RouteName = routeName,
            RouteValues = routeValues
        };

        //Stores the route parameters before rewritten by LinkRewritingFilter
        [JsonIgnore]
        public string RouteName { get; set; } = default!;
        //Stores the route parameters before being rewritten by the LinkRewritingFilter

        [JsonIgnore]
        public object? RouteValues { get; set; }
    }
}
