using RetailSystem.Domain.Specifications;

namespace RetailSystem.Application.Specifications
{
    internal class InvoiceHeaderSpecification : BaseSpecification<InvoiceHeader>
    {
        public static InvoiceHeaderSpecification GatAll(RequestModel requestModel)
        {
            var spec = new InvoiceHeaderSpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.CustomerName.Contains(requestModel.Search));

            spec.AddInclude(new List<string>()
            {
                nameof(InvoiceHeader.Cashier),
                nameof(InvoiceHeader.Branch),
                nameof(InvoiceHeader.InvoiceDetails)
            });

            return spec;
        }
        
        public static InvoiceHeaderSpecification GatAllWithOutInclude(RequestModel requestModel)
        {
            var spec = new InvoiceHeaderSpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.CustomerName.Contains(requestModel.Search));

            return spec;
        }

        public static InvoiceHeaderSpecification GatWithId(long Id)
        {
            var spec = new InvoiceHeaderSpecification();

            spec.AddCriteria(x => x.ID == Id);

            spec.AddInclude(new List<string>()
            {
                nameof(InvoiceHeader.Cashier),
                nameof(InvoiceHeader.Branch),
                nameof(InvoiceHeader.InvoiceDetails)
            });

            return spec;
        }
    }
}
