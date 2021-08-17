using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.AsientoContable
{
    public class CreateAsientoViewModel
    {
        public string Descripcion { get; set; }
        public int ClienteId { get; set; }
        public string Cuenta { get; set; }
        public int TipoDeMovimiento { get; set; }
        public DateTime FechaAsiento { get; set; }
        public decimal MontoAsiento { get; set; }
        public bool Estado { get; set; }
    }
}
