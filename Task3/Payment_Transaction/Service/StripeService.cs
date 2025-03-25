using Stripe;
using Stripe.Checkout;

namespace Payment_Transaction.Service
{
    public class StripeService
    {
        public string CreateCheckoutSession(decimal amount, string currency)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = currency,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Product Name"
                        },
                        UnitAmount = (long)(amount * 100) // Convert to cents
                    },
                    Quantity = 1
                }
            },
                Mode = "payment",
                SuccessUrl = "https://yourdomain.com/payment/success",
                CancelUrl = "https://yourdomain.com/payment/cancel"
            };

            var service = new SessionService();
            var session = service.Create(options);
            return session.Url;
        }
    }
}
