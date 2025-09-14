using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using CMS.DocumentEngine.Types.GCWS;
using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Controllers;
using GulfCoastWorkforceSolutions.Infrastructure;
using GulfCoastWorkforceSolutions.Models.Home;
using GulfCoastWorkforceSolutions.Models.References;
using GulfCoastWorkforceSolutions.Repositories;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;

[assembly: RegisterPageRoute(Home.CLASS_NAME, typeof(HomeController))]

namespace GulfCoastWorkforceSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly IHomeRepository homeSectionRepository;
        private readonly IReferenceRepository referenceRepository;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IOutputCacheDependencies outputCacheDependencies;


        public HomeController(IPageDataContextRetriever pageDataContextRetriever,
            IHomeRepository homeSectionRepository,
            IReferenceRepository referenceRepository,
            IOutputCacheDependencies outputCacheDependencies, 
            IPageUrlRetriever pageUrlRetriever,
            IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.homeSectionRepository = homeSectionRepository;
            this.referenceRepository = referenceRepository;
            this.pageUrlRetriever = pageUrlRetriever;
            this.outputCacheDependencies = outputCacheDependencies;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
        }


        //[OutputCache(CacheProfile = "PageBuilder")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var home = pageDataContextRetriever.Retrieve<Home>().Page;            

            return View();
        }
    }
}
