namespace RetailSystem.Application.Abstractions
{
    public interface ICityService
    {
        ResponseModel<List<CityDto>> GetAll(RequestModel requestModel);
    }
}