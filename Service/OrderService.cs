using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_41_FoodOrderingApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryPartnerRepository _partnerRepository;
        private readonly IMenuItemRepository _menuItemRepository; 

        
        public OrderService(IOrderRepository orderRepository,
                            IDeliveryPartnerRepository partnerRepository,
                            IMenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _partnerRepository = partnerRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Order> CreateNewOrderAsync(Order order)
        {
            double calculatedAmount = 0;

            foreach (var item in order.OrderItems)
            {
               
                var menuItem = _menuItemRepository.GetById(item.MenuItemId);

                if (menuItem != null)
                {
                    
                    calculatedAmount += (double)(menuItem.MenuPrice * item.Quantity);
                }
                else
                {
                    throw new InvalidOperationException($"MenuItem with ID {item.MenuItemId} not found.");
                }
            }

            order.OrderAmount = calculatedAmount;

            
            var allPartners = (_partnerRepository.GetAll()).ToList();

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