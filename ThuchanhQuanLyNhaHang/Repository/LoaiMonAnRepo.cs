using ThuchanhQuanLyNhaHang.Models;
namespace ThuchanhQuanLyNhaHang.Repository
{
    public class LoaiMonAnRepo : ILoaiMonAnRepo
    {
        private readonly QlnhaHangContext _context;
        public LoaiMonAnRepo (QlnhaHangContext context)
        {
            _context = context; 
        }
        public FoodCategory Add(FoodCategory category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public FoodCategory Delete(string IDcategory)
        {
            throw new NotImplementedException();
        }

        public FoodCategory Get(string IDcategory)
        {
            return _context.FoodCategories.Find(IDcategory);
        }

        public IEnumerable<FoodCategory> GetAll()
        {
           return _context.FoodCategories;
        }

        public FoodCategory Update(FoodCategory category)
        {
           _context.Update(category);
            _context.SaveChanges ();
            return category;
        }
    }
}
