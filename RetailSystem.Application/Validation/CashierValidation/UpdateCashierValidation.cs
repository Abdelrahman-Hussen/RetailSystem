using FluentValidation;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Validation
{
    internal class UpdateCashierValidation : AbstractValidator<UpdateCashierDto>
    {
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly IGenericRepository<Cashier> _cashierRepo;

        public UpdateCashierValidation(IGenericRepository<Branch> branchRepo, IGenericRepository<Cashier> cashierRepo)
        {
            _branchRepo = branchRepo;
            _cashierRepo = cashierRepo;

            RuleFor(u => u.ID)
                    .MustAsync(IsExist)
                    .WithMessage("الكاشير غير موجود");

            When(x => x.BranchID is not null, () => 
                RuleFor(u => u.BranchID)
                    .MustAsync(IsBranchExist)
                    .WithMessage("الفرع غير موجود الرجاء اختيار فرع اخر"));
        }

        private async Task<bool> IsBranchExist(int? id, CancellationToken cancellationToken)
            => (await _branchRepo.IsExist(x => x.ID == id));

        private async Task<bool> IsExist(int id, CancellationToken cancellationToken)
            => (await _cashierRepo.IsExist(x => x.ID == id));
    }
}