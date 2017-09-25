using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrWhiteSpace(Cookie.Get("BudgShopTicket")))
            {
                filterContext.Result = new RedirectResult(Url.Action("Login", "Usuario"));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}