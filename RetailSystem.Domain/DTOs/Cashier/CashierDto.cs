namespace RetailSystem.Domain.DTOs
{
    public class CashierDto
    {
        public int ID { get; set; }
        public string CashierName { get; set; }
        public RawBranchDto Branch { get; set; }
    }
}
