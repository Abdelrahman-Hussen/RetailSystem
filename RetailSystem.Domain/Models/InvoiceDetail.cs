namespace RetailSystem.Domain.Models
{
    public class InvoiceDetail : EntityWithLongId
    {
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }

        [ForeignKey(nameof(InvoiceHeaderID))]
        public long InvoiceHeaderID { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; }

        public void Update(UpdateInvoiceDetailDto Dto)
        {
            ItemName = String.IsNullOrEmpty(Dto.ItemName) ? ItemName : Dto.ItemName;
            ItemCount = Dto.ItemCount ?? ItemCount;
            ItemPrice = Dto.ItemPrice ?? ItemPrice;
        }
    }
}
