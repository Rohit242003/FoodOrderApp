using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public class PaymentMethodRepository: IPaymentMethodRepository
    {
        private readonly DbContextFoodApp _contextFoodApp;
        public PaymentMethodRepository(DbContextFoodApp dbContextFoodApp) 
        { 
            _contextFoodApp = dbContextFoodApp;
        }
        PaymentMethod IPaymentMethodRepository.Add(PaymentMethod partner)
        {
            _contextFoodApp.PaymentMethods.Add(partner);
            _contextFoodApp.SaveChanges();
            return partner;
        }
        bool IPaymentMethodRepository.Delete(int id)
        {
           PaymentMethod? paymentMethod = _contextFoodApp.PaymentMethods.FirstOrDefault(p=> p.PaymentMethodId == id);
            _contextFoodApp.PaymentMethods.Remove(paymentMethod);
           return paymentMethod != null;
        }
        IEnumerable<PaymentMethod> IPaymentMethodRepository.GetAll()
        {
            return _contextFoodApp.PaymentMethods.ToList();
        }
        PaymentMethod IPaymentMethodRepository.GetById(int id)
        {
            PaymentMethod? paymentMethod = _contextFoodApp.PaymentMethods.FirstOrDefault(p => p.PaymentMethodId == id);
            return paymentMethod ;
        }
        PaymentMethod IPaymentMethodRepository.Update(PaymentMethod partner)
        {
            _contextFoodApp.PaymentMethods.Update(partner);
            _contextFoodApp.SaveChanges(true);
            return partner;
        }
    }
}
