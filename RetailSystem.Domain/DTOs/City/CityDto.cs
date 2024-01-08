namespace RetailSystem.Domain.DTOs
{
    public class CityDto
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public List<RawBranchDto> Branches { get; set; }
    }
}
