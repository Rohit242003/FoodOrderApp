using Day_41_FoodOrderingApp.Model;

public interface IPaymentMethodService
{
    IEnumerable<PaymentMethod> GetAllPaymentMethods();
    PaymentMethod GetPaymentMethodById(int id);
}