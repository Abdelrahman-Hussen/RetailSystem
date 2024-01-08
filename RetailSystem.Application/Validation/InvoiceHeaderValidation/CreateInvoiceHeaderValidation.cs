using FluentValidation;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Validation
{
    internal class CreateInvoiceHeaderValidation : AbstractValidator<CreateInvoiceHeaderDto>
    {
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly IGenericRepository<Cashier> _cashierRepo;

        public CreateInvoiceHeaderValidation(IGenericRepository<Cashier> cashierRepo, IGenericRepository<Branch> branchRepo)
        {
            _cashierRepo = cashierRepo;
            _branchRepo = branchRepo;

            RuleFor(u => u.CustomerName)
                .NotEmpty()
                .WithMessage("إسم العميل مطلوب");

            RuleFor(u => u.BranchID)
                .NotEmpty()
                .MustAsync(IsBranchExist)
                .WithMessage("الفرع غير موجود");

            When(x => x.CashierID is not null, () =>
                RuleFor(u => u.CashierID)
                    .MustAsync(IsCashierExist)
                    .WithMessage("الفرع غير موجود"));
        }

        private async Task<bool> IsBranchExist(int id, CancellationToken cancellationToken)
            => await _branchRepo.IsExist(x => x.ID == id);

        private async Task<bool> IsCashierExist(int? id, CancellationToken cancellationToken)
            => await _cashierRepo.IsExist(x => x.ID == id);
    }
}