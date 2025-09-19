using System.Linq;
using System.Web.Mvc;

using GulfCoastWorkforceSolutions.Controllers.Widgets;
using GulfCoastWorkforceSolutions.Infrastructure;
using GulfCoastWorkforceSolutions.Models.Widgets;
using GulfCoastWorkforceSolutions.Repositories;

using Kentico.PageBuilder.Web.Mvc;

[assembly: RegisterWidget(ProductCardWidgetController.IDENTIFIER, typeof(ProductCardWidgetController), "{$GulfCoastWorkforceSolutionsmvc.widget.productcard.name$}", Description = "{$GulfCoastWorkforceSolutionsmvc.widget.productcard.description$}", IconClass = "icon-box")]

namespace GulfCoastWorkforceSolutions.Controllers.Widgets
{
    /// <summary>
    /// Controller for product card widget.
    /// </summary>
    public class ProductCardWidgetController : WidgetController<ProductCardProperties>
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "GulfCoastWorkforceSolutions.LandingPage.ProductCardWidget";


        private readonly IProductRepository repository;
        private readonly IOutputCacheDependencies outputCacheDependencies;
        private readonly IComponentPropertiesRetriever componentPropertiesRetriever;


        /// <summary>
        /// Creates an instance of <see cref="ProductCardWidgetController"/> class.
        /// </summary>
        /// <param name="repository">Repository for retrieving products.</param>
        /// <param name="outputCacheDependencies">Output cache dependency handling.</param>
        public ProductCardWidgetController(IProductRepository repository,
            IOutputCacheDependencies outputCacheDependencies,
            IComponentPropertiesRetriever componentPropertiesRetriever)
        {
            this.repository = repository;
            this.outputCacheDependencies = outputCacheDependencies;
            this.componentPropertiesRetriever = componentPropertiesRetriever;
        }


        public ActionResult Index()
        {
            var selectedPage = componentPropertiesRetriever.Retrieve<ProductCardProperties>().SelectedProducts.FirstOrDefault();

            var product = (selectedPage != null) ? repository.GetProduct(selectedPage.NodeGuid) : null;

            outputCacheDependencies.AddDependencyOnPage(product);

            return PartialView("Widgets/_ProductCardWidget", ProductCardViewModel.GetViewModel(product));
        }
    }
}