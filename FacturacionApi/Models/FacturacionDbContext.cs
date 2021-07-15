using FacturacionApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacturacionApi.Models
{
    public class FacturacionDbContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            optionsBuilder.UseSqlServer(@"Data Source=LAP0301TEC357\SQLEXPRESS;Initial Catalog=FacturacionDB;Trusted_Connection=True;");
        
        }
    }
}
