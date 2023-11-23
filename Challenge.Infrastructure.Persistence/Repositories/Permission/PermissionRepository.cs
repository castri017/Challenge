using Challenge.Application.Services.Services;
using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace Challenge.Infrastructure.Persistence.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {

        public PermissionRepository(DbContext _context) : base(_context) { }

        public async Task<(bool, Permission)> addPermission(Permission permission)
        {
            try
            {
                var newPermission = await this.Create(permission);
                var isCreated = await this.Commit();
                return (isCreated, newPermission);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> existsPermission(Guid Id)
        {
            var permission = await this.GetByExpression(param => param.Id == Id, new string[1] { Id.ToString() });
            return permission.hasRecords();
        }

        public async Task<IEnumerable<Permission>> getAllPermission(Expression<Func<Permission, bool>> expr)
        {
            return await this.GetAllExpression(expr);
        }

        public async Task<IEnumerable<Permission>> getAllPermission()
        {
            return await this.GetAll();
        }

        public async Task<Permission> getByIdPermission(Guid Id)
        {
            return await this.GetById(Id);
        }

        public async Task<(bool, Permission)> ModifyPermission(Permission permission)
        {
            var _permission = await getByIdPermission(permission.Id);
            _permission.setValuePermission(permission);
            permission = null;
            var permissionUpdated = await this.Update(_permission);
            var isupdated = await this.Commit();
            return (isupdated, permissionUpdated);
        }
    }
}
