using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day_41_FoodOrderingApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateNewOrderAsync(Order order)
        {
            
            if (order.OrderAmount >= 500)
            {
                
                DiscountConfig.amount = order.OrderAmount;
                order.FinalAmount = DiscountConfig.calculateDiscount();
            }
            else
            {
                order.FinalAmount = order.OrderAmount;
            }
           
            return await _orderRepository.AddAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            
            return await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
           
            return await _orderRepository.UpdateAsync(order);
        }
    }
}