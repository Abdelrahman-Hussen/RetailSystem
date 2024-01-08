
namespace RetailSystem.Domain.DTOs
{
    public class InvoiceHeaderDto
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Invoicedate { get; set; }
        public double TotalPrice { get; set; }
        public RawCashierDto? Cashier { get; set; }
        public RawBranchDto Branch { get; set; }
        public List<RawInvoiceDetailDto> InvoiceDetails { get; set; }
    }
}
