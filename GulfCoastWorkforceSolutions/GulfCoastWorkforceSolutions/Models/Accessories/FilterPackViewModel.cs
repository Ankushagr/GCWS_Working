using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Models.Products;

namespace GulfCoastWorkforceSolutions.Models.Accessories
{
    public class FilterPackViewModel : ITypedProductViewModel
    {
        public int Quantity { get; set; }

        public static FilterPackViewModel GetViewModel(FilterPack filterPack)
        {
            return new FilterPackViewModel
            {
                Quantity = filterPack.FilterPackQuantity
            };
        }
    }
}