using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class FoodPackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
