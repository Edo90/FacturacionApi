using FacturacionApi.Models.Entities;
using FacturacionApi.Repositories;
using FacturacionApi.ViewModels.AsientoContable;
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
    public class AsientoContableController : ControllerBase
    {
        private readonly IRepository<AsientoContable> _asientoContableRepository;

        public AsientoContableController(IRepository<AsientoContable> asientoContableRepository)
        {
            _asientoContableRepository = asientoContableRepository;
        }


        [HttpGet("GetById")]
        public ActionResult<AsientoContableViewModel> GetById(int id)
        {
            try
            {
                var asiento = _asientoContableRepository.Queryable().Select(asiento => new
                {
                    asiento.Id,
                    asiento.Descripcion,
                    asiento.ClienteId,
                    asiento.Cliente.NombreComercial,
                    asiento.Cuenta,
                    asiento.TipoDeMovimiento,
                    asiento.FechaAsiento,
                    asiento.MontoAsiento,
                    asiento.Estado
                }).FirstOrDefault();

                return Ok(asiento);
            }
            catch (Exception)
            {

                return BadRequest(($"Ocurrio un error con el id {0} de Asiento", id));
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AsientoContableViewModel>>> GetAll()
        {
            try
            {
                var asientos = await _asientoContableRepository.Queryable().Select(asiento => new
                {
                    asiento.Id,
                    asiento.Descripcion,
                    asiento.ClienteId,
                    asiento.Cliente.NombreComercial,
                    asiento.Cuenta,
                    asiento.TipoDeMovimiento,
                    asiento.FechaAsiento,
                    asiento.MontoAsiento,
                    asiento.Estado
                }).ToListAsync();

                return Ok(asientos);
            }
            catch (Exception)
            {

                return BadRequest("No se pudo completar la solicitud");
            }

        }

        [HttpPost]
        public ActionResult CreateAsiento(CreateAsientoViewModel viewModel)
        {
            try
            {
                _asientoContableRepository.Insert(new()
                {
                    ClienteId = viewModel.ClienteId,
                    Cuenta = viewModel.Cuenta,
                    Descripcion = viewModel.Descripcion,
                    Estado = viewModel.Estado,
                    FechaAsiento = viewModel.FechaAsiento,
                    MontoAsiento = viewModel.MontoAsiento,
                    TipoDeMovimiento = (TipoDeMovimiento)viewModel.TipoDeMovimiento
                });
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("El objeto no pudo ser agregado");
            }

        }

        [HttpPut]
        public ActionResult UpdateAsiento(AsientoContableViewModel viewModel)
        {
            try
            {
                var asiento = _asientoContableRepository.Find(viewModel.Id);
                if (asiento == null)
                    return NotFound("El Asiento no fue encontrado");
                asiento.MontoAsiento = viewModel.MontoAsiento;
                asiento.ClienteId = viewModel.ClienteId;
                asiento.Cuenta = viewModel.Cuenta;
                asiento.Descripcion = viewModel.Descripcion;
                asiento.Estado = viewModel.Estado;
                asiento.FechaAsiento = viewModel.FechaAsiento;
                asiento.MontoAsiento = viewModel.MontoAsiento;
                asiento.TipoDeMovimiento = viewModel.TipoDeMovimiento;

                _asientoContableRepository.Update(asiento);

                return Ok("Ha sido actualizado con exito!");
            }
            catch (Exception)
            {

                return BadRequest("El asiento no puedo ser actualizado");
            }
        }

        [HttpDelete]
        public ActionResult DeleteAsiento(int id)
        {
            try
            {
                var asiento = _asientoContableRepository.Find(id);
                if (asiento == null)
                    return NotFound();
                _asientoContableRepository.Delete(asiento);
                return Ok("Asiento fue eliminado");
            }
            catch (Exception)
            {
                return BadRequest("No pude ser completada la solicitud");
            }
        }
    }
}
