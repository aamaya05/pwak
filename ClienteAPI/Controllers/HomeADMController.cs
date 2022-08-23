using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    public class HomeADMController : Controller
    {
        public IActionResult Index()
        {

            string accessToken = HttpContext.Session.GetString("JWTToken");

            ServiceRepository serviceObj = new ServiceRepository(accessToken);
            return View();
        }
    }
}
