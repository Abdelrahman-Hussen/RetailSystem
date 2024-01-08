using RetailSystem.Domain.Specifications;

namespace RetailSystem.Application.Specifications
{
    internal class CitySpecification : BaseSpecification<City>
    {
        public static CitySpecification GatAll(RequestModel requestModel)
        {
            var spec = new CitySpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.CityName.Contains(requestModel.Search));

            spec.AddInclude(new List<string>()
            {
                nameof(City.Branches)
            });

            return spec;
        }

        public static CitySpecification GatAllWithOutInclude(RequestModel requestModel)
        {
            var spec = new CitySpecification();

            if (!String.IsNullOrEmpty(requestModel.Search))
                spec.AddCriteria(x => x.CityName.Contains(requestModel.Search));

            return spec;
        }

        public static CitySpecification GatWithId(int Id)
        {
            var spec = new CitySpecification();

            spec.AddCriteria(x => x.ID == Id);

            spec.AddInclude(new List<string>()
            {
                nameof(City.Branches)
            });

            return spec;
        }
    }
}
