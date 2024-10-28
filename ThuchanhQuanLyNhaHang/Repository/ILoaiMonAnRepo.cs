using ThuchanhQuanLyNhaHang.Models;
namespace ThuchanhQuanLyNhaHang.Repository

{
    public interface ILoaiMonAnRepo
    {
        FoodCategory Add(FoodCategory category);
        FoodCategory Update(FoodCategory category);
        FoodCategory Delete(String IDcategory);
        FoodCategory Get(String IDcategory);
        IEnumerable<FoodCategory> GetAll();
    }
}
