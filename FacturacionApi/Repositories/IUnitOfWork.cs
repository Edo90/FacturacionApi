using FacturacionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturacionApi.Repositories
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }

        void BeginTransaction();
        void SaveChanges();
        bool Commit();
        void Rollback();
        FacturacionDbContext GetDbContext();
    }
}