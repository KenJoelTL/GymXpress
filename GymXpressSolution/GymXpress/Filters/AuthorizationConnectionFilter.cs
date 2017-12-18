using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Filters {
    public class AuthorizationConnectionFilter : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            /*filterContext.HttpContext.Trace.Write("(Logging Filter)Action Executing: " +
                filterContext.ActionDescriptor.ActionName);*/
            string connecte = "connecte";
            if (filterContext.HttpContext.Session[connecte] == null) {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Compte" }, { "action", "Login" } });
            }/*
            else {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Compte" }, { "action", "Login" } });
            }*/

            base.OnActionExecuting(filterContext);
        }

    }
}