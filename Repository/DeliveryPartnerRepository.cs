using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public class DeliveryPartnerRepository: IDeliveryPartnerRepository
    {
        private readonly DbContextFoodApp dbContextFoodApp;
        public DeliveryPartnerRepository(DbContextFoodApp dbContextFoodApp) 
        {
            this.dbContextFoodApp = dbContextFoodApp;
        
        }
        DeliveryPartner IDeliveryPartnerRepository.Add(DeliveryPartner partner)
        {
            dbContextFoodApp.DeliveryPartners.Add(partner);
            dbContextFoodApp.SaveChanges();
            return partner;
        }
        bool IDeliveryPartnerRepository.Delete(int id)
        {
            DeliveryPartner? deliveryPartner=  dbContextFoodApp.DeliveryPartners.FirstOrDefault(d=> d.DeliveryPartnerID == id);
            dbContextFoodApp.DeliveryPartners.Remove(deliveryPartner);
            dbContextFoodApp.SaveChanges();
            if(deliveryPartner!=null)
                return true;
            return false;
        }
        IEnumerable<DeliveryPartner> IDeliveryPartnerRepository.GetAll()
        {
            return dbContextFoodApp.DeliveryPartners.ToList();
        }
        DeliveryPartner IDeliveryPartnerRepository.GetById(int id)
        {
            DeliveryPartner? deliveryPartner = dbContextFoodApp.DeliveryPartners.FirstOrDefault(d => d.DeliveryPartnerID == id);
            if(deliveryPartner!=null)
                return deliveryPartner;
            return null;
        }
        DeliveryPartner IDeliveryPartnerRepository.Update(DeliveryPartner partner)
        {
            dbContextFoodApp.DeliveryPartners.Update(partner);
            dbContextFoodApp.SaveChanges();
            return partner;
        }
    }
}
