﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Models.Entities
{
    public class Facturacion
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
