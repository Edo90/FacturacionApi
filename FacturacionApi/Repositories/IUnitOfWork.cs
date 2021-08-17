using FacturacionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturacionApi.Repositories
{
    public interface IUnitOfWork
    {
        public DbContext Context { get; }
        void BeginTransaction();
        void SaveChanges();
        bool Commit();
        void Rollback();
        IRepository<TEntity> Repository<TEntity>();
    }
}