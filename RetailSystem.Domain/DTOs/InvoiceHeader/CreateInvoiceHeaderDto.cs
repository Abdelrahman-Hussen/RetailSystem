namespace RetailSystem.Domain.DTOs
{
    public class CreateInvoiceHeaderDto
    {
        [Required(ErrorMessage = "الخانة مطلوبة")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "الاسم لا يجب أن يحتوي على أرقام.")]
        public string CustomerName { get; set; }
        public int? CashierID { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبة")]
        public int BranchID { get; set; }
    }
}
