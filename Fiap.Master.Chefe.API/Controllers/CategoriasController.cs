using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fiap.Master.Chefe.Core.Repository;
using Fiap.Master.Chefe.Core.Model;

namespace Fiap.Master.Chefe.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorias")]
    public class CategoriasController : Controller
    {
        CategoriasRepository _contexto = new CategoriasRepository(new MasterChefeContext());

        // GET: api/Categorias
        [HttpGet]
        public IActionResult Get()
        {
            var result = _contexto.Listar();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _contexto.ListarPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        // POST: api/Categorias
        [HttpPost]
        public IActionResult Post([FromBody]Categorias entity)
        {
            try
            {
                _contexto.Incluir(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Categorias entity)
        {
            try
            {
                _contexto.Atualizar(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entidade = _contexto.ListarPorId(id);
                _contexto.Excluir(entidade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
