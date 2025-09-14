using System.Web.Mvc;
using CMS.DocumentEngine.Types.GCWS;
using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Controllers.PageTemplates;
using GulfCoastWorkforceSolutions.Models.PageTemplates;

using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

[assembly: RegisterPageTemplate("GulfCoastWorkforceSolutions.News", typeof(NewsPageTemplateController), "NewsPageTemplate", Description = "News Page Template", IconClass = "icon-l-text")]

namespace GulfCoastWorkforceSolutions.Controllers.PageTemplates
{
    public class NewsPageTemplateController : PageTemplateController
    {
        private readonly IPageDataContextRetriever pageDataContextRetriver;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;


        public NewsPageTemplateController(IPageDataContextRetriever pageDataContextRetriver, IPageUrlRetriever pageUrlRetriever, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            this.pageDataContextRetriver = pageDataContextRetriver;
            this.pageUrlRetriever = pageUrlRetriever;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
        }


        public ActionResult Index()
        {
            var news = pageDataContextRetriver.Retrieve<News>().Page;
            if (news == null)
            {
                return HttpNotFound();
            }

            return View("PageTemplates/_News", NewsViewModel.GetViewModel(news, pageUrlRetriever, attachmentUrlRetriever));
        }
    }
}