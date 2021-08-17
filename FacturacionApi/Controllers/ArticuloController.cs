using AutoMapper;
using FacturacionApi.Models;
using FacturacionApi.Models.Entities;
using FacturacionApi.Repositories;
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
    public class ArticuloController : ControllerBase
    {
        private readonly IRepository<Articulo> _repo;
        public ArticuloController(IRepository<Articulo> repo)
        {
            _repo = repo;
        }

        [HttpGet("GetById")]
        public ActionResult<ArticuloViewModel> GetById(int id)
        {
            try
            {

                using var _dbContext = new FacturacionDbContext();
                //var _repo = new ArticuloRepository(_dbContext);
                //var test = _repo.Find(id);
                //var test2 = _repo.SumTwoDBNumbers();

                var articulo = _dbContext.Articulos.FirstOrDefault(x => x.Id == id);

                if (articulo == null) return NotFound();

                ArticuloViewModel viewModel = new()
                {
                    Id = articulo.Id,
                    Descripcion = articulo.Descripcion,
                    Estado = articulo.Estado,
                    PrecioUnitario = articulo.PrecioUnitario
                };
                return Ok(viewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ArticuloViewModel>> GetAll()
        {
            using var _dbContext = new FacturacionDbContext();

            var articulos = _dbContext.Articulos.Where(x => x.Estado).ToList();
            List<ArticuloViewModel> result = new();
            foreach (var item in articulos)
            {
                result.Add(new ArticuloViewModel()
                {
                    Descripcion = item.Descripcion,
                    Estado = item.Estado,
                    Id= item.Id,
                    PrecioUnitario = item.PrecioUnitario
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateArticulo(CreateArticuloViewModel viewModel)
        {
            try
            {
                var articulo = new Articulo()
                {
                    Descripcion = viewModel.Descripcion,
                    Estado = viewModel.Estado,
                    PrecioUnitario = viewModel.PrecioUnitario
                };

                using var _dbContext = new FacturacionDbContext();
               
                _dbContext.Articulos.Add(articulo);

                await _dbContext.SaveChangesAsync();
                
                return Ok(articulo.Id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut]
        public ActionResult UpdateArticulo(ArticuloViewModel viewModel)
        {
            using var _dbContext = new FacturacionDbContext();

            var existing = _dbContext.Articulos.FirstOrDefault(x => x.Id == viewModel.Id);

            if(existing == null)
                return NotFound();
            
            existing.PrecioUnitario = viewModel.PrecioUnitario;
            existing.Estado = viewModel.Estado;
            existing.Descripcion = viewModel.Descripcion;
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using var _dbContext = new FacturacionDbContext();

            var articulo = _dbContext.Articulos.FirstOrDefault(x => x.Id == id);

            articulo.Estado = false;
            _dbContext.SaveChanges();
            return Ok();
        }


    }
}
