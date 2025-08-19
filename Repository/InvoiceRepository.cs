using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Day_41_FoodOrderingApp.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbContextFoodApp _context;

        public InvoiceRepository(DbContextFoodApp context)
        {
            _context = context;
        }

        public IEnumerable<Invoice> GetAll()
        {
            // Eagerly load related Order data for all invoices
            return _context.Invoices.Include(i => i.Order).ToList();
        }

        public Invoice GetById(int id)
        {
            return _context.Invoices
                .Include(i => i.Order) 
                .FirstOrDefault(i => i.InvoiceId == id);
        }

        public Invoice GetByOrderId(int orderId)
        {
            
            return _context.Invoices
                .Include(i => i.Order)
                .FirstOrDefault(i => i.Order.OrderId == orderId);
        }
    }
}