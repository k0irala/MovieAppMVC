using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIrst_App.Attributes.SessionCheckAttribute;
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //var hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
        //    .OfType<AllowAnonymousAttribute>().Any();
        var controller = context.RouteData.Values["controller"]?.ToString();
        var action = context.RouteData.Values["action"]?.ToString();

        if (controller == "Login" && action == "Index")
        {
            base.OnActionExecuting(context);
            return;
        }
        var session = context.HttpContext.Session;
        var userId = session.GetInt32("userId");

        // If userId not found in session, redirect to Login page
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Login", null);
        }
        base.OnActionExecuting(context);
    }
}