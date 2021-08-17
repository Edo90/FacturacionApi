using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Find(params object[] keyValues);
        IEnumerable<TEntity> FindAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Queryable();
        void SaveChanges();
        /// <summary>
        /// PEnding to fix
        /// </summary>
        void SaveUnitOfWork();
        
    }
}
