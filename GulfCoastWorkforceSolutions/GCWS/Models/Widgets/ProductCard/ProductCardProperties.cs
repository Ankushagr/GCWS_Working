using System.Collections.Generic;
using System.Linq;

using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.Widgets
{
    /// <summary>
    /// Product card widget properties.
    /// </summary>
    public class ProductCardProperties : IWidgetProperties
    {
        /// <summary>
        /// Selected product.
        /// </summary>
        [EditingComponent(PageSelector.IDENTIFIER, Label = "{$GulfCoastWorkforceSolutionsMVC.Widget.ProductCard.SelectedProduct$}", Order = 1)]
        [EditingComponentProperty(nameof(PageSelectorProperties.RootPath), ContentItemIdentifiers.STORE)]
        public IEnumerable<PageSelectorItem> SelectedProducts { get; set; } = Enumerable.Empty<PageSelectorItem>();
    }
}