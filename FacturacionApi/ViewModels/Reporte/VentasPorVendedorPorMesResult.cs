using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.Reporte
{
    public class VentasPorVendedorPorMesResult
    {
        public VentasPorVendedorPorMesResult(List<VendedorVentasPorMesViewModel> result, int pageIndex, int totalPages)
        {
            Result = result;
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }

        public List<VendedorVentasPorMesViewModel> Result { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
