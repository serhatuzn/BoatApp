namespace BoatApp.WebApi.MiddleWare
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMainMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MainMiddleWare>();
        }
    }
}
