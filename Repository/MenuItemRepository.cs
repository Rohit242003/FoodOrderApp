using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;


namespace Day_41_FoodOrderingApp.Repository
{
    public class MenuItemRepository: IMenuItemRepository
    {
        private readonly DbContextFoodApp _contextFoodApp;
        public MenuItemRepository(DbContextFoodApp  _contextFoodApp)
        {
            this._contextFoodApp = _contextFoodApp;
         }
        MenuItem IMenuItemRepository.Add(MenuItem MenuItem)
        {

            _contextFoodApp.menuItems.Add(MenuItem);
            _contextFoodApp.SaveChanges();
            return MenuItem;

        }
        bool IMenuItemRepository.Delete(int id)
        {
            MenuItem? MenuItem = _contextFoodApp.menuItems.FirstOrDefault(o => o.MenuId == id);
            MenuItem.IsActive = false;
            _contextFoodApp.menuItems.Update(MenuItem);
            _contextFoodApp.SaveChanges();
            return true;
           
        }
        IEnumerable<MenuItem> IMenuItemRepository.GetAll()
        {
            return _contextFoodApp.menuItems.ToList();
        }
        MenuItem IMenuItemRepository.GetById(int id)
        {
            MenuItem? MenuItem = _contextFoodApp.menuItems.FirstOrDefault(o => o.MenuId == id);
            return MenuItem;
        }
        MenuItem IMenuItemRepository.Update(MenuItem MenuItem)
        {
            _contextFoodApp.menuItems.Update(MenuItem);
            _contextFoodApp.SaveChanges();
            return MenuItem;
        }
    }


}
