namespace RetailSystem.Domain.DTOs
{
    public class CreateInvoiceDetailDto
    {
        [Required(ErrorMessage = "الخانة مطلوبة")]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "الاسم لا يجب أن يحتوي على أرقام.")]
        public string ItemName { get; set; }
        
        [Required(ErrorMessage = "الخانة مطلوبة")]
        [Range(0, float.MaxValue, MinimumIsExclusive = true)]
        public float ItemCount { get; set; }
        
        [Required(ErrorMessage = "الخانة مطلوبة")]
        [Range(0, float.MaxValue, MinimumIsExclusive = true)]
        public float ItemPrice { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبة")]
        public long InvoiceHeaderID { get; set; }
    }
}
