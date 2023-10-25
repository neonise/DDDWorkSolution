namespace Domain
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public OrderDeliveryType DeliveryType { get; set; }

        public Student Student { get; set; }
        public Discount? Discount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
