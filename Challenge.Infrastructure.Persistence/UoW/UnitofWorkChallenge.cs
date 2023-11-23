using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Challenge.Domain.core.SeedWork;
using Challenge.Infrastructure.Persistence.Context;
using Challenge.Infrastructure.Persistence.Repositories;

namespace Challenge.Infrastructure.Persistence.UoW
{
    public class UnitofWorkChallenge :  IUnitofWorkChallenge, IDisposable
    {
        private readonly ChallengeContext _challenegeContext;
        public IPermissionRepository _permissionRepository;


        public UnitofWorkChallenge(ChallengeContext _challenegeContext)
        {
            this._challenegeContext = _challenegeContext; 
        }

        public IPermissionRepository permissionRepository => (_permissionRepository == null) ? new PermissionRepository(_challenegeContext) : _permissionRepository;


        public async Task commit()
        {
            _challenegeContext.SaveChanges();
            if (_challenegeContext.Database.CurrentTransaction != null)
            {
                await _challenegeContext.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task RollBack()
        {
            await _challenegeContext.Database.CurrentTransaction.RollbackAsync();
        }

        public void Dispose()
        {
            GC.KeepAlive(this);
            _challenegeContext.Dispose();
        }

    }
}
