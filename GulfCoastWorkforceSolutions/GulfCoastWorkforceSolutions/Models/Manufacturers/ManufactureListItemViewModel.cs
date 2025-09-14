using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using Kentico.Content.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.Manufacturers
{
    public class ManufactureListItemViewModel
    {
        public string Url { get; }


        public string Name { get; }


        public string ImagePath { get; }


        public ManufactureListItemViewModel(Manufacturer manufacturer, IPageUrlRetriever pageUrlRetriever)
        {
            Name = manufacturer.DocumentName;
            ImagePath = string.IsNullOrEmpty(manufacturer.Logo) ? null : new FileUrl(manufacturer.Logo, true).RelativePath;
            Url = pageUrlRetriever.Retrieve(manufacturer).RelativePath;
        }
    }
}