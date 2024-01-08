namespace RetailSystem.Domain.Models
{
    public class InvoiceHeader : EntityWithLongId
    {
        public string CustomerName { get; set; }
        public DateTime Invoicedate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(CashierID))]
        public int? CashierID { get; set; }
        public Cashier Cashier { get; set; }

        [ForeignKey(nameof(BranchID))]
        public int BranchID { get; set; }
        public Branch Branch { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public void Update(UpdateInvoiceHeaderDto Dto)
        {
            CustomerName = String.IsNullOrEmpty(Dto.CustomerName) ? CustomerName : Dto.CustomerName;
            BranchID = Dto.BranchID ?? BranchID;
            CashierID = Dto.CashierID;
        }
    }
}
