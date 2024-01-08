using MapsterMapper;
using Microsoft.Extensions.Logging;
using RetailSystem.Application.Abstractions;
using RetailSystem.Application.Specifications;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Services
{
    internal class BranchService : IBranchService
    {
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly ILogger<Branch> _logger;
        private readonly IMapper _mapper;

        public BranchService(IGenericRepository<Branch> branchRepo,
                             ILogger<Branch> logger,
                             IMapper mapper)
        {
            _branchRepo = branchRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public ResponseModel<List<BranchDto>> GetAll(RequestModel requestModel)
        {
            try
            {
                var result = _branchRepo.GetWithSpec(BranchSpecification.GatAll(requestModel));

                var branchsDto = _mapper.Map<List<BranchDto>>(result.data);

                return ResponseModel<List<BranchDto>>.Success(branchsDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<BranchDto>>.Error();
        }

        public ResponseModel<List<BranchDto>> GetForLookUp()
        {
            try
            {
                var result = _branchRepo.GetWithSpec(BranchSpecification.GatAllWithOutInclude(new RequestModel())).data.ToList();

                var branchsDto = _mapper.Map<List<BranchDto>>(result);

                return ResponseModel<List<BranchDto>>.Success(branchsDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<BranchDto>>.Error();
        }
    }
}
