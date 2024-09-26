using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Entities.Models.Auction;
using OnlineStore.Entities.Models.Authentication;
using OnlineStore.Services;
using System.Security.Claims;

namespace OnlineStore.WebApp.Controllers
{
    public class AuctionController : Controller
    {
        public AuctionController(IItemService itemService,
                                 ICategoryService categoryService,
                                 BidService bidService,
                                 UserManager<User> userManager
                                 )
        {
            ItemService = itemService;
            CategoryService = categoryService;
            BidService = bidService;
            UserManager = userManager;
        }

        public IItemService ItemService { get; }
        public ICategoryService CategoryService { get; }
        public BidService BidService { get; }
        public UserManager<User> UserManager { get; }

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
                var category =  await CategoryService.GetCategoryDetailsAsync(categoryid.Value);
                items = category.Items.ToList() ;
                ViewBag.Category = category; 
                    
            }


            return View(items);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var item = await ItemService.GetItemDetails(id);

            if (item == null)
            {
                return NotFound();
            }

            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }

            return View(item);
        }

        public async Task<IActionResult> SubmitBid(int ItemId, decimal Amount)
        {

            var user = await UserManager.GetUserAsync(User); //FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await BidService.AddAsync(user.Id, Amount, ItemId);

            TempData["Message"] = "You Placed Bid successfuly";

            return RedirectToAction("Details", new { id = ItemId });
        }
    }
}
