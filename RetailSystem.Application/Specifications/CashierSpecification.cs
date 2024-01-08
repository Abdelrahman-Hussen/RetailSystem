using RetailSystem.Domain.Specifications;

namespace RetailSystem.Application.Specifications
{
    internal class CashierSpecification : BaseSpecification<Cashier>
    {
        public static CashierSpecification GatAll(RequestModel requestModel)
        {
            var spec = new CashierSpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.CashierName.Contains(requestModel.Search));

            spec.AddInclude(new List<string>()
            {
                nameof(Cashier.Branch)
            });

            return spec;
        }

        public static CashierSpecification GatAllWithOutInclude(RequestModel requestModel)
        {
            var spec = new CashierSpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.CashierName.Contains(requestModel.Search));

            return spec;
        }

        public static CashierSpecification GatWithId(int Id)
        {
            var spec = new CashierSpecification();

            spec.AddCriteria(x => x.ID == Id);

            spec.AddInclude(new List<string>()
            {
                nameof(Cashier.Branch)
            });

            return spec;
        }
    }
}
