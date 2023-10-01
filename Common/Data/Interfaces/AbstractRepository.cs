using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TranslateHistory.Common.Data.Interfaces
{
    public class AbstractRepository<TEntity> : IAbstractRepository<TEntity> where TEntity : class
    {

        internal DataContext context;
        internal DbSet<TEntity> dbSet;

        public AbstractRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task Delete(object id)
        {
            TEntity? entityToDelete = dbSet.Find(id) ?? throw new Exception("Entity not found");
            await Delete(entityToDelete);
        }

        public async Task Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            var result = await context.SaveChangesAsync() > 0;
            if (!result) throw new Exception("Error deleting entity");
        }

        public async Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public Task<TEntity> GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}