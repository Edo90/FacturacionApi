using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels
{
    public class ArticuloViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Estado { get; set; }
    }
}
