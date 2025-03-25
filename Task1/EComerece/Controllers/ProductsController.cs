using EComerece.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComerece.Controllers
{
    public class ProductsController : Controller
    {
        private EcommereceContext db = new EcommereceContext();

        // Display all products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
