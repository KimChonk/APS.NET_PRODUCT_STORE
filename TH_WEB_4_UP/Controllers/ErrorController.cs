using Microsoft.AspNetCore.Mvc;

namespace TH_WEB_4_UP.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
} 