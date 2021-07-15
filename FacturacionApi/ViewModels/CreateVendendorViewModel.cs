using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels
{
    public class CreateVendendorViewModel
    {
        public string Nombre { get; set; }
        public decimal PorcientoDeComision { get; set; }
        public bool Estado { get; set; }
    }
}
