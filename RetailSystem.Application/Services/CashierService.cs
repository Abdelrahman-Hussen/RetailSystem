using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using RetailSystem.Application.Abstractions;
using RetailSystem.Application.Specifications;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Services
{
    internal class CashierService : ICashierService
    {
        private readonly IGenericRepository<Cashier> _cashierRepo;
        private readonly IValidator<CreateCashierDto> _createCashierValidation;
        private readonly IValidator<UpdateCashierDto> _updateCashierValidation;
        private readonly ILogger<Cashier> _logger;
        private readonly IMapper _mapper;

        public CashierService(IGenericRepository<Cashier> cashierRepo,
                              IValidator<CreateCashierDto> createCashierValidation,
                              IValidator<UpdateCashierDto> updateCashierValidation,
                              ILogger<Cashier> logger,
                              IMapper mapper)
        {
            _cashierRepo = cashierRepo;
            _createCashierValidation = createCashierValidation;
            _updateCashierValidation = updateCashierValidation;
            _logger = logger;
            _mapper = mapper;
        }

        public ResponseModel<List<CashierDto>> GetAll(RequestModel requestModel)
        {
            try
            {
                var result = _cashierRepo.GetWithSpec(CashierSpecification.GatAll(requestModel));

                var CashierDto = _mapper.Map<List<CashierDto>>(result.data);

                return ResponseModel<List<CashierDto>>.Success(CashierDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<CashierDto>>.Error();
        }

        public ResponseModel<List<CashierDto>> GetAllForLookUp()
        {
            try
            {
                var result = _cashierRepo.GetWithSpec(CashierSpecification.GatAllWithOutInclude(new RequestModel())).data.ToList();

                var CashierDto = _mapper.Map<List<CashierDto>>(result);

                return ResponseModel<List<CashierDto>>.Success(CashierDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<CashierDto>>.Error();
        }

        public ResponseModel<CashierDto> GetById(int Id)
        {
            try
            {
                var result = _cashierRepo.GetEntityWithSpec(CashierSpecification.GatWithId(Id));

                var CashierDto = _mapper.Map<CashierDto>(result);

                return ResponseModel<CashierDto>.Success(CashierDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<CashierDto>.Error();
        }

        public async Task<ResponseModel<CashierDto>> Create(CreateCashierDto Dto)
        {
            try
            {
                var validationResult = await _createCashierValidation.ValidateAsync(Dto);

                if (!validationResult.IsValid)
                    return ResponseModel<CashierDto>
                    .ErrorBadRequset(Helpers.ArrangeValidationErrors(validationResult.Errors));

                var cashier = _mapper.Map<Cashier>(Dto);

                await _cashierRepo.Add(cashier);
                await _cashierRepo.Save();

                return ResponseModel<CashierDto>.Success(_mapper.Map<CashierDto>(cashier));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<CashierDto>.Error();
        }

        public async Task<ResponseModel<CashierDto>> Update(UpdateCashierDto Dto)
        {
            try
            {
                var validationResult = await _updateCashierValidation.ValidateAsync(Dto);

                if (!validationResult.IsValid)
                    return ResponseModel<CashierDto>
                    .ErrorBadRequset(Helpers.ArrangeValidationErrors(validationResult.Errors));

                var cashier = await _cashierRepo.GetById(Dto.ID);

                cashier!.Update(Dto);

                await _cashierRepo.Save();

                return ResponseModel<CashierDto>.Success(_mapper.Map<CashierDto>(cashier));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<CashierDto>.Error();
        }

        public async Task<ResponseModel<string>> Delete(int id)
        {
            try
            {
                var filter = await _cashierRepo.GetById(id);

                if (filter == null)
                    return ResponseModel<string>.ErrorNotFound();

                _cashierRepo.Delete(filter);

                await _cashierRepo.Save();

                return ResponseModel<string>.Success();
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<string>.Error();
        }
    }
}
