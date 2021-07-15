using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Models.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PorcientoDeComision { get; set; }
        public bool Estado { get; set; }
    }
}
