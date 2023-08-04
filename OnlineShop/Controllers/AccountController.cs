using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
