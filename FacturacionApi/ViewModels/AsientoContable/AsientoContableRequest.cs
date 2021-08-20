using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.AsientoContable
{
    public class AsientoContableRequest
    {
        public AsientoContableRequest()
        {
            Transacciones = new List<Transaccion>();
        }
        public string Descripcion { get; set; }
        public int CatalogoAuxiliarId { get; set; } = 3;
        public string Fecha { get; set; }
        public int MonedasId { get; set; } = 1;
        public List<Transaccion> Transacciones { get; set; }

    }

    public class Transaccion
    {
        public int CuentasContablesId { get; set; }
        public int TipoMovimientoId { get; set; }
        public int Monto { get; set; }
    }

}
