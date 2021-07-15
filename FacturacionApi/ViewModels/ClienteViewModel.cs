﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string NombreComercial { get; set; }
        public string Cedula { get; set; }
        public string CuentaContable { get; set; }
        public bool Estado { get; set; }
    }
}
