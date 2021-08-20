using FacturacionApi.Services;
using FacturacionApi.ViewModels.Reporte;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        [HttpGet("GetReporteVendedores")]
        public async Task<ActionResult<List<VendedorVentasPorMesViewModel>>> GetReporteVendedores()
        {
            using ReporteService reporteService = new();

            var result = await reporteService.GetVendedorVentas();

            return result;
        }
    }
}
