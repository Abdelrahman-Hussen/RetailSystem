namespace RetailSystem.Domain.DTOs
{
    public class UpdateInvoiceHeaderDto
    {
        [Required]
        public long ID { get; set; }

        [RegularExpression("^[^0-9]+$", ErrorMessage = "الاسم لا يجب أن يحتوي على أرقام.")]
        public string? CustomerName { get; set; }
        public int? CashierID { get; set; }
        public int? BranchID { get; set; }
    }
}
