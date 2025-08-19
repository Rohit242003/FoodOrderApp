using Day_41_FoodOrderingApp.Model;

public interface IDeliveryPartnerService
{
    IEnumerable<DeliveryPartner> GetAllPartners();
    DeliveryPartner GetPartnerById(int id);
    DeliveryPartner CreatePartner(DeliveryPartner deliveryPartner);
    DeliveryPartner UpdatePartner(DeliveryPartner deliveryPartner);
    bool DeletePartner(int id);
}