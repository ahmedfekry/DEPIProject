using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities;
using OnlineStore.Services.Products;

namespace OnlineStore.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(ProductService productService)
        {
            ProductService = productService;
        }

        public ProductService ProductService { get; }

        public IActionResult Index()
        {
            List<Product> prods = ProductService.GetOldProducts();

            return View();
        }
    }
}
