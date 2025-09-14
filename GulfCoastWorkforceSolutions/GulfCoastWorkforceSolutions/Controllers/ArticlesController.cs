using System.Linq;
using System.Web.Mvc;

using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

using GulfCoastWorkforceSolutions.Controllers;
using GulfCoastWorkforceSolutions.Infrastructure;
using GulfCoastWorkforceSolutions.Repositories;

[assembly: RegisterPageRoute(ArticleSection.CLASS_NAME, typeof(ArticlesController))]
[assembly: RegisterPageRoute(Article.CLASS_NAME, typeof(ArticlesController), ActionName = "Show")]

namespace GulfCoastWorkforceSolutions.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IPageDataContextRetriever dataContextRetriever;
        private readonly IArticleRepository articleRepository;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IOutputCacheDependencies outputCacheDependencies;


        public ArticlesController(IPageDataContextRetriever dataContextRetriever,
            IArticleRepository articleRepository,
            IPageUrlRetriever pageUrlRetriever,
            IPageAttachmentUrlRetriever attachmentUrlRetriever,
            IOutputCacheDependencies outputCacheDependencies)
        {
            this.dataContextRetriever = dataContextRetriever;
            this.articleRepository = articleRepository;
            this.pageUrlRetriever = pageUrlRetriever;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
            this.outputCacheDependencies = outputCacheDependencies;
        }



        // GET: Articles
        [OutputCache(CacheProfile = "Default")]
        public ActionResult Index()
        {
            var section = dataContextRetriever.Retrieve<TreeNode>().Page;
            var articles = articleRepository.GetArticles(section.NodeAliasPath);

            outputCacheDependencies.AddDependencyOnPages(articles);

            return View(articles.Select(article => ArticleViewModel.GetViewModel(article, pageUrlRetriever, attachmentUrlRetriever)));
        }


        [OutputCache(CacheProfile = "Default")]
        public ActionResult Show()
        {
            var article = articleRepository.GetCurrent();

            outputCacheDependencies.AddDependencyOnPage(article);

            return new TemplateResult(article);
        }
    }
}