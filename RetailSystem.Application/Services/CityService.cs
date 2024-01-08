using MapsterMapper;
using Microsoft.Extensions.Logging;
using RetailSystem.Application.Abstractions;
using RetailSystem.Application.Specifications;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Services
{
    internal class CityService : ICityService
    {
        private readonly IGenericRepository<City> _cityRepo;
        private readonly ILogger<City> _logger;
        private readonly IMapper _mapper;

        public CityService(IGenericRepository<City> cityRepo,
                           ILogger<City> logger,
                           IMapper mapper)
        {
            _cityRepo = cityRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public ResponseModel<List<CityDto>> GetAll(RequestModel requestModel)
        {
            try
            {
                var result = _cityRepo.GetWithSpec(CitySpecification.GatAll(requestModel));

                var citiesDto = _mapper.Map<List<CityDto>>(result.data);

                return ResponseModel<List<CityDto>>.Success(citiesDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }
            return ResponseModel<List<CityDto>>.Error();
        }
    }
}
