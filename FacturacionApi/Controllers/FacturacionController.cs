using FacturacionApi.Models.Entities;
using FacturacionApi.Repositories;
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
        public FacturacionController(IRepository<Facturacion> repository)
        {
            _facturacionRepo = repository;
        }

        [HttpGet("GetById")]
        public ActionResult<FacturacionViewModel> GetById(int id)
        {
            try
            {
                var Facturacion = _facturacionRepo.Find(id);
                FacturacionViewModel viewModel = new()
                {
                    Articulo = Facturacion.Articulo.Descripcion,
                    ArticuloId = Facturacion.ArticuloId,
                    Id = Facturacion.Id,
                    Cantidad = Facturacion.Cantidad,
                    Cliente = Facturacion.Cliente.NombreComercial,
                    ClienteId = Facturacion.ClienteId,
                    Comentario = Facturacion.Comentario,
                    Fecha = Facturacion.Fecha,
                    PrecioUnitario = Facturacion.PrecioUnitario,
                    Vendedor = Facturacion.Vendedor.Nombre,
                    VendedorId = Facturacion.VendedorId
                };

                return Ok(viewModel);
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
                var facturas = await _facturacionRepo.Queryable().Select(factura => new {
                    factura.Articulo.Descripcion,
                    factura.ArticuloId,
                    factura.Id,
                    factura.Cantidad,
                    factura.Cliente.NombreComercial,
                    factura.ClienteId,
                    factura.Comentario,
                    factura.Fecha,
                    factura.PrecioUnitario,
                    factura.Vendedor.Nombre,
                    factura.VendedorId
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
                
                _facturacionRepo.Insert(new()
                {
                    ArticuloId = model.ArticuloId,
                    Cantidad = model.Cantidad,
                    ClienteId = model.ClienteId,
                    Comentario = model.Comentario,
                    Fecha = model.Fecha,
                    PrecioUnitario = model.PrecioUnitario,
                    VendedorId = model.VendedorId
                });

                _facturacionRepo.SaveChanges();

                return Ok();
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
            factura.PrecioUnitario = viewModel.PrecioUnitario;
            factura.VendedorId = viewModel.VendedorId;
            factura.ArticuloId = viewModel.ArticuloId;
            factura.Cantidad = viewModel.Cantidad;
            factura.ClienteId = viewModel.ClienteId;
            factura.Fecha = viewModel.Fecha;
            factura.Comentario = viewModel.Comentario;

            try
            {
                _facturacionRepo.Update(factura);
                _facturacionRepo.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete]
        public ActionResult DeleteFacturacion(int id)
        {
            try
            {
                var factura = _facturacionRepo.Find(id);
                _facturacionRepo.Delete(factura);
                _facturacionRepo.SaveChanges();
                return Ok("Ha sido eliminado");
            }
            catch (Exception)
            {

                return BadRequest(($"El id {0} no ha sido encontrado",id));
            }
            
        }
    }
}
