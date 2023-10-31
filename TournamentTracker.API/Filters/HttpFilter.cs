using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TournamentTracker.API.Filters
{
    public class HttpFilter : RequireHttpsAttribute
    {
        protected override void HandleNonHttpsRequest(AuthorizationFilterContext filterContext)
        {
            filterContext.Result = new StatusCodeResult(400); // Bad Request will be sent on HTTP requests to API
        }

    }
}
