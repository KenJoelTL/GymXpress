using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Filters {
    public class AutorisationEntraineurFilter : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {

            string role = "role";
            if (filterContext.HttpContext.Session[role] != null && (int)filterContext.HttpContext.Session[role] < Models.Compte.ENTRAINEUR) {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
            }

            base.OnActionExecuting(filterContext);
        }

    }
}