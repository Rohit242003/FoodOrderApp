using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public interface IMenuItemRepository
    {
        MenuItem Add(MenuItem partner);
        MenuItem Update(MenuItem partner);
        bool Delete(int id);
        IEnumerable<MenuItem> GetAll();
        MenuItem GetById(int id);
    }
}
