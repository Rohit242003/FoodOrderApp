namespace Day_41_FoodOrderingApp.Model
{
    public class DiscountConfig
    {
        public static double amount {  get; set; }
        public static double discount_rate { get; set; } = 0.2;
       
        public static double calculateDiscount()
        {
            return amount - (amount * discount_rate);
        }
    }
}
