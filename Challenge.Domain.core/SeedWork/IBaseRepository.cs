using System.Linq.Expressions;

namespace Challenge.Domain.core.SeedWork
{
    public interface IBaseRepository<TEntity> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// get all records 
        /// </summary>
        /// <returns>queryable to record</returns>
        Task<IEnumerable<TEntity>> GetAll();
        public Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expr, params object[] paths);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expr);
        /// <summary>
        /// Get All Register
        /// </summary>
        /// <param name="paths">Include Table</param>
        /// <returns>List Register</returns>
        public Task<IEnumerable<TEntity>> GetAllInclude(params string[] paths);

        public Task<IEnumerable<TEntity>> GetAllExpression(Expression<Func<TEntity, bool>> expr);
        public IQueryable<TEntity> GetAllExpression(Expression<Func<TEntity, bool>> expr, params object[] paths);

        /// <summary>
        /// Object by Id
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Object type T</returns>
        public Task<TEntity> GetById(Guid id);

        public Task<TEntity> GetById(Expression<Func<TEntity, bool>> expr, params object[] paths);

        /// <summary>
        /// Get Object by Expression
        /// </summary>
        /// <param name="expr">Expression</param>
        /// <returns>Object TEntity</returns>
        public Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expr, params object[] paths);


        /// <summary>
        /// Create Register
        /// </summary>
        /// <param name="record">Object Create</param>
        /// <returns>Primary Key</returns> 

        public Task<TEntity> Create(TEntity record);
        public Task Create(IEnumerable<TEntity> records);
        public Task<bool> Commit();


        /// <summary>
        /// Update Register
        /// </summary>
        /// <param name="record">Object Update</param>
        public Task<TEntity> Update(TEntity record);

        /// <summary>
        /// remove register
        /// </summary>
        /// <param name="record">entity</param>
        /// <returns>bool value</returns>
        Task<bool> Remove(TEntity record);

        Task<bool> Exists(Expression<Func<TEntity, bool>> expr);


    }
}








