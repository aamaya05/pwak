using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    public class HomeADMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
