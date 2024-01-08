using RetailSystem.Domain.DTOs;

namespace RetailSystem.Models
{
    public class SuperInvoiceHeaderDto
    {
        public List<InvoiceHeaderDto>? InvoiceHeaderDtos { get; set; }
        public CreateInvoiceHeaderDto? createInvoiceHeaderDto { get; set; }
        public UpdateInvoiceHeaderDto? updateInvoiceHeaderDto { get; set; }
        public CreateInvoiceDetailDto? createInvoiceDetailDto { get; set; }
        public RequestModel requestModel { get; set; } = new RequestModel();
    }
}
