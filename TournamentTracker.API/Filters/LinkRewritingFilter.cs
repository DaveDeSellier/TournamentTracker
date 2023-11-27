using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;
using TournamentTracker.API.Models;
using TournamentTracker.API.Utils;

namespace TournamentTracker.API.Filters
{
    public class LinkRewritingFilter : IAsyncResultFilter
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        public LinkRewritingFilter(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var asObjectResult = context.Result as ObjectResult;

            bool shouldSkip = asObjectResult?.StatusCode >= 400
                || asObjectResult?.Value == null
                || asObjectResult?.Value as Resource == null;

            if (shouldSkip)
            {
                return next();
            }

            var rewriter = new LinkRewriter(_urlHelperFactory.GetUrlHelper(context));
            RewriteAllLinks(asObjectResult?.Value, rewriter);

            return next();

        }

        private static void RewriteAllLinks(object? model, LinkRewriter rewriter)
        {
            if (model == null)
            {
                return;
            }

            var allProperties = model.GetType()
                .GetTypeInfo().GetProperties()
                .Where(p => p.CanRead)
                .ToArray();

            var linkProperties = allProperties.Where(p => p.CanWrite && p.PropertyType == typeof(Link));

            foreach (var linkProperty in linkProperties)
            {
                var rewritten = rewriter.Rewrite(linkProperty.GetValue(model) as Link);
                if (rewritten == null) continue;

                linkProperty.SetValue(model, rewritten);

                //Special handling of the hidden Self property
                //Unwrap into the root object

                if (linkProperty.Name == nameof(Resource.Self))
                {
                    allProperties.SingleOrDefault(p => p.Name == nameof(Resource.Href))
                        ?.SetValue(model, rewritten.Href);
                }
            }

            var arrayProperties = allProperties.Where(p => p.PropertyType.IsInterface);
            RewriteLinksInArray(arrayProperties, model, rewriter);

            var objectProperties = allProperties
                .Except(linkProperties)
                .Except(arrayProperties);

            //RewriteLinksInNestedObjects(objectProperties, model, rewriter);

        }


        private static void RewriteLinksInArray(IEnumerable<PropertyInfo> arrayProperties, object model, LinkRewriter rewriter)
        {
            foreach (var arrayProperty in arrayProperties)
            {

                var objs = arrayProperty.GetValue(model) as IEnumerable<object>;

                foreach (var element in objs)
                {
                    RewriteAllLinks(element, rewriter);
                }
            }
        }

        //private static void RewriteLinksInNestedObjects(IEnumerable<PropertyInfo> objectProperties, object model, LinkRewriter rewriter)
        //{

        //    foreach (var objectProperty in objectProperties)
        //    {

        //        RewriteAllLinks(objectProperty, rewriter);

        //    }
        //}
    }
}
