namespace RetailSystem.Domain.DTOs
{
    public class InvoiceDetailRequestModel : RequestModel
    {
        [Required]
        public long InvoiceHeaderId { get; set; }
    }
}
