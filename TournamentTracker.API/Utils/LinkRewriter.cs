using Microsoft.AspNetCore.Mvc;
using TournamentTracker.API.Models;

namespace TournamentTracker.API.Utils
{
    public class LinkRewriter
    {
        private readonly IUrlHelper _urlHelper;
        public LinkRewriter(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public Link? Rewrite(Link original)
        {
            if (original == null) return null;

            return new Link
            {
                Href = _urlHelper.Link(original.RouteName, original.RouteValues)
            };

        }
    }
}
