using FacturacionApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Repositories
{
    public class ArticuloRepository : Repository<Articulo>
    {
       public ArticuloRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
       {
        }
    }
}
