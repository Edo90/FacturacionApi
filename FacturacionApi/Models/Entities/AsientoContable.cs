using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Models.Entities
{
    public class AsientoContable
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Cuenta { get; set; }
        public TipoDeMovimiento TipoDeMovimiento { get; set; }
        public DateTime FechaAsiento { get; set; }
        public decimal MontoAsiento { get; set; }
        public bool Estado { get; set; }

    }

    public enum TipoDeMovimiento
    {
        DB,
        CR
    }
}
