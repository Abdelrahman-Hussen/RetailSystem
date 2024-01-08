namespace RetailSystem.Domain.DTOs
{
    public class UpdateCashierDto
    {
        [Required]
        public int ID { get; set; }

        [RegularExpression("^[^0-9]+$", ErrorMessage = "الاسم لا يجب أن يحتوي على أرقام.")]
        public string? CashierName { get; set; }
        public int? BranchID { get; set; }
    }
}
