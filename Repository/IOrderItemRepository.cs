using Day_41_FoodOrderingApp.Model;
namespace Day_41_FoodOrderItemingApp.Repository
{
    public interface IOrderItemRepository
    {
            OrderItem Add(OrderItem OrderItem);
            OrderItem Update(OrderItem OrderItem);

            bool Delete(int id);
            IEnumerable<OrderItem> GetAll();
            OrderItem GetById(int id);
        }
    

}
