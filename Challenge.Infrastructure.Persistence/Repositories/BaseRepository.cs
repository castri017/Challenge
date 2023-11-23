using Challenge.Domain.core.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> bdColletion;

        public BaseRepository(DbContext _context)
        {
            this._context = _context;
            bdColletion = _context.Set<TEntity>();

        }

        public async Task<TEntity> Create(TEntity record)
        {
            await bdColletion.AddAsync(record);
            return record;
        }

        public async Task Create(IEnumerable<TEntity> records)
        {
            await bdColletion.AddRangeAsync(records);
        }
        public async Task<TEntity> Update(TEntity record)
        {
            bdColletion.Update(record);
            _context.Entry(record).State = EntityState.Modified;
            return record;
        }

        public async Task<bool> Remove(TEntity record)
        {
            if (_context.Entry(record).State == EntityState.Detached)
            {
                bdColletion.Attach(record);
            }

            bdColletion.Remove(record);
            var isremove = true;
            return isremove;
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expr)
        {
            IEnumerable<TEntity> listEntity = null;
            listEntity = bdColletion.Where(expr).ToList();
            return listEntity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> listEntity = null;
            listEntity = bdColletion.ToList();
            return listEntity;
        }
        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expr, params object[] paths)
        {
            IEnumerable<TEntity> listEntity = null;
            listEntity = bdColletion.Include(paths.First().ToString()).Where(expr).Distinct().ToList();
            return listEntity.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(params string[] paths)
        {
            IEnumerable<TEntity> listEntity = null;
            listEntity = bdColletion.Include(paths.First()).ToList();
            return listEntity;
        }

        public async Task<IEnumerable<TEntity>> GetAllExpression(Expression<Func<TEntity, bool>> expr)
        {
            IEnumerable<TEntity> listEntity = null;
            listEntity = bdColletion.Where(expr).ToList();
            return listEntity.Distinct();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            TEntity Entity = null;

            //var valueCache = await _cache.getOneToCache<TEntity>(id);

            //if (_cache.existCache())
            //return _cache.FromByteArrayToEntity<TEntity>(valueCache);

            //if (!_cache.existCache())
            Entity = await bdColletion.FindAsync(id);

            //if (!_cache.existErrorInCaching() && !_cache.existCache() && Entity != null)
            //    await _cache.addToCache(Entity);

            return Entity;
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> expr, params object[] paths)
        {
            TEntity Entity = null;


            //var Id = Guid.Parse(paths[1].ToString());
            //var valueCache = await _cache.getOneToCache<TEntity>(Id);

            //if (_cache.existCache())
            //    return _cache.FromByteArrayToEntity<TEntity>(valueCache);

            //if (!_cache.existCache())
            Entity = bdColletion.Include(paths.First().ToString()).Where(expr).FirstOrDefault();

            //if (!_cache.existErrorInCaching() && !_cache.existCache() && Entity != null)
            //    await _cache.addToCache(Entity);


            return Entity;
        }



        public async Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expr, params object[] paths)
        {
            TEntity Entity = null;
            var Id = Guid.Parse(paths[0].ToString());
            Entity = bdColletion.FirstOrDefault(expr);
            return Entity;
        }

        public IQueryable<TEntity> GetAllExpression(Expression<Func<TEntity, bool>> expr, params object[] paths)
        {
            IQueryable<TEntity> Entitys = null;

            //var valueCache = await _cache.getListToCache<TEntity>();

            //if (_cache.existCache())
            //    return _cache.FromByteArrayToList<TEntity>(valueCache);

            //if (!_cache.existCache())
            Entitys = bdColletion.Include(paths.First().ToString()).Where(expr);

            //if (!_cache.existErrorInCaching() && !_cache.existCache() && Entitys != null)
            //    await _cache.addToCache(Entitys);

            return Entitys;
        }

        public async Task<bool> Commit()
        {
            var save = await _context.SaveChangesAsync();
            var retorno = save >= 0;

            return retorno;
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> expr)
        {
            return await bdColletion.AnyAsync(expr);
        }
    }
}
