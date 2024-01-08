namespace RetailSystem.Domain.Models
{
    public class City : EntityWithIntId
    {
        public string CityName { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
