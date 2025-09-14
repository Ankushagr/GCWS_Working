using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.GCWS;
using GulfCoastWorkforceSolutions.Controllers;
using GulfCoastWorkforceSolutions.Infrastructure;
using GulfCoastWorkforceSolutions.Models.News;
using GulfCoastWorkforceSolutions.Repositories;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterPageRoute(NewsSection.CLASS_NAME, typeof(NewsController))]
[assembly: RegisterPageRoute(News.CLASS_NAME, typeof(NewsController), ActionName = "Show")]

namespace GulfCoastWorkforceSolutions.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPageDataContextRetriever dataContextRetriever;
        private readonly IArticleRepository articleRepository;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IOutputCacheDependencies outputCacheDependencies;
		private readonly IPageRetriever pageRetriever;


		public NewsController(IPageDataContextRetriever dataContextRetriever,
            IArticleRepository articleRepository,
            IPageUrlRetriever pageUrlRetriever,
            IPageAttachmentUrlRetriever attachmentUrlRetriever,
            IOutputCacheDependencies outputCacheDependencies,
			IPageRetriever pageRetriever)
        {
            this.dataContextRetriever = dataContextRetriever;
            this.articleRepository = articleRepository;
            this.pageUrlRetriever = pageUrlRetriever;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
            this.outputCacheDependencies = outputCacheDependencies;
            this.pageRetriever = pageRetriever;
		}



        // GET: Articles
        //[OutputCache(CacheProfile = "Default")]
        public ActionResult Index()
        {
            var section = dataContextRetriever.Retrieve<TreeNode>().Page;
           var news= pageRetriever.Retrieve<News>(
               query => query
                   .Path(section.NodeAliasPath, PathTypeEnum.Children)
                   .OrderByDescending("DocumentPublishFrom").ToList());
			//var articles = articleRepository.GetArticles(section.NodeAliasPath);

			outputCacheDependencies.AddDependencyOnPages(news);

            return View(news.Select(x => NewsViewModel.GetViewModel(x, pageUrlRetriever, attachmentUrlRetriever)));
        }


        //[OutputCache(CacheProfile = "Default")]
        public ActionResult Show()
        {
            var news = GetCurrent();

            outputCacheDependencies.AddDependencyOnPage(news);

            return new TemplateResult(news);
        }
		public News GetCurrent()
		{
			var page = dataContextRetriever.Retrieve<News>().Page;
			return pageRetriever.Retrieve<News>(
				query => query
					.WhereEquals("NodeID", page.NodeID))				
				.First();
		}
	}
}