using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Web.Filters
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var http = filterContext.HttpContext;
            var key = http.Request.Cookies.Get("AuthCode");
            if (string.IsNullOrEmpty(key.Value) || key.Value.ToUpper() != ConfigurationManager.AppSettings["AuthCode"].ToUpper())
            {
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                        { "controller","Account"},
                        { "action","login"}
                    });
            }
        }
    }
}