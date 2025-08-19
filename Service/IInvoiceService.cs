using Day_41_FoodOrderingApp.Model;

public interface IInvoiceService
{
    IEnumerable<Invoice> GetAllInvoices();
    Invoice GetInvoiceById(int id);
    Invoice GetInvoiceForOrder(int orderId);
}