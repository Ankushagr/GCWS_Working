using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Models.Products;

namespace GulfCoastWorkforceSolutions.Models.Grinders
{
    public class ElectricGrinderViewModel : ITypedProductViewModel
    {
        public int Power { get; set; }


        public static ElectricGrinderViewModel GetViewModel(ElectricGrinder grinder)
        {
            return new ElectricGrinderViewModel
            {
                Power = grinder.ElectricGrinderPower
            };
        }
    }
}