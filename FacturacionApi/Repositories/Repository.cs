using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        //private readonly IUnitOfWork _unitOfWork;
        public Repository(DbContext dbContext)
        {
            //_unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
        public IEnumerable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>();
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Pending to fix
        /// </summary>
        public void SaveUnitOfWork()
        {
            //_unitOfWork.SaveChanges();
        }
    }
}
