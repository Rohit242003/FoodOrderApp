using System.ComponentModel.DataAnnotations;

namespace Day_41_FoodOrderingApp.Model
{
    public class MenuItem
    {
        [Key] 
        public int MenuId { get; set; }
        [Required(ErrorMessage ="Field Is Required")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "Field Is Required")]
        public double MenuPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
