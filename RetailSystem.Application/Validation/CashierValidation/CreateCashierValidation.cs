using FluentValidation;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Validation
{
    internal class CreateCashierValidation : AbstractValidator<CreateCashierDto>
    {
        private readonly IGenericRepository<Branch> _branchRepo;

        public CreateCashierValidation(IGenericRepository<Branch> branchRepo)
        {
            _branchRepo = branchRepo;

            RuleFor(u => u.CashierName)
                .NotEmpty()
                .WithMessage("إسم الكاشير مطلوب");

            RuleFor(u => u.BranchID)
                .NotEmpty()
                .MustAsync(IsBranchExist)
                .WithMessage("الفرع غير موجود الرجاء اختيار فرع اخر");
        }

        private async Task<bool> IsBranchExist(int id, CancellationToken cancellationToken)
            => (await _branchRepo.IsExist(x => x.ID == id));
    }
}