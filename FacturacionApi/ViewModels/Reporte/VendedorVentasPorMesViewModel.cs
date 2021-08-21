using FacturacionApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.Reporte
{
    public class VendedorVentasPorMesViewModel 
    {
        public int VendedorId { get; set; }
        public string NombreVendedor { get; set; }
        public int FacturasEmitidas { get; set; }
        public decimal Ventas { get; set; }
    }
}
