using System.Linq;
using System.Web.Mvc;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.Content.Web.Mvc;

using GulfCoastWorkforceSolutions.Controllers.Widgets;
using GulfCoastWorkforceSolutions.Models.Widgets;
using GulfCoastWorkforceSolutions.Repositories;
using GulfCoastWorkforceSolutions.Infrastructure;

[assembly: RegisterWidget(CafeCardWidgetController.IDENTIFIER, typeof(CafeCardWidgetController), "{$GulfCoastWorkforceSolutionsmvc.widget.cafecard.name$}", Description = "{$GulfCoastWorkforceSolutionsmvc.widget.cafecard.description$}", IconClass = "icon-cup")]

namespace GulfCoastWorkforceSolutions.Controllers.Widgets
{
    /// <summary>
    /// Controller for cafe card widget.
    /// </summary>
    public class CafeCardWidgetController : WidgetController<CafeCardProperties>
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "GulfCoastWorkforceSolutions.HomePage.CafeCardWidget";


        private readonly ICafeRepository repository;
        private readonly IOutputCacheDependencies outputCacheDependencies;
        private readonly IComponentPropertiesRetriever componentPropertiesRetriever;
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;


        /// <summary>
        /// Initializes an instance of <see cref="CafeCardWidgetController"/> class.
        /// </summary>
        /// <param name="repository">Repository for retrieving cafes.</param>
        /// <param name="outputCacheDependencies">Output cache dependency handling.</param>
        public CafeCardWidgetController(ICafeRepository repository, 
            IOutputCacheDependencies outputCacheDependencies, 
            IComponentPropertiesRetriever componentPropertiesRetriever, 
            IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            this.repository = repository;
            this.outputCacheDependencies = outputCacheDependencies;
            this.componentPropertiesRetriever = componentPropertiesRetriever;
            this.attachmentUrlRetriever = attachmentUrlRetriever;
        }


        public ActionResult Index()
        {
            var selectedPage = componentPropertiesRetriever.Retrieve<CafeCardProperties>().SelectedCafes.FirstOrDefault();
            var cafe = (selectedPage != null) ? repository.GetCafeByGuid(selectedPage.NodeGuid) : null;

            outputCacheDependencies.AddDependencyOnPage(cafe);

            return PartialView("Widgets/_CafeCardWidget", CafeCardViewModel.GetViewModel(cafe, attachmentUrlRetriever));
        }
    }
}