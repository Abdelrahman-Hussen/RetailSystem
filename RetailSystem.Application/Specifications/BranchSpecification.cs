using RetailSystem.Domain.Specifications;

namespace RetailSystem.Application.Specifications
{
    internal class BranchSpecification : BaseSpecification<Branch>
    {
        public static BranchSpecification GatAll(RequestModel requestModel)
        {
            var spec = new BranchSpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.BranchName.Contains(requestModel.Search));

            spec.AddInclude(new List<string>()
            {
                nameof(Branch.City),
                nameof(Branch.Cashiers),
                nameof(Branch.InvoiceHeaders)
            });

            return spec;
        }

        public static BranchSpecification GatAllWithOutInclude(RequestModel requestModel)
        {
            var spec = new BranchSpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.BranchName.Contains(requestModel.Search));

            return spec;
        }

        public static BranchSpecification GatWithId(int Id)
        {
            var spec = new BranchSpecification();

            spec.AddCriteria(x => x.ID == Id);

            spec.AddInclude(new List<string>()
            {
                nameof(Branch.City),
                nameof(Branch.Cashiers),
                nameof(Branch.InvoiceHeaders)
            });

            return spec;
        }
    }
}
