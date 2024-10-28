using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using ThuchanhQuanLyNhaHang.Models;
using X.PagedList;

namespace ThuchanhQuanLyNhaHang.Controllers
{
    public class HomeController : Controller
    {
        // khai báo DB 
        QlnhaHangContext db = new QlnhaHangContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home( int ? page)
        {
            int pageSize = 8;
            int pageNumber = page==null||page<0?1:page.Value;
            // lấy tất cả món ăn 
             
           var lstMonAn = db.MenuItems.AsNoTracking().OrderBy(a => a.Name).ToList();
            PagedList<MenuItem> lst = new PagedList<MenuItem>(lstMonAn, pageNumber, pageSize);
                return View(lst);
        }

    
        public IActionResult MonAnTheoLoai(int maloai)
        {
            //Lấy danh sách SubCategoryID của loại "Thức uống" dựa vào CategoryID
           var subCategories = db.SubCategories
                                 .Where(sc => sc.CategoryId == maloai) // CategoryID == maloai (Thức uống)
                                 .Select(sc => sc.SubCategoryId)
                                 .ToList();

            // Lấy danh sách món ăn thuộc loại thức uống (theo SubCategoryID)
            var listMon = db.MenuItems
                            .Where(mi => subCategories.Contains((int)mi.SubCategoryId))
                            .ToList();



            return View(listMon); // Trả về view và hiển thị danh sách món
        }


        public IActionResult chitietmonan (int Mamonan)
        {
            var monan = db.MenuItems.SingleOrDefault(x=>x.MenuItemId==Mamonan);

            return View(monan);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
