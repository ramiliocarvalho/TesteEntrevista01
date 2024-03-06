using Microsoft.AspNetCore.Mvc;
using WebAppTesteEntrevista01.Filters;

namespace WebAppTesteEntrevista01.Controllers
{
    [PageUserLoged]
    public class RestrictedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
