using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using ThuchanhQuanLyNhaHang.Models;
using ThuchanhQuanLyNhaHang.Models.Authentication;

namespace ThuchanhQuanLyNhaHang.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]
  
    public class HomeAdminController : Controller
    {
        QlnhaHangContext db = new QlnhaHangContext();
        [Route("")]
        [Route("index")]
      
        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucmonan")]
        public IActionResult Danhmucmonan()
        {
            var lismonan = db.MenuItems.ToList();
            return View(lismonan);
        }

        [Route("Themmonan")]
        [HttpGet]
        public IActionResult Themmonan()
        {
             ViewBag.SubCategoryId = new SelectList(db.SubCategories.ToList(), "SubCategoryId", "SubCategoryName");
            return View();
        }
        [Route("Themmonan")]
        [HttpPost]
        public IActionResult Themmonan(MenuItem monan)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(monan);
                db.SaveChanges();
                return RedirectToAction("Danhmucmonan");
            }

            // Nếu ModelState không hợp lệ, bạn có thể lặp qua các lỗi và lưu chúng vào ViewBag để hiển thị trên view
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage); // Hiển thị lỗi trong console
            }

            // Trả về view cùng với mô hình để hiển thị lại thông tin
            return View(monan);
        }

        [Route("Suamonan/{MenuItemID}")]
        [HttpGet]
        public IActionResult Suamonan(int MenuItemID )
        {

            ViewBag.SubCategoryId = new SelectList(db.SubCategories.ToList(), "SubCategoryId", "SubCategoryName");
           
            var monan = db.MenuItems.Find(MenuItemID);
            if (monan == null)
            {
                Console.WriteLine(MenuItemID);
                // Bạn có thể trả về một view lỗi hoặc điều hướng đến trang khác
                Console.WriteLine("null"); // trả về lỗi 404
            }
            return View(monan);

        }

        [Route("Suamonan")]
        [HttpPost]
        public IActionResult Suamonan(MenuItem monan)
        {
            if (ModelState.IsValid)
            {
               db.Update(monan);
                db.SaveChanges();
                return RedirectToAction("Danhmucmonan");


            }

            return View(monan);
        }

        [Route("Xoamonan/{MenuItemID}")]
        [HttpGet]
        public IActionResult Xoamonan(int MenuItemID)
        {
            var monan = db.MenuItems.Find(MenuItemID);
            if(monan!= null)
            {
                db.Remove(monan);
                db.SaveChanges();
            }

            return RedirectToAction("Danhmucmonan");
        }
    }
}
