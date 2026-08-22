namespace AzmoonGaj.Domain.Entities
{


    public enum ProductCategory
    {
        Online,
        Printed
    }
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }         
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public ProductCategory Category { get; set; } 
        public string Grade { get; set; }     
        public string Major { get; set; }       
        public DateTime ExamDate { get; set; }    
        public DateTime CreatedAt { get; set; }
    }

  

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }     
        public decimal DiscountAmount { get; set; }
        public string AppliedDiscountCode { get; set; }  
    }
}
