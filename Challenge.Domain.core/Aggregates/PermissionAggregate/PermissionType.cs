using Challenge.Domain.core.SeedWork;

namespace Challenge.Domain.core.Aggregates.PermissionAggregate
{
    public class PermissionType : Entity
    {
        public string Description { get; private set; } 

        public PermissionType()  { }
         
        public PermissionType(string Description)
        {
            Id = Guid.NewGuid();
            this.Description = Description;
        } 
    }
}
