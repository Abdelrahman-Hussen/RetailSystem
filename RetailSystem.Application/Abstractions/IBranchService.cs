namespace RetailSystem.Application.Abstractions
{
    public interface IBranchService
    {
        ResponseModel<List<BranchDto>> GetAll(RequestModel requestModel);
        ResponseModel<List<BranchDto>> GetForLookUp();
    }
}