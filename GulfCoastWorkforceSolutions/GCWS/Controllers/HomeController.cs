using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

using GCWS.Controllers;

using CMS.Core;
using CMS.DocumentEngine;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using CMS.DocumentEngine.Types.GCWS;
using GCWS.Infrastructure;
using System.Threading;
using GCWS.Repositories;

//[assembly: RegisterPageRoute("NewSite.Home", typeof(HomeController))]

namespace GCWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly IHomeRepository homeSectionRepository;

        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IOutputCacheDependencies outputCacheDependencies;


        public HomeController(IPageDataContextRetriever pageDataContextRetriever,
            IHomeRepository homeSectionRepository,
          //  IReferenceRepository referenceRepository,
            IOutputCacheDependencies outputCacheDependencies,
            IPageUrlRetriever pageUrlRetriever,
            IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.homeSectionRepository = homeSectionRepository;

            this.pageUrlRetriever = pageUrlRetriever;
            this.outputCacheDependencies = outputCacheDependencies;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
        }


        //[OutputCache(CacheProfile = "PageBuilder")]
        public ActionResult Index(CancellationToken cancellationToken)
        {
            var home = pageDataContextRetriever.Retrieve<Home>().Page;

            return View();
        }
    }
}