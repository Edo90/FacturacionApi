using FacturacionApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Repositories
{
    public static class Extensions
    {
        public static int SumTwoDBNumbers(this IRepository<Articulo> repository)
        {
            return 2;
        }
    }
}
