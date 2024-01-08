using FluentValidation;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Validation
{
    internal class UpdateInvoiceHeaderValidation : AbstractValidator<UpdateInvoiceHeaderDto>
    {
        private readonly IGenericRepository<InvoiceHeader> _invoiceHeaderRepo;
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly IGenericRepository<Cashier> _cashierRepo;

        public UpdateInvoiceHeaderValidation(IGenericRepository<Cashier> cashierRepo,
                                             IGenericRepository<Branch> branchRepo,
                                             IGenericRepository<InvoiceHeader> invoiceHeaderRepo)
        {
            _cashierRepo = cashierRepo;
            _branchRepo = branchRepo;
            _invoiceHeaderRepo = invoiceHeaderRepo;

            RuleFor(u => u.ID)
                .NotEmpty()
                .MustAsync(IsExist)
                .WithMessage("الفرع غير موجود");

            When(x => x.BranchID is not null, () =>
                RuleFor(u => u.BranchID)
                    .MustAsync(IsBranchExist)
                    .WithMessage("الفرع غير موجود"));

            When(x => x.CashierID is not null, () =>
                RuleFor(u => u.CashierID)
                    .MustAsync(IsCashierExist)
                    .WithMessage("الفرع غير موجود"));
        }
        private async Task<bool> IsExist(long id, CancellationToken cancellationToken)
           => await _invoiceHeaderRepo.IsExist(x => x.ID == id);

        private async Task<bool> IsBranchExist(int? id, CancellationToken cancellationToken)
            => await _branchRepo.IsExist(x => x.ID == id);

        private async Task<bool> IsCashierExist(int? id, CancellationToken cancellationToken)
            => await _cashierRepo.IsExist(x => x.ID == id);
    }
}