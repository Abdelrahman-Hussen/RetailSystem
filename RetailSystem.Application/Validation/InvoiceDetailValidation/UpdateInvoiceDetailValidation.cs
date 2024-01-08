using FluentValidation;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Validation
{
    internal class UpdateInvoiceDetailValidation : AbstractValidator<UpdateInvoiceDetailDto>
    {
        private readonly IGenericRepository<InvoiceDetail> _invoiceDetailRepo;

        public UpdateInvoiceDetailValidation(IGenericRepository<InvoiceDetail> invoiceDetailRepo)
        {
            _invoiceDetailRepo = invoiceDetailRepo;

            RuleFor(u => u.ID)
                .NotEmpty()
                .MustAsync(IsExist)
                .WithMessage("الفاتورة غير موجود");

            RuleFor(u => u.ItemCount)
                .GreaterThan(0)
                .WithMessage("الكمية يجب ان تكون رقم اكبر من ال 0");

            RuleFor(u => u.ItemPrice)
                .GreaterThan(0)
                .WithMessage("السعر يجب ان تكون رقم اكبر من ال 0");
        }

        private async Task<bool> IsExist(long id, CancellationToken cancellationToken)
            => await _invoiceDetailRepo.IsExist(x => x.ID == id);
    }
}