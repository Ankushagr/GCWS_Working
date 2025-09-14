using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

using CMS.Base;
using CMS.Base.Internal;
using CMS.Membership;
using CMS.Search;
using CMS.WebAnalytics;

using GulfCoastWorkforceSolutions.Infrastructure;
using GulfCoastWorkforceSolutions.Models.Search;

using X.PagedList;

namespace GulfCoastWorkforceSolutions.Controllers
{
    public class SearchController : Controller
    {
        private const string INDEX_NAME = "GulfCoastWorkforceSolutionsMvc.Index";
        private const int PAGE_SIZE = 5;
        private const int DEFAULT_PAGE_NUMBER = 1;

        private readonly TypedSearchItemViewModelFactory searchItemViewModelFactory;
        private readonly IPagesActivityLogger pagesActivityLogger;
        private readonly IAnalyticsLogger analyticsLogger;
        private readonly ISiteService siteService;
        private readonly IHttpContextRetriever retriever;


        public SearchController(TypedSearchItemViewModelFactory searchItemViewModelFactory, IPagesActivityLogger pagesActivityLogger, 
            IAnalyticsLogger analyticsLogger, ISiteService siteService, IHttpContextRetriever retriever)
        {
            this.searchItemViewModelFactory = searchItemViewModelFactory;
            this.pagesActivityLogger = pagesActivityLogger;
            this.analyticsLogger = analyticsLogger;
            this.siteService = siteService;
            this.retriever = retriever;
        }


        // GET: Search
        [ValidateInput(false)]
        public ActionResult Index(string searchText, int page = DEFAULT_PAGE_NUMBER)
        {
            if (String.IsNullOrWhiteSpace(searchText))
            {
                var empty = new SearchResultsModel
                {
                    Items = new StaticPagedList<SearchResultItemModel>(Enumerable.Empty<SearchResultItemModel>(), page, PAGE_SIZE, 0)
                };
                return View(empty);
            }

            // Validate page number (starting from 1)
            page = Math.Max(page, DEFAULT_PAGE_NUMBER);

            var searchParameters = SearchParameters.PrepareForPages(searchText, new[] { INDEX_NAME }, page, PAGE_SIZE, MembershipContext.AuthenticatedUser);
            var searchResults = SearchHelper.Search(searchParameters);

            pagesActivityLogger.LogInternalSearch(searchText);

            var siteId = siteService.CurrentSite.SiteID;
            var culture = Thread.CurrentThread.CurrentCulture.Name;
            var uri = retriever.GetContext().Request.Url;
            var hostAddress = retriever.GetContext().Request.UserHostAddress;

            analyticsLogger.LogInternalSearchKeywords(new AnalyticsData(siteId, searchText, culture: culture, uri: uri, hostAddress: hostAddress));

            var searchResultItemModels = searchResults.Items
                .Select(searchResultItem => searchItemViewModelFactory.GetTypedSearchResultItemModel(searchResultItem));

            var model = new SearchResultsModel
            {
                Items = new StaticPagedList<SearchResultItemModel>(searchResultItemModels, page, PAGE_SIZE, searchResults.TotalNumberOfResults),
                Query = searchText
            };

            return View(model);
        }
    }
}