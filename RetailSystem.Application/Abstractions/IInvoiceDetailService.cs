namespace RetailSystem.Application.Abstractions
{
    public interface IInvoiceDetailService
    {
        Task<ResponseModel<InvoiceDetailDto>> Create(CreateInvoiceDetailDto Dto);
        Task<ResponseModel<string>> Delete(long id);
        ResponseModel<List<InvoiceDetailDto>> GetAll(InvoiceDetailRequestModel requestModel);
        ResponseModel<InvoiceDetailDto> GetById(int Id);
        Task<ResponseModel<InvoiceDetailDto>> Update(UpdateInvoiceDetailDto Dto);
    }
}