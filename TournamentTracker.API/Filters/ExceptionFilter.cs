using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TournamentTracker.API.Models;

namespace TournamentTracker.API.Filter
{


    public class ExceptionFilter : IExceptionFilter
    {

        private readonly IHostEnvironment _env;

        public ExceptionFilter(IHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();

            if (_env.IsDevelopment())
            {
                error.Message = context.Exception.Message;

                error.Details = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A server error has occured";
                error.Details = context.Exception.Message;
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };

        }
    }
}
