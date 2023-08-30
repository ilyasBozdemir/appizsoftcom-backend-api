using Microsoft.AspNetCore.Mvc;

namespace Appizsoft.Api.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
