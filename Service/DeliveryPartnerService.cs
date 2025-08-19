using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;

public class DeliveryPartnerService : IDeliveryPartnerService
{
    private readonly IDeliveryPartnerRepository _partnerRepository;

    public DeliveryPartnerService(IDeliveryPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public DeliveryPartner CreatePartner(DeliveryPartner deliveryPartner)
    {
        return _partnerRepository.Add(deliveryPartner);
    }

    public bool DeletePartner(int id)
    {
        return _partnerRepository.Delete(id);
    }

    public IEnumerable<DeliveryPartner> GetAllPartners()
    {
        return _partnerRepository.GetAll();
    }

    public DeliveryPartner GetPartnerById(int id)
    {
        return _partnerRepository.GetById(id);
    }

    public DeliveryPartner UpdatePartner(DeliveryPartner deliveryPartner)
    {
        return _partnerRepository.Update(deliveryPartner);
    }
}