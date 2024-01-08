namespace RetailSystem.Domain.DTOs
{
    public class UpdateInvoiceDetailDto
    {
        [Required]
        public long ID { get; set; }
        
        [RegularExpression("^[^0-9]+$", ErrorMessage = "الاسم لا يجب أن يحتوي على أرقام.")]
        public string? ItemName { get; set; }

        [Range(0, float.MaxValue, MinimumIsExclusive = true)]
        public float? ItemCount { get; set; }

        [Range(0, float.MaxValue, MinimumIsExclusive = true)]
        public float? ItemPrice { get; set; }
    }
}
