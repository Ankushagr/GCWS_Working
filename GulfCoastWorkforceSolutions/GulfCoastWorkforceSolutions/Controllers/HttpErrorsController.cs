using System.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Controllers
{
    public class HttpErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;

            return View();
        }
    }
}