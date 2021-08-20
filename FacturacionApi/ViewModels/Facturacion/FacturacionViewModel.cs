using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.Facturacion
{
    public class FacturacionViewModel
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public string Vendedor { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public List<FacturacionDetalleViewModel> Detalle { get; set; }


    }
   
}
