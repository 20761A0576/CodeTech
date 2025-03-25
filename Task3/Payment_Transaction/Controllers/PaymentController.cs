using Microsoft.AspNetCore.Mvc;
using Payment_Transaction.Service;

namespace Payment_Transaction.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripeService _stripeService;

        public PaymentController(StripeService stripeService)
        {
            _stripeService = stripeService ?? throw new ArgumentNullException(nameof(stripeService));
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCheckout(decimal amount, string currency)
        {
            var sessionUrl = _stripeService.CreateCheckoutSession(amount, currency);
            return Redirect(sessionUrl);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}
