using System;
using System.Web.Mvc;

using CMS.Core;

namespace GulfCoastWorkforceSolutions.Controllers
{
    /// <summary>
    /// Redirects a request to "/admin" to the administration site specified in <c>GulfCoastWorkforceSolutionsAdminUrl</c> app setting.
    /// </summary>
    public class AdminRedirectController : Controller
    {
        private static string mAdminUrl;


        private static string AdminUrl
        {
            get
            {
                return mAdminUrl ?? (mAdminUrl = Service.Resolve<IAppSettingsService>()["GulfCoastWorkforceSolutionsAdminUrl"] ?? string.Empty);
            }
        }


        // GET: Admin redirect
        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty(AdminUrl))
            {
                return RedirectPermanent(AdminUrl);
            }

            return HttpNotFound();
        }
    }
}