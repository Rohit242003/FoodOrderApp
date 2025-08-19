using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderItemingApp.Repository
{
    public class OrderItemRepository: IOrderItemRepository
    {
        private readonly DbContextFoodApp dbContextFoodApp;
        public OrderItemRepository(DbContextFoodApp dbContextFoodApp)
        {
            this.dbContextFoodApp = dbContextFoodApp;
        }
        OrderItem IOrderItemRepository.Add(OrderItem OrderItem)
        {
           
            dbContextFoodApp.OrderItems.Add(OrderItem);
            dbContextFoodApp.SaveChanges();
            return OrderItem;

        }
        bool IOrderItemRepository.Delete(int id)
        {
            OrderItem? OrderItem = dbContextFoodApp.OrderItems.FirstOrDefault(o => o.OrderItemId == id);
            dbContextFoodApp.OrderItems.Remove(OrderItem);
            dbContextFoodApp.SaveChanges();
            if (OrderItem != null)
                return true;
            return false;

        }
        IEnumerable<OrderItem> IOrderItemRepository.GetAll()
        {
            return dbContextFoodApp.OrderItems.ToList();
        }
        OrderItem IOrderItemRepository.GetById(int id)
        {
            OrderItem? OrderItem = dbContextFoodApp.OrderItems.FirstOrDefault(o => o.OrderItemId == id);
            return OrderItem;
        }
        OrderItem IOrderItemRepository.Update(OrderItem OrderItem)
        {
            dbContextFoodApp.OrderItems.Update(OrderItem);
            dbContextFoodApp.SaveChanges();
            return OrderItem;
        }
    }

}
