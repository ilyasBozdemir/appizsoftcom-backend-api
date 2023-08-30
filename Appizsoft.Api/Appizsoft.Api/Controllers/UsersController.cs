using Microsoft.AspNetCore.Mvc;

namespace Appizsoft.Api.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
