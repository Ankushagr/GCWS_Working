using CMS.Core;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Internal;
using CMS.DocumentEngine.Routing;
using CMS.DocumentEngine.Types.GCWS;
using GCWS.Controllers;
using GCWS.Infrastructure;
using GCWS.Models;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using org.pdfclown.documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterPageRoute(NewsSection.CLASS_NAME, typeof(NewsController))]
[assembly: RegisterPageRoute(News.CLASS_NAME, typeof(NewsController), ActionName = "Show")]
namespace GCWS.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPageDataContextRetriever dataContextRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;
        private readonly IPageRetriever pageRetriever;
        //  private readonly IOutputCacheDependencies outputCacheDependencies;

        public NewsController()
        {
            // Initializes instances of required services
            // NOTE: This method of instantiating services is not recommended for
            // real-world projects and is only used for the sake of brevity in this tutorial.
            // Instead, we recommend configuring a dependency injection container to resolve
            // object dependencies (e.g., Autofac). See the Xperience documentation for details.
            pageRetriever = Service.Resolve<IPageRetriever>();
            pageUrlRetriever = Service.Resolve<IPageUrlRetriever>();
            attachmentUrlRetriever = Service.Resolve<IPageAttachmentUrlRetriever>();
            dataContextRetriever = Service.Resolve<IPageDataContextRetriever>();
            // this.outputCacheDependencies = outputCacheDependencies;

        }

        
        // GET: News
        // [OutputCache(CacheProfile = "Default")]
        public ActionResult Index()
        {
            var section = dataContextRetriever.Retrieve<TreeNode>().Page;
            var news = pageRetriever.Retrieve<News>(
                query =>
                {
                    query
                    .Path(ContentItemIdentifiers.NEWS, PathTypeEnum.Children)
                    .OrderByDescending("DocumentPublishFrom");

                    //// Apply category filter if possible
                    //if (categories != null && categories.Any())
                    //{
                    //    query.InCategories(categories.ToArray());
                    //}
                },
            cache => cache
                .Key($"{nameof(NewsController)}|{nameof(Index)}")
                .Dependencies((_, builder) =>
                    builder.PagePath(ContentItemIdentifiers.NEWS, PathTypeEnum.Children))
        );
            //cache => cache
            //    .Key($"{nameof(KenticoArticleRepository)}|{nameof(GetArticles)}|{nodeAliasPath}|{count}")
            //    // Include path dependency to flush cache when a new child page is created.
            //    .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children)));

            return View(news.Select(article => NewsViewModel.GetViewModel(article, pageUrlRetriever, attachmentUrlRetriever)));
        }

        //  [OutputCache(CacheProfile = "Default")]
        public ActionResult Show()
        {
            var page = dataContextRetriever.Retrieve<News>().Page;

            var newsitem = pageRetriever.Retrieve<News>(
                query => query
                    .WhereEquals("NodeID", page.NodeID)).FirstOrDefault();
           // NewsViewModel.GetViewModel(news, pageUrlRetriever, attachmentUrlRetriever)

            //outputCacheDependencies.AddDependencyOnPage(newsitem);

            //return new TemplateResult(newsitem);
            return View("PageTemplates/_news", NewsViewModel.GetViewModel(newsitem, pageUrlRetriever, attachmentUrlRetriever));
        }
    }
}