namespace RetailSystem.Domain.DTOs
{
    public class CreateCashierDto
    {
        [Required(ErrorMessage = "الخانة مطلوبة")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "الاسم لا يجب أن يحتوي على أرقام.")]
        public string CashierName { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبة")]
        public int BranchID { get; set; }
    }
}
