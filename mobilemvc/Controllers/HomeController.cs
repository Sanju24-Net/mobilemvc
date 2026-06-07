using Microsoft.AspNetCore.Mvc;
using mobilemvc.Models;
using mobilemvc.Services;
using System.Diagnostics;

namespace mobilemvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }


        public IActionResult Index()
        {
            var products = context.Products.ToList();

            // TOTAL PRODUCTS
            ViewBag.TotalProducts = products.Count;

            // TOTAL REVENUE
            ViewBag.TotalRevenue = products.Sum(p => p.Price);

            // NEW PRODUCTS (last 7 days)
            var newProducts = products
                .Where(p => p.CreatedAt >= DateTime.Now.AddDays(-7))
                .ToList();

            ViewBag.NewProductsCount = newProducts.Count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NewProducts()
        {
            var products = context.Products
                .Where(p => p.CreatedAt >= DateTime.Now.AddDays(-1))
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(products);
        }

    }
}
