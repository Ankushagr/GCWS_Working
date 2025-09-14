using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Models.Products;

namespace GulfCoastWorkforceSolutions.Models.Brewers
{
    public class BrewerViewModel : ITypedProductViewModel
    {
        public bool IsDishwasherSafe { get; set; }


        public static BrewerViewModel GetViewModel(Brewer brewer)
        {
            return new BrewerViewModel
            {
                IsDishwasherSafe = brewer.Fields.IsDishwasherSafe
            };
        }
    }
}