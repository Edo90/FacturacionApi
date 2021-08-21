using FacturacionApi.Models;
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
        public async Task<ActionResult<VentasPorVendedorPorMesResult>> GetReporteVendedores(int pageNumber = 1)
        {
            using ReporteService reporteService = new();

            var reporte = await reporteService.GetVendedorVentas(pageNumber);

            var result = new VentasPorVendedorPorMesResult(reporte,reporte.PageIndex,reporte.TotalPages);


            return result;
        }
    }
}
