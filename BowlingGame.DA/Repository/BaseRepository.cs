using BowlingGame.DA.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BowlingGame.BE.Interfaces;

namespace BowlingGame.DA.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected internal BowlingGameDBContext dbContext;

        public BaseRepository(BowlingGameDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Add or Replace Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Save(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// AsNoTracking to force cache to be refreshed
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }
    }
}