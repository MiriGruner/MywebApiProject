using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using servies;
using System.Threading.Tasks;

namespace project.middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IRatingServies ratingServies)
        {
            Rating rating=new Rating();
            rating.Method=httpContext.Request.Method;
            rating.Path=httpContext.Request.Path;
            rating.Host = (httpContext.Request.Host).ToString();  
            rating.UserAgent = httpContext.Request.Headers.UserAgent;
            rating.Referer = httpContext.Request.Headers.Referer;
            rating.RecordDate = DateTime.Now;
                                                                                                                                                                
            ratingServies.post(rating);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
