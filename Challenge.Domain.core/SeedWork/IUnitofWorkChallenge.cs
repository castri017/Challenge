using Challenge.Domain.core.Aggregates.PermissionAggregate;

namespace Challenge.Domain.core.SeedWork

{
    public interface IUnitofWorkChallenge 
    {
        
        IPermissionRepository permissionRepository { get; }        
        Task commit();
        Task RollBack();
    }
}
