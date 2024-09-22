using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Entities.Models.Auction;
using OnlineStore.Services;

namespace OnlineStore.WebApp.Controllers
{
    public class AuctionController : Controller
    {
        public AuctionController(IItemService itemService,ICategoryService categoryService)
        {
            ItemService = itemService;
            CategoryService = categoryService;
        }

        public IItemService ItemService { get; }
        public ICategoryService CategoryService { get; }

        public async Task<IActionResult> Index(int? categoryid = null)
        {
            var items = new List<Item>();

            if (categoryid == null)
            {
                items = (await ItemService.GetAllItemsAysnc()).ToList();
                ViewBag.Category = null;
            }
            else
            {
                //items = (await ItemService.GetItemsByCategoryAysnc(categoryid.Value)).ToList();
                var category =  await CategoryService.GetCategoryDetailsAsync(categoryid.Value);
                items = category.Items.ToList() ;
                ViewBag.Category = category; 
                    
            }


            return View(items);
        }
    }
}
