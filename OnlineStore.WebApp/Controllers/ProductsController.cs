using Microsoft.AspNetCore.Mvc;
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

    }
}
