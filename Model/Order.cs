using Day_41_FoodOrderingApp.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Field Required")]
    public List<OrderItem> OrderItems { get; set; }

    [Required(ErrorMessage = "Field Required")]
    public double OrderAmount { get; set; }

    [ForeignKey("DeliveryPartner")]
    public int DeliveryPartnerId { get; set; }
    public virtual DeliveryPartner? DeliveryPartner { get; set; }

    [ForeignKey("PaymentMethod")]
    public int PaymentMethodId { get; set; }
    public virtual PaymentMethod? PaymentMethod { get; set; }

    public double Discount { get; set; } = 0.2;
    public double FinalAmount { get; set; } 
}
