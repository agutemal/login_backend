using Microsoft.AspNetCore.Mvc;

namespace login_backend.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
