namespace RetailSystem.Domain.Models
{
    public class Cashier : EntityWithIntId
    {
        public string CashierName { get; set; }

        [ForeignKey(nameof(BranchID))]
        public int BranchID { get; set; }
        public Branch Branch { get; set; }

        public void Update(UpdateCashierDto Dto)
        {
            CashierName = String.IsNullOrEmpty(Dto.CashierName) ? CashierName : Dto.CashierName;
            BranchID = Dto.BranchID ?? BranchID;
        }
    }
}
