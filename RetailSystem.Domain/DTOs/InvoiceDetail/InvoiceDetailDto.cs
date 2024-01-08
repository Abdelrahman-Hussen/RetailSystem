namespace RetailSystem.Domain.DTOs
{
    public class InvoiceDetailDto
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }
        public long InvoiceHeaderID { get; set; }
        public RawInvoiceHeaderDto InvoiceHeader { get; set; }
    }
}
