namespace AzmoonGaj.Domain.Entities
{

    public enum OrderType { PreOrder, FinalPurchase }
    public enum OrderStatus { Draft, Confirmed, Paid }
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int RepresentativeId { get; set; }
        public Representative Representative { get; set; }
        public int? AgentId { get; set; }         
        public OrderType Type { get; set; }       
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
