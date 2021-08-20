using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Models.Entities
{
    public class FacturacionDetalle
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int FacturacionId { get; set; }
        public Facturacion Facturacion { get; set; }
        public int? AsientoId { get; set; }
    }
}
