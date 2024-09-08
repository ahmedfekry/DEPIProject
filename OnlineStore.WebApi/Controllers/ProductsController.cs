using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities;
using OnlineStore.Services.Products;

namespace OnlineStore.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(ProductService productService)
        {
            ProductService = productService;
        }

        public ProductService ProductService { get; }

        [HttpGet]
        public List<Product> Get()
        {
            return ProductService.GetOldProducts();
        }
    }
}
