using FacturacionApi.Models;
using FacturacionApi.ViewModels;
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
    public class ClienteController : ControllerBase
    {
        [HttpGet("GetById")]
        public ActionResult<ClienteViewModel> GetById(int id)
        {
            try
            {
                using var _dbContext = new FacturacionDbContext();
                var cliente = _dbContext.Clientes.FirstOrDefault(x => x.Id == id);
                if (cliente == null)
                    return NotFound();

                ClienteViewModel viewModel = new()
                {
                    Id = cliente.Id,
                    Cedula = cliente.Cedula,
                    CuentaContable = cliente.CuentaContable,
                    Estado = cliente.Estado,
                    NombreComercial = cliente.NombreComercial
                };
                return Ok(viewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ClienteViewModel>> GetAll()
        {
            using var _dbContext = new FacturacionDbContext();

            var clientes = _dbContext.Clientes.Where(x => x.Estado).ToList();
            List<ClienteViewModel> result = new();
            foreach (var cliente in clientes)
            {
                result.Add(new ClienteViewModel()
                {
                    Id = cliente.Id,
                    Cedula = cliente.Cedula,
                    CuentaContable = cliente.CuentaContable,
                    Estado = cliente.Estado,
                    NombreComercial = cliente.NombreComercial
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCliente(CreateClienteViewModel viewModel)
        {
            try
            {
                var cliente = new Models.Entities.Cliente()
                {
                    Cedula = viewModel.Cedula,
                    NombreComercial = viewModel.NombreComercial,
                    Estado = viewModel.Estado,
                    CuentaContable = viewModel.CuentaContable
                };

                using var _dbContext = new FacturacionDbContext();

                _dbContext.Clientes.Add(cliente);

                await _dbContext.SaveChangesAsync();

                return Ok(cliente.Id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut]
        public ActionResult UpdateCliente(ClienteViewModel viewModel)
        {
            using var _dbContext = new FacturacionDbContext();

            var existing = _dbContext.Clientes.FirstOrDefault(x => x.Id == viewModel.Id);

            if (existing == null)
                return NotFound();

            existing.CuentaContable = viewModel.CuentaContable;
            existing.Estado = viewModel.Estado;
            existing.Cedula = viewModel.Cedula;
            existing.NombreComercial = viewModel.NombreComercial;

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using var _dbContext = new FacturacionDbContext();

            var cliente = _dbContext.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null) return NotFound();
            cliente.Estado = false;
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
