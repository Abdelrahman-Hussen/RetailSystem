namespace RetailSystem.Domain.Models
{
    public class Branch : EntityWithIntId
    {
        public string BranchName { get; set; }
        
        [ForeignKey(nameof(CityID))]
        public int CityID { get; set; }
        public City City { get; set; }

        public ICollection<Cashier> Cashiers { get; set; }
        public ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
