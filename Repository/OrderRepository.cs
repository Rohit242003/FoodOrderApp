using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Repository;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly DbContextFoodApp _dbContext;

    public OrderRepository(DbContextFoodApp dbContext)
    {
        _dbContext = dbContext;
    }
    

    public async Task<Order> AddAsync(Order order)
    {
        _dbContext.Orders.Add(order);
        // The SaveChangesAsync override will create the invoice automatically
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _dbContext.Orders.FindAsync(id);

        // 1. Check for null BEFORE trying to remove
        if (order == null)
        {
            return false;
        }

        _dbContext.Orders.Remove(order);
        // 2. Call SaveChangesAsync to commit the deletion
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _dbContext.Orders.FindAsync(id);
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }
}