using System.Linq;

using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;
using CMS.Helpers;
using CMS.Search;

using GulfCoastWorkforceSolutions.Repositories;

using Kentico.Content.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.Search
{
    public class SearchResultAboutUsItemModel : SearchResultPageItemModel
    {
        public SearchResultAboutUsItemModel(SearchResultItem resultItem, AboutUs aboutUs, IAboutUsRepository aboutUsRepository, IPageUrlRetriever pageUrlRetriever)
            : base(resultItem, aboutUs, pageUrlRetriever)
        {
            var sideStories = aboutUsRepository.GetSideStories(aboutUs.NodeAliasPath);
            Content = string.Join(" ", sideStories.Select(story => HTMLHelper.StripTags(story.AboutUsSectionText, false)));
        }
    }
}