using FacturacionApi.Models;
using FacturacionApi.Models.Entities;
using FacturacionApi.ViewModels.Reporte;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Services
{
    public class ReporteService : IDisposable
    {
        private bool disposedValue;

        public async Task<List<VendedorVentasPorMesViewModel>> GetVendedorVentas()
        {
            using var _dbContext = new FacturacionDbContext();

            var vendedorVentasPorMes = _dbContext.FacturacionDetalle.Include(x => x.Facturacion)
                                                    .ThenInclude(x => x.Vendedor)
                                                    .GroupBy(x => 
                                                    new { 
                                                        x.Facturacion.VendedorId, 
                                                        x.Facturacion.Vendedor.Nombre
                                                    })
                                                    .Select(x => 
                                                    new VendedorVentasPorMesViewModel{
                                                            VendedorId = x.Key.VendedorId,
                                                            NombreVendedor = x.Key.Nombre,
                                                            FacturasEmitidas =0, /*x.Count(t => t.Facturacion.Id > 0), 
*/                                                            Ventas = x.Sum(x => x.Cantidad * x.PrecioUnitario) })
                                                     .ToList();


            return vendedorVentasPorMes;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ReporteService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
