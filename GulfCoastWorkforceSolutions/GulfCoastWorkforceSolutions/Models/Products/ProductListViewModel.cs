using System.Collections.Generic;

using GulfCoastWorkforceSolutions.Repositories.Filters;

namespace GulfCoastWorkforceSolutions.Models.Products
{
    public class ProductListViewModel
    {
        public IRepositoryFilter Filter { get; set; }

        public IEnumerable<ProductListItemViewModel> Items { get; set; }
    }
}