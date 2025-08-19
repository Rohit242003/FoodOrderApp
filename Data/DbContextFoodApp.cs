
using Day_41_FoodOrderingApp.Model;
using Microsoft.EntityFrameworkCore;
namespace Day_41_FoodOrderingApp.Data
{
    public class DbContextFoodApp: DbContext
    {
        public DbContextFoodApp() { }
        public DbContextFoodApp (DbContextOptions dbContextOptions): base(dbContextOptions) { }
        public DbSet<DeliveryPartner> DeliveryPartners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> menuItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<User> Users { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Get all the new Order entries that are about to be saved
        var newOrderEntries = ChangeTracker.Entries<Order>()
            .Where(e => e.State == EntityState.Added)
            .ToList();

        // For each new order, create an invoice
        foreach (var orderEntry in newOrderEntries)
        {
            var invoice = new Invoice
            {
                Order = orderEntry.Entity // Link the invoice to the new order
            };
            Invoices.Add(invoice);
        }

        // Call the base SaveChangesAsync to save the orders AND the new invoices
        return await base.SaveChangesAsync(cancellationToken);
    }
    }
}
