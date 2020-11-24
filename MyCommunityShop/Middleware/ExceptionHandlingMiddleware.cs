namespace MyCommunityShop.Api.Middleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using MyCommunityShop.Api.Models;
    using Newtonsoft.Json;

    //todo: re-enable once logging is in.
    #pragma warning disable CS0168
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //todo: log something here
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var error = new ErrorDto();
                var serialisedError = JsonConvert.SerializeObject(error);
                await context.Response.WriteAsync(serialisedError);
            }
        }
    }
}
