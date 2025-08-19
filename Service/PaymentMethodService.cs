using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }

    public IEnumerable<PaymentMethod> GetAllPaymentMethods()
    {
        return _paymentMethodRepository.GetAll();
    }

    public PaymentMethod GetPaymentMethodById(int id)
    {
        return _paymentMethodRepository.GetById(id);
    }
}