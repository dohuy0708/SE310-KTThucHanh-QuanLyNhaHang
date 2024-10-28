using Microsoft.AspNetCore.Mvc;

namespace ThuchanhQuanLyNhaHang.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        [Route("")]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
