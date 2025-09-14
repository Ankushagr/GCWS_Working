using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using CMS.Ecommerce;

namespace GulfCoastWorkforceSolutions.Models.Checkout
{
    [Bind(Exclude = "PaymentMethods")]
    public class PaymentMethodViewModel
    {
        [Required(ErrorMessage = "GulfCoastWorkforceSolutionsMvc.Payment.PaymentMethodRequired")]
        [Display(Name = "GulfCoastWorkforceSolutionsMvc.Payment.SelectPayment")]
        public int PaymentMethodID { get; set; }


        public SelectList PaymentMethods { get; set; }


        public PaymentMethodViewModel()
        {
        }


        public PaymentMethodViewModel(PaymentOptionInfo paymentMethod, SelectList paymentMethods)
        {
            PaymentMethods = paymentMethods;

            if (paymentMethod != null)
            {
                PaymentMethodID = paymentMethod.PaymentOptionID;
            }
        }
    }
}