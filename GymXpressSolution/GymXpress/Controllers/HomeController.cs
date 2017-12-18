using GymXpress.Filters;
using System.Web.Mvc;

namespace GymXpress.Controllers {
    [HandleError, AuthorizationConnectionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            
        }
    }
}
