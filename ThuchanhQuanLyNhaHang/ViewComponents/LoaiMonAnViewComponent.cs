using ThuchanhQuanLyNhaHang.Models;
using Microsoft.AspNetCore.Mvc;
using ThuchanhQuanLyNhaHang.Repository;
namespace ThuchanhQuanLyNhaHang.ViewComponents
{
    public class LoaiMonAnViewComponent: ViewComponent
    {
        private readonly LoaiMonAnViewComponent _component;

        public LoaiMonAnViewComponent(ILoaiMonAnRepo loaiMonAnRepo)
        {

        }
    }
}
