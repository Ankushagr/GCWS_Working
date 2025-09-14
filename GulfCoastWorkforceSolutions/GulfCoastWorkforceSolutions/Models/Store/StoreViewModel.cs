using System.Collections.Generic;

using GulfCoastWorkforceSolutions.Models.Manufacturers;
using GulfCoastWorkforceSolutions.Models.Products;

namespace GulfCoastWorkforceSolutions.Models.Store
{
    public class StoreViewModel
    {
        public IEnumerable<ProductListItemViewModel> FeaturedProducts { get; set; }

        public IEnumerable<ProductListItemViewModel> HotTipProducts { get; set; }

        public IEnumerable<ManufactureListItemViewModel> Manufacturers { get; set; }
    }
}