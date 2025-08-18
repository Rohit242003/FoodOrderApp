using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public MenuItem CreateMenuItem(MenuItem menuItem)
    {
        return _menuItemRepository.Add(menuItem);
    }

    public bool DeleteMenuItem(int id)
    {
        return _menuItemRepository.Delete(id);
    }

    public IEnumerable<MenuItem> GetAllMenuItems()
    {
        return _menuItemRepository.GetAll();
    }

    public MenuItem GetMenuItemById(int id)
    {
        return _menuItemRepository.GetById(id);
    }

    public MenuItem UpdateMenuItem(MenuItem menuItem)
    {
        return _menuItemRepository.Update(menuItem);
    }
}