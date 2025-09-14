using System.Web.Mvc;

using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Controllers.PageTemplates;
using GulfCoastWorkforceSolutions.Models.PageTemplates;

using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

[assembly: RegisterPageTemplate("GulfCoastWorkforceSolutions.Article", typeof(ArticlePageTemplateController), "{$GulfCoastWorkforceSolutionsmvc.pagetemplate.article.name$}", Description = "{$GulfCoastWorkforceSolutionsmvc.pagetemplate.article.description$}", IconClass = "icon-l-text")]

namespace GulfCoastWorkforceSolutions.Controllers.PageTemplates
{
    public class ArticlePageTemplateController : PageTemplateController
    {
        private readonly IPageDataContextRetriever pageDataContextRetriver;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;


        public ArticlePageTemplateController(IPageDataContextRetriever pageDataContextRetriver, IPageUrlRetriever pageUrlRetriever, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            this.pageDataContextRetriver = pageDataContextRetriver;
            this.pageUrlRetriever = pageUrlRetriever;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
        }


        public ActionResult Index()
        {
            var article = pageDataContextRetriver.Retrieve<Article>().Page;
            if (article == null)
            {
                return HttpNotFound();
            }

            return View("PageTemplates/_Article", ArticleViewModel.GetViewModel(article, pageUrlRetriever, attachmentUrlRetriever));
        }
    }
}