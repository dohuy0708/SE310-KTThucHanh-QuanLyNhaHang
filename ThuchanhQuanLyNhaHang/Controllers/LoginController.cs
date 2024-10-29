using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using ThuchanhQuanLyNhaHang.Models;

namespace ThuchanhQuanLyNhaHang.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        QlnhaHangContext db = new QlnhaHangContext();
        [Route("")]
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                Console.WriteLine("null");
                return View();
            }
            else
            {

                Console.WriteLine(" khong null");
                return View();
            }

        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            Console.WriteLine("truy cap");

            var u = db.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
              
                if (u != null) // Kiểm tra nếu người dùng tồn tại
                {
                    Console.WriteLine("ten khong null ", u.Username);
                    HttpContext.Session.SetString("Username", u.Username.ToString()); // Lấy Username từ đối tượng người dùng
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    Console.WriteLine("ten null");
                    // Thêm xử lý nếu người dùng không tồn tại (ví dụ: thông báo lỗi)
                }
            
            
            return View(); // Hoặc chuyển hướng đến trang đăng nhập
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("login", "Login");
        }

    }
}
