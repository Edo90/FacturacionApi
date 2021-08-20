using FacturacionApi.Models.Entities;
using FacturacionApi.Repositories;
using FacturacionApi.Services;
using FacturacionApi.ViewModels.Facturacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        ///CRUD
        ///
        private readonly IRepository<Facturacion> _facturacionRepo;
        private readonly IRepository<FacturacionDetalle> _facturacionDetalleRepo;
        public FacturacionController(IRepository<Facturacion> repository, IRepository<FacturacionDetalle> detalleRepo)
        {
            _facturacionRepo = repository;
            _facturacionDetalleRepo = detalleRepo;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<FacturacionViewModel>> GetById(int id)
        {

            try
            {
                var factura = await _facturacionRepo.Queryable().Select(factura => new FacturacionViewModel()
                {
                    Id = factura.Id,
                    Cliente = factura.Cliente.NombreComercial,
                    ClienteId = factura.ClienteId,
                    Comentario = factura.Comentario,
                    Fecha = factura.Fecha,
                    Vendedor = factura.Vendedor.Nombre,
                    VendedorId = factura.VendedorId,
                    Detalle = _facturacionDetalleRepo.Queryable().Where(x => x.FacturacionId == factura.Id).Select(detalle => new FacturacionDetalleViewModel()
                    {
                        ArticuloId = detalle.ArticuloId,
                        Cantidad = detalle.Cantidad,
                        PrecioUnitario = detalle.PrecioUnitario,
                        Articulo = detalle.Articulo.Descripcion,
                        IdAsiento = detalle.AsientoId,
                        Id = detalle.Id
                    }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

                return Ok(factura);
            }
            catch (Exception)
            {

                return BadRequest(($"Ocurrio un error con el {0} de Facturacion", id));
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<FacturacionViewModel>>> GetAll()
        {
            try
            {
                var facturas = await _facturacionRepo.Queryable().Select(factura => new FacturacionViewModel()
                {
                    Id = factura.Id,
                    Cliente = factura.Cliente.NombreComercial,
                    ClienteId = factura.ClienteId,
                    Comentario = factura.Comentario,
                    Fecha = factura.Fecha,
                    Vendedor = factura.Vendedor.Nombre,
                    VendedorId = factura.VendedorId,
                    Detalle = _facturacionDetalleRepo.Queryable().Where(x => x.FacturacionId == factura.Id).Select(x => new FacturacionDetalleViewModel()
                    {
                        ArticuloId = x.ArticuloId,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Articulo = x.Articulo.Descripcion,
                        IdAsiento = x.AsientoId,
                        Id = x.Id

                    }).ToList()
                }).ToListAsync();

                return Ok(facturas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult<int> CreateFacturacion(CreateFacturacionViewModel model)
        {
            try
            {
                List<FacturacionDetalle> detalle = new();

                Facturacion cabecera = new()
                {
                    ClienteId = model.ClienteId,
                    Comentario = model.Comentario,
                    Fecha = model.Fecha,
                    VendedorId = model.VendedorId,
                };

                _facturacionRepo.Insert(cabecera);

                if (model.Detalle.Any())
                {

                    foreach (var item in model.Detalle)
                    {
                        detalle.Add(new FacturacionDetalle()
                        {
                            ArticuloId = item.ArticuloId,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUnitario,
                            FacturacionId = cabecera.Id
                        });
                    }
                    _facturacionDetalleRepo.InsertRange(detalle);

                }


                return Ok(($"Factura creada con exito id {0}", cabecera.Id));
            }
            catch (Exception)
            {
                return BadRequest("No se pudo Insertar modelo");
            }

        }

        [HttpPut]
        public ActionResult UpdateFacturacion(FacturacionViewModel viewModel)
        {
            var factura = _facturacionRepo.Find(viewModel.Id);

            factura.VendedorId = viewModel.VendedorId;
            factura.ClienteId = viewModel.ClienteId;
            factura.Fecha = viewModel.Fecha;
            factura.Comentario = viewModel.Comentario;
            List<FacturacionDetalle> detalles = GetDetallesToUpdate(viewModel);

            try
            {
                _facturacionRepo.Update(factura);
                _facturacionDetalleRepo.UpdateRange(detalles);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private List<FacturacionDetalle> GetDetallesToUpdate(FacturacionViewModel viewModel)
        {
            List<FacturacionDetalle> detalles = _facturacionDetalleRepo.Queryable().Where(x => x.FacturacionId == viewModel.Id).ToList();

            if (viewModel.Detalle.Any())
            {
                foreach (var item in viewModel.Detalle)
                {

                    if (item.Id == 0)
                    {
                        _facturacionDetalleRepo.Insert(new FacturacionDetalle()
                        {
                            ArticuloId = item.ArticuloId,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUnitario,
                            FacturacionId = viewModel.Id,
                            AsientoId = item.IdAsiento
                        });
                    }
                    else
                    {
                        detalles.Where(x => x.Id == item.Id)
                            .ToList()
                            .ForEach(t => { t.PrecioUnitario = item.PrecioUnitario; t.ArticuloId = item.ArticuloId; t.Cantidad = item.Cantidad; t.AsientoId = item.IdAsiento; });
                    }
                }

            }

            return detalles;
        }

        [HttpDelete]
        public ActionResult DeleteFacturacion(int id)
        {
            try
            {
                var factura = _facturacionRepo.Find(id);
                _facturacionRepo.Delete(factura);
                return Ok("Ha sido eliminado");
            }
            catch (Exception)
            {

                return BadRequest(($"El id {0} no ha sido encontrado", id));
            }

        }

        [HttpPost("Contabilizar")]
        public ActionResult Contabilizar(FacturacionViewModel viewModel)
        {
            try
            {
                using ContabilidadService service = new();
                service.PostAsientoContable(viewModel);
            }
            catch
            {
                return BadRequest("No se pudo completar la solicitud");
            }
            try
            {
                var detalles = GetDetallesToUpdate(viewModel);
                _facturacionDetalleRepo.UpdateRange(detalles);
            }
            catch
            {
                return BadRequest("No se pudo Actualizar asiento contables de manera local");
            }

            return Ok("Asiento Contable ha sido obtenido y actualizado");
        }
    }
}
