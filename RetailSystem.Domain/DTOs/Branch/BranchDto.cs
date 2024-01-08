namespace RetailSystem.Domain.DTOs
{
    public class BranchDto
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public RawCityDto City { get; set; }
        public List<RawCashierDto> Cashiers { get; set; }
        public List<RawInvoiceHeaderDto> InvoiceHeaders { get; set; }
    }
}
