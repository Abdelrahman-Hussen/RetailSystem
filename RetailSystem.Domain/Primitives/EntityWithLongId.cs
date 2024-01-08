namespace RetailSystem.Domain.Primitives
{
    public class EntityWithLongId : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
    }
}
