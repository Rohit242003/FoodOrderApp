using System.ComponentModel.DataAnnotations;

namespace Day_41_FoodOrderingApp.Model
{
    public class DeliveryPartner
    {
        [Key]
        [Required(ErrorMessage ="Id Required")]
        public int DeliveryPartnerID { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string DeliveryPartnerName { get; set; }
        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}$", ErrorMessage = "Phone Number must be In xxx-xxx format")]
        public string DeliveryPartnerPhone { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public int DeliveryPartnerRating { get; set; } = 4;
    }
}
