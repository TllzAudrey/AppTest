using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppTest.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Content("Administrator");
        }
    }
}