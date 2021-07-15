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
    public class VendedorController : ControllerBase
    {
        [HttpGet("GetById")]
        public ActionResult<VendedorViewModel> GetById(int id)
        {
            try
            {
                using var _dbContext = new FacturacionDbContext();
                var vendedor = _dbContext.Vendedores.FirstOrDefault(x => x.Id == id);
                if (vendedor == null) return NotFound();

                VendedorViewModel viewModel = new()
                {
                    Id = vendedor.Id,
                    Estado = vendedor.Estado,
                    Nombre = vendedor.Nombre,
                    PorcientoDeComision = vendedor.PorcientoDeComision
                };
                return Ok(viewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<List<VendedorViewModel>> GetAll()
        {
            using var _dbContext = new FacturacionDbContext();

            var vendedores = _dbContext.Vendedores.Where(x => x.Estado).ToList();
            List<VendedorViewModel> result = new();
            foreach (var item in vendedores)
            {
                result.Add(new VendedorViewModel()
                {
                    Nombre = item.Nombre,
                    PorcientoDeComision = item.PorcientoDeComision,
                    Estado = item.Estado,
                    Id = item.Id
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateVendedor(CreateVendendorViewModel viewModel)
        {
            try
            {
                var vendedor = new Models.Entities.Vendedor()
                {
                    Nombre = viewModel.Nombre,
                    Estado = viewModel.Estado,
                    PorcientoDeComision = viewModel.PorcientoDeComision
                };

                using var _dbContext = new FacturacionDbContext();

                _dbContext.Vendedores.Add(vendedor);

                await _dbContext.SaveChangesAsync();

                return Ok(vendedor.Id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut]
        public ActionResult UpdateVendedor(VendedorViewModel viewModel)
        {
            using var _dbContext = new FacturacionDbContext();

            var existing = _dbContext.Vendedores.FirstOrDefault(x => x.Id == viewModel.Id);

            if (existing == null)
                return NotFound();

            existing.PorcientoDeComision = viewModel.PorcientoDeComision;
            existing.Estado = viewModel.Estado;
            existing.Nombre = viewModel.Nombre;
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using var _dbContext = new FacturacionDbContext();

            var vendendor = _dbContext.Vendedores.FirstOrDefault(x => x.Id == id);
            if (vendendor == null) return NotFound();

            vendendor.Estado = false;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
