using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_41_FoodOrderingApp.Model
{
    public class OrderItem
    {
        [Key] 
        public int OrderItemId { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public virtual MenuItem? MenuItem { get; set; }

        [Required(ErrorMessage ="Field Required")]
        public int Quantity { get; set; }
    }
}
