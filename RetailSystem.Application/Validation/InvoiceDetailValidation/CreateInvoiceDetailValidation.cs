using FluentValidation;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Validation
{
    internal class CreateInvoiceDetailValidation : AbstractValidator<CreateInvoiceDetailDto>
    {
        private readonly IGenericRepository<InvoiceHeader> _invoiceHeaderRepo;

        public CreateInvoiceDetailValidation(IGenericRepository<InvoiceHeader> invoiceHeaderRepo)
        {
            _invoiceHeaderRepo = invoiceHeaderRepo;

            RuleFor(u => u.ItemName)
                .NotEmpty()
                .WithMessage("إسم العنصر مطلوب");

            RuleFor(u => u.ItemCount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("الكمية يجب ان تكون رقم اكبر من ال 0");

            RuleFor(u => u.ItemPrice)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("السعر يجب ان تكون رقم اكبر من ال 0");

            RuleFor(u => u.InvoiceHeaderID)
                .NotEmpty()
                .MustAsync(IsInvoiceHeaderExist)
                .WithMessage("الفاتورة غير موجود");
        }

        private async Task<bool> IsInvoiceHeaderExist(long id, CancellationToken cancellationToken)
            => await _invoiceHeaderRepo.IsExist(x => x.ID == id);
    }
}