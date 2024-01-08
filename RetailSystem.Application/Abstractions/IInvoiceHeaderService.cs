namespace RetailSystem.Application.Abstractions
{
    public interface IInvoiceHeaderService
    {
        Task<ResponseModel<InvoiceHeaderDto>> Create(CreateInvoiceHeaderDto Dto);
        Task<ResponseModel<string>> Delete(long id);
        ResponseModel<List<InvoiceHeaderDto>> GetAll(RequestModel requestModel);
        ResponseModel<InvoiceHeaderDto> GetById(long Id);
        Task<ResponseModel<InvoiceHeaderDto>> Update(UpdateInvoiceHeaderDto Dto);
    }
}