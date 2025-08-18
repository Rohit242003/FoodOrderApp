using Day_41_FoodOrderingApp.Model;

namespace Day_41_FoodOrderingApp.Repository
{
    public interface IDeliveryPartnerRepository
    {
        DeliveryPartner Add( DeliveryPartner partner );
        DeliveryPartner Update( DeliveryPartner partner );
        bool Delete( int id );
        IEnumerable<DeliveryPartner> GetAll();
        DeliveryPartner GetById( int id );

    }
}
