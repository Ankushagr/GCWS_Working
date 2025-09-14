using System.ComponentModel.DataAnnotations;

namespace GulfCoastWorkforceSolutions.Models.Checkout
{
    public class CouponCodesUpdateModel
    {
        [MaxLength(200, ErrorMessage = "GulfCoastWorkforceSolutionsMvc.General.MaximumInputLengthExceeded")]
        public string NewCouponCode { get; set; }


        public string RemoveCouponCode { get; set; }
    }
}