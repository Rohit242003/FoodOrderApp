using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_41_FoodOrderingApp.Model
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        


    }
}
