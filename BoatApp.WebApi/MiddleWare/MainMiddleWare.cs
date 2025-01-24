using BoatApp.Business.Operations.Settings;

namespace BoatApp.WebApi.MiddleWare
{
    public class MainMiddleWare
    {
        private readonly RequestDelegate _next;

        public MainMiddleWare(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context)
        {
            var settingsService = context.RequestServices.GetRequiredService<ISettingsService>();
            bool maintenenceMode = settingsService.GetMaintenenceMode();

            if(context.Request.Path.StartsWithSegments("/api/auth/login") || context.Request.Path.StartsWithSegments("/api/settings"))
            {
                await _next(context);
                return;
            }

            if (maintenenceMode)
            {
                await context.Response.WriteAsync("Şuanda bakımdayız :)");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
