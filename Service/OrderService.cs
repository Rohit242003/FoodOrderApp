using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day_41_FoodOrderingApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryPartnerRepository _partnerRepository;

        public OrderService(IOrderRepository orderRepository, IDeliveryPartnerRepository partnerRepository)
        {
            _orderRepository = orderRepository;
            _partnerRepository = partnerRepository;
        }

        public async Task<Order> CreateNewOrderAsync(Order order)
        {
           
            var allPartners = _partnerRepository.GetAll().ToList();

            if (!allPartners.Any())
            {
                throw new InvalidOperationException("No delivery partners are available to assign to the order.");
            }

           
            var random = new Random();
            int randomIndex = random.Next(0, allPartners.Count);
            var assignedPartner = allPartners.ElementAt(randomIndex);

            
            order.DeliveryPartnerId = assignedPartner.DeliveryPartnerID;

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
