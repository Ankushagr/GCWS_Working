using System.Web.Mvc;

using Kentico.Forms.Web.Mvc;

using GulfCoastWorkforceSolutions.Controllers.FormSections;

[assembly: RegisterFormSection(TwoColumnFormSectionController.IDENTIFIER, typeof(TwoColumnFormSectionController), "{$GulfCoastWorkforceSolutionsmvc.formsection.twocolumn.name$}", Description = "{$GulfCoastWorkforceSolutionsmvc.formsection.twocolumn.description$}", IconClass = "icon-l-cols-2")]

namespace GulfCoastWorkforceSolutions.Controllers.FormSections
{
    [FormSectionExceptionFilter]
    public class TwoColumnFormSectionController : Controller
    {
        public const string IDENTIFIER = "GulfCoastWorkforceSolutions.TwoColumnSection";


        // GET: TwoColumnSection
        public ActionResult Index()
        {
            return PartialView("FormSections/_TwoColumnSection");
        }
    }
}