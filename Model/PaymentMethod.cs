using System.ComponentModel.DataAnnotations;

namespace Day_41_FoodOrderingApp.Model
{
    public enum Payments
    {
        UPI, CREDIT_CARD, DEBITCARD, MOBILE_BANKING, NET_BANKING
    }
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Required]
        public Payments Payments { get; set; }
    }
}
