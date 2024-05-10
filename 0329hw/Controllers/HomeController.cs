using _0329hw.Models;
using _0329hw.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _0329hw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _products;
        public HomeController(ProductService products)
        {
            _products = products;
        }
        public IActionResult Index()
        {
            return View(_products.GetProducts());
        }
        public IActionResult Edit(int productId)
        {
            var currentProduct=_products.GetProduct(productId);
            if (currentProduct != null)
            {
                ViewBag.Categories = new string[] { "Meat", "Dairy", "Sweets" };
                return View(currentProduct);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _products.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }
    }
}
