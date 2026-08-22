namespace AzmoonGaj.Domain.Entities
{
    public class SalesTarget
    {
        public int Id { get; set; }
        public int RepresentativeId { get; set; }
        public Representative Representative { get; set; }
        public decimal TargetAmount { get; set; }   // کف قابل‌قبول
    }
}
