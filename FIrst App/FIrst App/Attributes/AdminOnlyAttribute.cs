using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FIrst_App.Enums;

namespace FIrst_App.Attributes
{
    public class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetInt32("UserRole");

            if (role != (int)Roles.Admin)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Home", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}