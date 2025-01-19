using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BoatApp.WebApi.ActionFilter
{
    public class TimeControlFilter : ActionFilterAttribute
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var now = DateTime.UtcNow.TimeOfDay;

            StartTime = "01:00";
            EndTime = "01:59";

            if (now >= TimeSpan.Parse(StartTime) && now <= TimeSpan.Parse(EndTime))
            {
                base.OnActionExecuting(context);
                context.Result = new ContentResult
                {
                    Content = "Bu saatlerde işlem yapamazsınız"
                };
            }
            // Burada zaman kontrolü yapılacak
        }
    }

}
