
using eShopLite.StoreCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace eShopLite.StoreFx.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreService _service;

        public HomeController(IStoreService service)
        {
            _service = service ?? throw new System.ArgumentNullException(nameof(service));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "This component demonstrates showing products data";

            var products = _service.GetProducts();

            return View(products);
        }

        public ActionResult Stores()
        {
            ViewBag.Message = "This component demonstrates showing stores data";

            var stores = _service.GetStores();

            return View(stores);
        }
    }
}