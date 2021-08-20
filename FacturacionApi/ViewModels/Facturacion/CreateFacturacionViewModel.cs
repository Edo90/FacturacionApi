﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.Facturacion
{
    public class CreateFacturacionViewModel
    {
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public IEnumerable<FacturacionDetalleViewModel> Detalle { get; set; }
       
    }
    public class FacturacionDetalleViewModel
    {
        public int Id { get; set; }
        public string Articulo { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int? IdAsiento { get; set; }
    }
}
