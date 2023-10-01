using System.Linq.Expressions;

namespace TranslateHistory.Common.Data.Interfaces
{
    public interface IAbstractRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetByID(object id);

        Task<TEntity> Insert(TEntity entity);

        Task Delete(object id);

        Task Delete(TEntity entityToDelete);

        Task<TEntity> Update(TEntity entityToUpdate);
    }
}