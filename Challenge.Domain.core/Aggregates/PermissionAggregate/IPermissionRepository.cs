using Challenge.Domain.core.SeedWork;
using System.Linq.Expressions;

namespace Challenge.Domain.core.Aggregates.PermissionAggregate
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<IEnumerable<Permission>> getAllPermission();
        Task <(bool, Permission)> addPermission(Permission permission);
        Task <(bool, Permission)> ModifyPermission(Permission permission);
        Task<Permission> getByIdPermission(Guid Id);
        Task<bool> existsPermission(Guid Id);
        Task<IEnumerable<Permission>> getAllPermission(Expression<Func<Permission, bool>> expr);
 
    }
}
