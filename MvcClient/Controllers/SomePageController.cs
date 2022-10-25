using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    public class SomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
