using System.Web.Mvc;

using CMS.Ecommerce;
using CMS.Helpers;

using GulfCoastWorkforceSolutions.ActionSelectors;
using GulfCoastWorkforceSolutions.Models.Checkout;
using GulfCoastWorkforceSolutions.Services;

namespace GulfCoastWorkforceSolutions.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly IShoppingService shoppingService;
        private readonly ICheckoutService checkoutService;


        public CouponController(IShoppingService shoppingService, ICheckoutService checkoutService)
        {
            this.shoppingService = shoppingService;
            this.checkoutService = checkoutService;
        }


        // GET: Coupon/Show
        public ActionResult Show()
        {
            var viewModel = checkoutService.PrepareCartViewModel();

            return PartialView("_CouponCodeEdit", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ButtonNameAction]
        [ValidateInput(false)]
        public ActionResult AddCouponCode(CouponCodesUpdateModel model)
        {
            string couponCode = model.NewCouponCode?.Trim();
            if (string.IsNullOrEmpty(couponCode) || !shoppingService.AddCouponCode(couponCode))
            {
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { CouponCodeInvalidMessage = ResHelper.GetString("GulfCoastWorkforceSolutionsMvc.Checkout.CouponCodeInvalid") }
                };

            }

            return new EmptyResult();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ButtonNameAction]
        [ValidateInput(false)]
        public ActionResult RemoveCouponCode(CouponCodesUpdateModel model)
        {
            shoppingService.RemoveCouponCode(model.RemoveCouponCode);

            return new EmptyResult();
        }
    }
}