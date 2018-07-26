using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Amf.Documentation.Developpement.API
{
    public class TempsAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actionDuration = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Stop();

            // // add time to viewbag if viewresult
            // ViewResult result = context.Result as ViewResult;
            // if (result != null)
            // {
            //     result.ViewData["actionDuration"] = actionDuration;
            // }

            context.HttpContext.Response.Headers.Add("Temps", actionDuration.ToString());
        }

    }
}