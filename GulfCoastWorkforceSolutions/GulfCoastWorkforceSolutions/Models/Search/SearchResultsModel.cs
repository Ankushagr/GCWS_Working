using X.PagedList;

namespace GulfCoastWorkforceSolutions.Models.Search
{
    public class SearchResultsModel
    {
        public string Query { get; set; }

        public IPagedList<SearchResultItemModel> Items { get; set; }
    }
}