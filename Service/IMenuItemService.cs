using Day_41_FoodOrderingApp.Model;

public interface IMenuItemService
{
    IEnumerable<MenuItem> GetAllMenuItems();
    MenuItem GetMenuItemById(int id);
    MenuItem CreateMenuItem(MenuItem menuItem);
    MenuItem UpdateMenuItem(MenuItem menuItem);
    bool DeleteMenuItem(int id);
}