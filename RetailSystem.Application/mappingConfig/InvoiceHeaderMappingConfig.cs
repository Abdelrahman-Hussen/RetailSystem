using Mapster;
using RetailSystem.Domain.Models;

namespace RetailSystem.Application.mappingConfig
{
    internal class InvoiceHeaderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InvoiceHeader, InvoiceHeaderDto>()
                .Map(dest => dest.TotalPrice,
                    src => InvoiceTotalPrice(src.InvoiceDetails));
        }

        public double InvoiceTotalPrice(ICollection<InvoiceDetail> src)
        {
            if(src is null || !src.Any())
                return 0.0;

            return src.Sum(x => x.ItemPrice * x.ItemCount);
        }
    }
}