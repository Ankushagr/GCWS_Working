using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GulfCoastWorkforceSolutions.Models.Checkout
{
    [Bind(Exclude = "Countries")]
    public class CountryStateViewModel
    {
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Address.CountryIsRequired")]
        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Address.Country")]
        public int CountryID { get; set; }


        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Address.State")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Address.StateIsRequired")]
        public int? StateID { get; set; }


        public SelectList Countries { get; set; }
    }
}