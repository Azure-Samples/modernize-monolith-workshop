using Microsoft.AspNetCore.Mvc;
using eShopLite.StoreCore.Services;

namespace eShopLite.StoreCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStoreService storeService, ILogger<HomeController> logger)
        {
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home page requested");
            return View();
        }

        public async Task<IActionResult> Products()
        {
            try
            {
                _logger.LogInformation("Products page requested");
                ViewBag.Message = "This component demonstrates showing products data";

                var products = await _storeService.GetProductsAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products page");
                ViewBag.Error = "Unable to load products at this time.";
                return View(Enumerable.Empty<Models.Product>());
            }
        }

        public async Task<IActionResult> Stores()
        {
            try
            {
                _logger.LogInformation("Stores page requested");
                ViewBag.Message = "This component demonstrates showing stores data";

                var stores = await _storeService.GetStoresAsync();
                return View(stores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading stores page");
                ViewBag.Error = "Unable to load stores at this time.";
                return View(Enumerable.Empty<Models.StoreInfo>());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}