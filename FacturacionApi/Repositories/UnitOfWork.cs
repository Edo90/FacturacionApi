using FacturacionApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly FacturacionDbContext _context;


        public UnitOfWork(FacturacionDbContext dbContext)
        {
            _context = dbContext;
        }

        public DbContext DbContext => _context;

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            try
            {
                _context.Database.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public FacturacionDbContext GetDbContext()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
