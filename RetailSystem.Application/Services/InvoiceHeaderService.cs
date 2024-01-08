using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using RetailSystem.Application.Abstractions;
using RetailSystem.Application.Specifications;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Services
{
    internal class InvoiceHeaderService : IInvoiceHeaderService
    {
        private readonly IGenericRepository<InvoiceHeader> _invoiceHeaderRepo;
        private readonly IValidator<CreateInvoiceHeaderDto> _createInvoiceHeaderValidation;
        private readonly IValidator<UpdateInvoiceHeaderDto> _updateInvoiceHeaderValidation;
        private readonly ILogger<InvoiceHeader> _logger;
        private readonly IMapper _mapper;

        public InvoiceHeaderService(IGenericRepository<InvoiceHeader> invoiceHeaderRepo,
                                    IValidator<CreateInvoiceHeaderDto> createInvoiceHeaderValidation,
                                    IValidator<UpdateInvoiceHeaderDto> updateInvoiceHeaderValidation,
                                    ILogger<InvoiceHeader> logger,
                                    IMapper mapper)
        {
            _invoiceHeaderRepo = invoiceHeaderRepo;
            _createInvoiceHeaderValidation = createInvoiceHeaderValidation;
            _updateInvoiceHeaderValidation = updateInvoiceHeaderValidation;
            _logger = logger;
            _mapper = mapper;
        }
        public ResponseModel<List<InvoiceHeaderDto>> GetAll(RequestModel requestModel)
        {
            try
            {
                var result = _invoiceHeaderRepo.GetWithSpec(InvoiceHeaderSpecification.GatAll(requestModel));

                var InvoiceHeaderDto = _mapper.Map<List<InvoiceHeaderDto>>(result.data);
                
                return ResponseModel<List<InvoiceHeaderDto>>.Success(InvoiceHeaderDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<InvoiceHeaderDto>>.Error();
        }

        public ResponseModel<InvoiceHeaderDto> GetById(long Id)
        {
            try
            {
                var result = _invoiceHeaderRepo.GetEntityWithSpec(InvoiceHeaderSpecification.GatWithId(Id));

                if (result == null)
                    return ResponseModel<InvoiceHeaderDto>.ErrorNotFound();

                var InvoiceHeaderDto = _mapper.Map<InvoiceHeaderDto>(result);

                return ResponseModel<InvoiceHeaderDto>.Success(InvoiceHeaderDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<InvoiceHeaderDto>.Error();
        }

        public async Task<ResponseModel<InvoiceHeaderDto>> Create(CreateInvoiceHeaderDto Dto)
        {
            try
            {
                var validationResult = await _createInvoiceHeaderValidation.ValidateAsync(Dto);

                if (!validationResult.IsValid)
                    return ResponseModel<InvoiceHeaderDto>
                    .ErrorBadRequset(Helpers.ArrangeValidationErrors(validationResult.Errors));

                var invoiceHeader = _mapper.Map<InvoiceHeader>(Dto);

                await _invoiceHeaderRepo.Add(invoiceHeader);
                await _invoiceHeaderRepo.Save();

                return ResponseModel<InvoiceHeaderDto>.Success(_mapper.Map<InvoiceHeaderDto>(invoiceHeader));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<InvoiceHeaderDto>.Error();
        }

        public async Task<ResponseModel<InvoiceHeaderDto>> Update(UpdateInvoiceHeaderDto Dto)
        {
            try
            {
                var validationResult = await _updateInvoiceHeaderValidation.ValidateAsync(Dto);

                if (!validationResult.IsValid)
                    return ResponseModel<InvoiceHeaderDto>
                    .ErrorBadRequset(Helpers.ArrangeValidationErrors(validationResult.Errors));

                var invoiceHeader = await _invoiceHeaderRepo.GetById(Dto.ID);

                invoiceHeader!.Update(Dto);

                await _invoiceHeaderRepo.Save();

                return ResponseModel<InvoiceHeaderDto>.Success(_mapper.Map<InvoiceHeaderDto>(invoiceHeader));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<InvoiceHeaderDto>.Error();
        }

        public async Task<ResponseModel<string>> Delete(long id)
        {
            try
            {
                var invoiceHeader = await _invoiceHeaderRepo.GetById(id);

                if (invoiceHeader == null)
                    return ResponseModel<string>.ErrorNotFound();

                _invoiceHeaderRepo.Delete(invoiceHeader);

                await _invoiceHeaderRepo.Save();

                return ResponseModel<string>.Success();
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<string>.Error();
        }
    }
}
