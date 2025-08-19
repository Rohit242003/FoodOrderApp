using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll();
        Invoice GetById(int id);
        Invoice GetByOrderId(int orderId);
    }
}
