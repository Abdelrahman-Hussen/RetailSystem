using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using RetailSystem.Application.Abstractions;
using RetailSystem.Application.Specifications;
using RetailSystem.Infrastructure.Reposatory;

namespace RetailSystem.Application.Services
{
    internal class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IGenericRepository<InvoiceDetail> _invoiceDetailRepo;
        private readonly IValidator<CreateInvoiceDetailDto> _createInvoiceDetailValidation;
        private readonly IValidator<UpdateInvoiceDetailDto> _updateInvoiceDetailValidation;
        private readonly ILogger<InvoiceDetail> _logger;
        private readonly IMapper _mapper;

        public InvoiceDetailService(IGenericRepository<InvoiceDetail> invoiceDetailRepo,
                                    IValidator<CreateInvoiceDetailDto> createInvoiceDetailValidation,
                                    IValidator<UpdateInvoiceDetailDto> updateInvoiceDetailValidation,
                                    ILogger<InvoiceDetail> logger,
                                    IMapper mapper)
        {
            _invoiceDetailRepo = invoiceDetailRepo;
            _createInvoiceDetailValidation = createInvoiceDetailValidation;
            _updateInvoiceDetailValidation = updateInvoiceDetailValidation;
            _logger = logger;
            _mapper = mapper;
        }

        public ResponseModel<List<InvoiceDetailDto>> GetAll(InvoiceDetailRequestModel requestModel)
        {
            try
            {
                var result = _invoiceDetailRepo.GetWithSpec(InvoiceDetailSpecification.GatAll(requestModel));

                var InvoiceDetailDto = _mapper.Map<List<InvoiceDetailDto>>(result.data);

                return ResponseModel<List<InvoiceDetailDto>>.Success(InvoiceDetailDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<InvoiceDetailDto>>.Error();
        }

        public ResponseModel<InvoiceDetailDto> GetById(int Id)
        {
            try
            {
                var result = _invoiceDetailRepo.GetEntityWithSpec(InvoiceDetailSpecification.GatWithId(Id));

                if (result == null)
                    return ResponseModel<InvoiceDetailDto>.ErrorNotFound();

                var InvoiceDetailDto = _mapper.Map<InvoiceDetailDto>(result);

                return ResponseModel<InvoiceDetailDto>.Success(InvoiceDetailDto);
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<InvoiceDetailDto>.Error();
        }

        public async Task<ResponseModel<InvoiceDetailDto>> Create(CreateInvoiceDetailDto Dto)
        {
            try
            {
                var validationResult = await _createInvoiceDetailValidation.ValidateAsync(Dto);

                if (!validationResult.IsValid)
                    return ResponseModel<InvoiceDetailDto>
                    .ErrorBadRequset(Helpers.ArrangeValidationErrors(validationResult.Errors));

                var invoiceDetail = _mapper.Map<InvoiceDetail>(Dto);

                await _invoiceDetailRepo.Add(invoiceDetail);
                await _invoiceDetailRepo.Save();

                return ResponseModel<InvoiceDetailDto>.Success(_mapper.Map<InvoiceDetailDto>(invoiceDetail));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<InvoiceDetailDto>.Error();
        }

        public async Task<ResponseModel<InvoiceDetailDto>> Update(UpdateInvoiceDetailDto Dto)
        {
            try
            {
                var validationResult = await _updateInvoiceDetailValidation.ValidateAsync(Dto);

                if (!validationResult.IsValid)
                    return ResponseModel<InvoiceDetailDto>
                    .ErrorBadRequset(Helpers.ArrangeValidationErrors(validationResult.Errors));

                var invoiceDetail = await _invoiceDetailRepo.GetById(Dto.ID);

                invoiceDetail!.Update(Dto);

                await _invoiceDetailRepo.Save();

                return ResponseModel<InvoiceDetailDto>.Success(_mapper.Map<InvoiceDetailDto>(invoiceDetail));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<InvoiceDetailDto>.Error();
        }

        public async Task<ResponseModel<string>> Delete(long id)
        {
            try
            {
                var invoiceDetail = await _invoiceDetailRepo.GetById(id);

                if (invoiceDetail == null)
                    return ResponseModel<string>.ErrorNotFound();

                _invoiceDetailRepo.Delete(invoiceDetail);

                await _invoiceDetailRepo.Save();

                return ResponseModel<string>.Success();
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<string>.Error();
        }
    }
}
