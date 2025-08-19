using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public interface IPaymentMethodRepository
    {
        PaymentMethod Add(PaymentMethod partner);
        PaymentMethod Update(PaymentMethod partner);
        bool Delete(int id);
        IEnumerable<PaymentMethod> GetAll();
        PaymentMethod GetById(int id);
    }
}
