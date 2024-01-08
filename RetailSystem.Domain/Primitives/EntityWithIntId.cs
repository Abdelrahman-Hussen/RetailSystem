namespace RetailSystem.Domain.Primitives
{
    public class EntityWithIntId : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}
