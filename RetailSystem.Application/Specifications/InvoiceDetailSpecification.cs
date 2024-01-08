using RetailSystem.Domain.Specifications;

namespace RetailSystem.Application.Specifications
{
    internal class InvoiceDetailSpecification : BaseSpecification<InvoiceDetail>
    {
        public static InvoiceDetailSpecification GatAll(InvoiceDetailRequestModel requestModel)
        {
            var spec = new InvoiceDetailSpecification();

            spec.AddCriteria(x => x.InvoiceHeaderID == requestModel.InvoiceHeaderId);

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.ItemName.Contains(requestModel.Search));

            spec.AddInclude(new List<string>()
            {
                nameof(InvoiceDetail.InvoiceHeader)
            });

            return spec;
        }

        public static InvoiceDetailSpecification GatAllWithOutInclude(InvoiceDetailRequestModel requestModel)
        {
            var spec = new InvoiceDetailSpecification();

            spec.AddCriteria(x => x.InvoiceHeaderID == requestModel.InvoiceHeaderId);

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.ItemName.Contains(requestModel.Search));

            return spec;
        }

        public static InvoiceDetailSpecification GatWithId(long Id)
        {
            var spec = new InvoiceDetailSpecification();

            spec.AddCriteria(x => x.ID == Id);

            spec.AddInclude(new List<string>()
            {
                nameof(InvoiceDetail.InvoiceHeader)
            });

            return spec;
        }
    }
}
