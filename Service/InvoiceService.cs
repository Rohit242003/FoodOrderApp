using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceService(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public IEnumerable<Invoice> GetAllInvoices()
    {
        return _invoiceRepository.GetAll();
    }

    public Invoice GetInvoiceById(int id)
    {
        return _invoiceRepository.GetById(id);
    }

    public Invoice GetInvoiceForOrder(int orderId)
    {
        return _invoiceRepository.GetByOrderId(orderId);
    }
}