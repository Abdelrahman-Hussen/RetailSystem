namespace RetailSystem.Application.Abstractions
{
    public interface ICashierService
    {
        Task<ResponseModel<CashierDto>> Create(CreateCashierDto Dto);
        Task<ResponseModel<string>> Delete(int id);
        ResponseModel<List<CashierDto>> GetAll(RequestModel requestModel);
        ResponseModel<List<CashierDto>> GetAllForLookUp();
        ResponseModel<CashierDto> GetById(int Id);
        Task<ResponseModel<CashierDto>> Update(UpdateCashierDto Dto);
    }
}