namespace AzmoonGaj.Domain.Entities
{

    public enum DiscountType { Percentage, FixedAmount }

    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DiscountType Type { get; set; }  
        public decimal Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public ProductCategory ApplicableCategory { get; set; } // مثلاً فقط آنلاین
    }
}
