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


}
