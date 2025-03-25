using System.Collections.Generic;
using System.Linq;
using EComerece.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EComerece.Controllers
{
    public class CartController : Controller
    {
        private readonly EcommereceContext _db;

        public CartController(EcommereceContext db)
        {
            _db = db;
        }

        // Get Cart from Session
        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetString("Cart");
            return cart == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);
        }

        // Save Cart to Session
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }

        // Display Cart
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = cart == null ? new List<CartItem>() : System.Text.Json.JsonSerializer.Deserialize<List<CartItem>>(cart);
            return View(cartItems);
        }

        // Add Item to Cart
        public IActionResult AddToCart(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return NotFound();

            var cart = GetCart();
            var existingItem = cart.FirstOrDefault(c => c.ProductId == id);

            if (existingItem != null)
                existingItem.Quantity++;
            else
                cart.Add(new CartItem { ProductId = id, Product = product, Quantity = 1 });

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        // Remove Item from Cart
        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
                cart.Remove(item);

            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}
